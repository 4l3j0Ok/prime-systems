using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class CompraController
    {
        private readonly AppDbContext _context;

        public CompraController()
        {
            _context = new AppDbContext();
        }

        public CompraController(AppDbContext context)
        {
            _context = context;
        }

        public List<HCompraModel> GetAllCompras()
        {
            return _context.HCompras
                .Include(c => c.Usuario)
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                .ToList();
        }

        public HCompraModel? GetCompraById(int id)
        {
            return _context.HCompras
                .Include(c => c.Usuario)
                .Include(c => c.Proveedor)
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(c => c.IdRemito == id);
        }

        public bool CreateCompra(HCompraModel compra)
        {
            try
            {
                _context.HCompras.Add(compra);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool CreateCompraConDetalles(HCompraModel compra, List<HCompraDetalleModel> detalles)
        {
            try
            {
                _context.HCompras.Add(compra);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.IdRemito = compra.IdRemito;
                    _context.HComprasDetalle.Add(detalle);
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

        public List<HCompraModel> GetComprasByProveedor(int proveedorId)
        {
            return _context.HCompras
                .Include(c => c.Usuario)
                .Include(c => c.Proveedor)
                .Where(c => c.IdProveedor == proveedorId)
                .ToList();
        }

        public List<HCompraModel> GetComprasByUsuario(int usuarioId)
        {
            return _context.HCompras
                .Include(c => c.Usuario)
                .Include(c => c.Proveedor)
                .Where(c => c.CodUsuario == usuarioId)
                .ToList();
        }
    }
}
