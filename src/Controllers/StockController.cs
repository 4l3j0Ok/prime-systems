using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class StockController : IGenericController<StockModel, int>
    {
        private readonly AppDbContext _context;

        public StockController()
        {
            _context = new AppDbContext();
        }

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        public List<StockModel> GetAll()
        {
            return _context.Stock
                .Include(s => s.Article)
                .ToList();
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
