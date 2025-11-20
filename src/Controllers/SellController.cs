using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class SellController : IGenericController<SellModel, int>
    {
        private readonly AppDbContext _context;
        private readonly StockController _stockController;

        public SellController()
        {
            _context = new AppDbContext();
            _stockController = new StockController(_context);
        }

        public SellController(AppDbContext context)
        {
            _context = context;
            _stockController = new StockController(context);
        }

        public List<SellModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(v => v.Active);
            }

            query = query.OrderByDescending(v => v.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<SellModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(v => v.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(v =>
                    (v.Title != null && v.Title.ToLower().Contains(searchTerm)) ||
                    (v.Description != null && v.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderByDescending(v => v.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public SellModel? GetById(int id)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefault(v => v.Id == id);
        }

        public bool Create(SellModel venta)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(SellModel venta)
        {
            try
            {
                var existing = _context.Sell.Find(venta.Id);
                if (existing == null) return false;

                existing.UserId = venta.UserId;
                existing.ClientId = venta.ClientId;
                existing.Date = venta.Date;
                existing.Active = venta.Active;
                existing.Subtotal = venta.Subtotal;
                existing.Discount = venta.Discount;
                existing.Total = venta.Total;
                existing.Title = venta.Title;
                existing.Description = venta.Description;

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
                var venta = _context.Sell.Find(id);
                if (venta == null) return false;
                
                // Baja lógica
                venta.Active = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateVentaConDetalles(SellModel venta, List<SellDetailModel> detalles)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    // Reducir el stock si el detalle tiene un artículo asociado
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = _stockController.AdjustStock(detalle.ArticleId.Value, -detalle.Quantity.Value);
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

        public bool UpdateVentaConDetalles(SellModel venta, List<SellDetailModel> detalles)
        {
            try
            {
                // Actualizar la venta
                var existing = _context.Sell.Find(venta.Id);
                if (existing == null) return false;

                existing.UserId = venta.UserId;
                existing.ClientId = venta.ClientId;
                existing.Date = venta.Date;
                existing.Active = venta.Active;
                existing.Subtotal = venta.Subtotal;
                existing.Discount = venta.Discount;
                existing.Total = venta.Total;
                existing.Title = venta.Title;
                existing.Description = venta.Description;

                // Obtener los detalles anteriores para restaurar el stock
                var oldDetails = _context.SellDetail.Where(d => d.SellId == venta.Id).ToList();
                
                // Restaurar el stock de los artículos vendidos anteriormente
                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && oldDetail.Quantity.HasValue)
                    {
                        _stockController.AdjustStock(oldDetail.ArticleId.Value, oldDetail.Quantity.Value);
                    }
                }

                // Eliminar los detalles anteriores
                _context.SellDetail.RemoveRange(oldDetails);

                // Agregar los nuevos detalles y reducir el stock
                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    // Reducir el stock si el detalle tiene un artículo asociado
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = _stockController.AdjustStock(detalle.ArticleId.Value, -detalle.Quantity.Value);
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

        public List<SellModel> GetVentasByCliente(int clienteId)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.ClientId == clienteId)
                .ToList();
        }

        public List<SellModel> GetVentasByUsuario(int usuarioId)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.UserId == usuarioId)
                .ToList();
        }
    }
}
