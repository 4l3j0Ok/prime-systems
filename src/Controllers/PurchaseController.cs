using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class PurchaseController : IGenericController<PurchaseModel, int>
    {
        private readonly AppDbContext _context;
        private readonly StockController _stockController;

        public PurchaseController()
        {
            _context = new AppDbContext();
            _stockController = new StockController(_context);
        }

        public PurchaseController(AppDbContext context)
        {
            _context = context;
            _stockController = new StockController(context);
        }

        public List<PurchaseModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            // Note: PurchaseModel doesn't have Active field based on requirements, so we just order
            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<PurchaseModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(c =>
                    (c.Title != null && c.Title.ToLower().Contains(searchTerm)) ||
                    (c.Description != null && c.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public PurchaseModel? GetById(int id)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool Create(PurchaseModel compra)
        {
            try
            {
                _context.Purchase.Add(compra);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(PurchaseModel compra)
        {
            try
            {
                var existing = _context.Purchase.Find(compra.Id);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Purchase.Find(id);
                if (entity == null) return false;
                _context.Purchase.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                _context.Purchase.Add(compra);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);
                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = _stockController.AdjustStock(detalle.ArticleId.Value, quantity);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                // Actualizar la compra
                var existing = _context.Purchase.Find(compra.Id);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

                // Obtener los detalles anteriores para restaurar el stock
                var oldDetails = _context.PurchaseDetail.Where(d => d.PurchaseId == compra.Id).ToList();

                // Restaurar el stock de los artículos comprados anteriormente (restar)
                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && int.TryParse(oldDetail.Quantity, out int quantity))
                    {
                        _stockController.AdjustStock(oldDetail.ArticleId.Value, -quantity);
                    }
                }

                // Eliminar los detalles anteriores
                _context.PurchaseDetail.RemoveRange(oldDetails);

                // Agregar los nuevos detalles y aumentar el stock
                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);

                    // Aumentar el stock si el detalle tiene un artículo asociado
                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = _stockController.AdjustStock(detalle.ArticleId.Value, quantity);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public List<PurchaseModel> GetComprasByProveedor(int proveedorId)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.SupplierId == proveedorId)
                .ToList();
        }

        public List<PurchaseModel> GetComprasByUsuario(int usuarioId)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.UserId == usuarioId)
                .ToList();
        }
    }
}
