using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class SellDetailController : IGenericController<SellDetailModel, int>
    {
        private readonly AppDbContext _context;

        public SellDetailController()
        {
            _context = new AppDbContext();
        }

        public SellDetailController(AppDbContext context)
        {
            _context = context;
        }

        public List<SellDetailModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .AsQueryable();

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<SellDetailModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(d =>
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

        public SellDetailModel? GetById(int id)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .FirstOrDefault(d => d.Id == id);
        }

        public List<SellDetailModel> GetDetallesByVenta(int ventaId)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.SellId == ventaId)
                .ToList();
        }

        public List<SellDetailModel> GetDetallesByArticulo(int articuloId)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.ArticleId == articuloId)
                .ToList();
        }

        public bool Create(SellDetailModel detalle)
        {
            try
            {
                _context.SellDetail.Add(detalle);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(SellDetailModel detalle)
        {
            try
            {
                var existingDetalle = _context.SellDetail.Find(detalle.Id);
                if (existingDetalle == null)
                    return false;

                existingDetalle.SellId = detalle.SellId;
                existingDetalle.ArticleId = detalle.ArticleId;
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
                var detalle = _context.SellDetail.Find(id);
                if (detalle == null) return false;
                _context.SellDetail.Remove(detalle);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateBatch(List<SellDetailModel> detalles)
        {
            try
            {
                _context.SellDetail.AddRange(detalles);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteByVenta(int ventaId)
        {
            try
            {
                var detalles = _context.SellDetail.Where(d => d.SellId == ventaId);
                _context.SellDetail.RemoveRange(detalles);
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