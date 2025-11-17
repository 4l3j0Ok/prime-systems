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

        public List<SellModel> GetAll()
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .ToList();
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
                _context.Sell.Remove(venta);
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
