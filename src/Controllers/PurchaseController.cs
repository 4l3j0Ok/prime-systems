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

        public PurchaseController()
        {
            _context = new AppDbContext();
        }

        public PurchaseController(AppDbContext context)
        {
            _context = context;
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
                // TODO: map fields as needed
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
