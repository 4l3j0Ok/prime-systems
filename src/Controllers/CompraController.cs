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

        public List<PurchaseModel> GetAllCompras()
        {
            return _context.HCompras
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .ToList();
        }

        public PurchaseModel? GetCompraById(int id)
        {
            return _context.HCompras
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool CreateCompra(PurchaseModel compra)
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

        public bool CreateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                _context.HCompras.Add(compra);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.IdRemito = compra.Id;
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

        public List<PurchaseModel> GetComprasByProveedor(int proveedorId)
        {
            return _context.HCompras
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.SupplierId == proveedorId)
                .ToList();
        }

        public List<PurchaseModel> GetComprasByUsuario(int usuarioId)
        {
            return _context.HCompras
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.UserId == usuarioId)
                .ToList();
        }
    }
}
