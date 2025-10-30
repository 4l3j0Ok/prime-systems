using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class VentaController : IGenericController<SellModel>
    {
        private readonly AppDbContext _context;

        public VentaController()
        {
            _context = new AppDbContext();
        }

        public VentaController(AppDbContext context)
        {
            _context = context;
        }

        public List<SellModel> GetAll()
        {
            return _context.HVentas
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .ToList();
        }

        public SellModel? GetById(object id)
        {
            if (id is int intId) return GetVentaById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetVentaById(parsed);
            return null;
        }

        public SellModel? GetVentaById(int id)
        {
            return _context.HVentas
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
                _context.HVentas.Add(venta);
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
                var existing = _context.HVentas.Find(venta.Id);
                if (existing == null) return false;
                // TODO: map fields as needed
                // example: existing.Total = venta.Total;
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
                var entity = _context.HVentas.Find(intId);
                if (entity == null) return false;
                _context.HVentas.Remove(entity);
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
                _context.HVentas.Add(venta);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.HVentasDetalle.Add(detalle);
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
            return _context.HVentas
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.ClientId == clienteId)
                .ToList();
        }

        public List<SellModel> GetVentasByUsuario(int usuarioId)
        {
            return _context.HVentas
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.UserId == usuarioId)
                .ToList();
        }
    }
}
