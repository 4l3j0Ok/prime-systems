using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class PurchaseController : IGenericController<PurchaseModel>
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

        public List<PurchaseModel> GetAll()
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .ToList();
        }

        public PurchaseModel? GetById(object id)
        {
            if (id is int intId) return GetCompraById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetCompraById(parsed);
            return null;
        }

        public PurchaseModel? GetCompraById(int id)
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
                existing.FechaHora = compra.FechaHora;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                if (!int.TryParse(id?.ToString(), out int intId)) return false;
                var entity = _context.Purchase.Find(intId);
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

        public bool UpdateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                // Actualizar la compra
                var existing = _context.Purchase.Find(compra.Id);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.FechaHora = compra.FechaHora;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;

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
