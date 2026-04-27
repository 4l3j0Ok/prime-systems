using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<List<StockModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Stock
                .AsNoTracking()
                .Include(s => s.Article)
                .AsQueryable();

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<StockModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Stock
                .AsNoTracking()
                .Include(s => s.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(s =>
                    (s.Article != null && s.Article.Name != null && s.Article.Name.ToLowerInvariant().Contains(searchLower)) ||
                    (s.Article != null && s.Article.Code.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<StockModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Stock
                .AsNoTracking()
                .Include(s => s.Article)
                .FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public async Task<StockModel?> GetStockByArticuloIdAsync(int articuloId, CancellationToken ct = default)
        {
            return await _context.Stock
                .AsNoTracking()
                .Include(s => s.Article)
                .FirstOrDefaultAsync(s => s.ArticleId == articuloId, ct);
        }

        public StockModel? GetStockByArticuloId(int articuloId)
            => GetStockByArticuloIdAsync(articuloId).GetAwaiter().GetResult();

        public async Task<bool> CreateAsync(StockModel stock, CancellationToken ct = default)
        {
            try
            {
                _context.Stock.Add(stock);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(StockModel stock, CancellationToken ct = default)
        {
            try
            {
                var existingStock = await _context.Stock.FindAsync(new object[] { stock.Id }, ct);
                if (existingStock == null)
                    return false;

                existingStock.ArticleId = stock.ArticleId;
                existingStock.Stock = stock.Stock;
                existingStock.Cost = stock.Cost;
                existingStock.Profit = stock.Profit;

                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var stock = await _context.Stock.FindAsync(new object[] { id }, ct);
                if (stock == null) return false;
                _context.Stock.Remove(stock);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AdjustStockAsync(int articuloId, int cantidad, CancellationToken ct = default)
        {
            try
            {
                var stock = await GetStockByArticuloIdAsync(articuloId, ct);
                if (stock == null)
                    return false;

                stock.Stock = (stock.Stock ?? 0) + cantidad;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AdjustStock(int articuloId, int cantidad)
            => AdjustStockAsync(articuloId, cantidad).GetAwaiter().GetResult();

        public List<StockModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<StockModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public StockModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(StockModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(StockModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}