using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class PurchaseDetailController : IGenericController<PurchaseDetailModel, int>
    {
        private readonly AppDbContext _context;

        public PurchaseDetailController()
        {
            _context = new AppDbContext();
        }

        public PurchaseDetailController(AppDbContext context)
        {
            _context = context;
        }

        public List<PurchaseDetailModel> GetAll()
        {
            return _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .ToList();
        }

        public PurchaseDetailModel? GetById(int id)
        {
            return _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .FirstOrDefault(d => d.Id == id);
        }

        public List<PurchaseDetailModel> GetDetallesByCompra(int compraId)
        {
            return _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .Where(d => d.PurchaseId == compraId)
                .ToList();
        }

        public List<PurchaseDetailModel> GetDetallesByArticulo(int articuloId)
        {
            return _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .Where(d => d.ArticleId == articuloId)
                .ToList();
        }

        public bool Create(PurchaseDetailModel detalle)
        {
            try
            {
                _context.PurchaseDetail.Add(detalle);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(PurchaseDetailModel detalle)
        {
            try
            {
                var existingDetalle = _context.PurchaseDetail.Find(detalle.Id);
                if (existingDetalle == null)
                    return false;

                existingDetalle.PurchaseId = detalle.PurchaseId;
                existingDetalle.ArticleId = detalle.ArticleId;
                existingDetalle.Description = detalle.Description;
                existingDetalle.UnitPrice = detalle.UnitPrice;
                existingDetalle.Quantity = detalle.Quantity;
                existingDetalle.Total = detalle.Total;

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
                var detalle = _context.PurchaseDetail.Find(id);
                if (detalle == null) return false;
                _context.PurchaseDetail.Remove(detalle);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}