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

        public List<HVentaModel> GetAllVentas()
        {
            return _context.HVentas
                .Include(v => v.Usuario)
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .ToList();
        }

        public HVentaModel? GetVentaById(int id)
        {
            return _context.HVentas
                .Include(v => v.Usuario)
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(v => v.IdRemito == id);
        }

        public bool CreateVenta(HVentaModel venta)
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

        public bool CreateVentaConDetalles(HVentaModel venta, List<HVentaDetalleModel> detalles)
        {
            try
            {
                _context.HVentas.Add(venta);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.IdRemito = venta.IdRemito;
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

        public List<HVentaModel> GetVentasByCliente(int clienteId)
        {
            return _context.HVentas
                .Include(v => v.Usuario)
                .Include(v => v.Cliente)
                .Where(v => v.IdCliente == clienteId)
                .ToList();
        }

        public List<HVentaModel> GetVentasByUsuario(int usuarioId)
        {
            return _context.HVentas
                .Include(v => v.Usuario)
                .Include(v => v.Cliente)
                .Where(v => v.IdUsuario == usuarioId)
                .ToList();
        }
    }
}
