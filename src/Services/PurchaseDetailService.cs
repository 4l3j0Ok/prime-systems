using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Services
{
    public class PurchaseDetailService : IGenericController<PurchaseDetailModel, int>
    {
        private readonly AppDbContext _context;

        public PurchaseDetailService()
        {
            _context = new AppDbContext();
        }

        public PurchaseDetailService(AppDbContext context)
        {
            _context = context;
        }

        public List<PurchaseDetailModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .AsQueryable();

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<PurchaseDetailModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.PurchaseDetail
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(d =>
                    (d.Description != null && d.Description.ToLower().Contains(searchTerm)) ||
                    (d.Article != null && d.Article.Name != null && d.Article.Name.ToLower().Contains(searchTerm)) ||
                    (d.Article != null && d.Article.Code.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
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