using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class VentaController
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

        public List<SellModel> GetAllVentas()
        {
            return _context.HVentas
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .ToList();
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

        public bool CreateVenta(SellModel venta)
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
