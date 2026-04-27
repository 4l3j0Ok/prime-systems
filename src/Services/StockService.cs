using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Services
{
    public class StockService : IGenericController<StockModel, int>
    {
        private readonly AppDbContext _context;

        public StockService()
        {
            _context = new AppDbContext();
        }

        public StockService(AppDbContext context)
        {
            _context = context;
        }

        public List<StockModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Stock
                .Include(s => s.Article)
                .AsQueryable();

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<StockModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Stock
                .Include(s => s.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(s =>
                    (s.Article != null && s.Article.Name != null && s.Article.Name.ToLower().Contains(searchTerm)) ||
                    (s.Article != null && s.Article.Code.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public StockModel? GetById(int id)
        {
            return _context.Stock
                .Include(s => s.Article)
                .FirstOrDefault(s => s.Id == id);
        }

        public StockModel? GetStockByArticuloId(int articuloId)
        {
            return _context.Stock
                .Include(s => s.Article)
                .FirstOrDefault(s => s.ArticleId == articuloId);
        }

        public bool Create(StockModel stock)
        {
            try
            {
                _context.Stock.Add(stock);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(StockModel stock)
        {
            try
            {
                var existingStock = _context.Stock.Find(stock.Id);
                if (existingStock == null)
                    return false;

                existingStock.ArticleId = stock.ArticleId;
                existingStock.Stock = stock.Stock;
                existingStock.Cost = stock.Cost;
                existingStock.Profit = stock.Profit;

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
                var stock = _context.Stock.Find(id);
                if (stock == null) return false;
                _context.Stock.Remove(stock);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AdjustStock(int articuloId, int cantidad)
        {
            try
            {
                var stock = GetStockByArticuloId(articuloId);
                if (stock == null)
                    return false;

                stock.Stock = (stock.Stock ?? 0) + cantidad;
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
