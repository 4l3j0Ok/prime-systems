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
    public class SellDetailService : IGenericController<SellDetailModel, int>
    {
        private readonly AppDbContext _context;

        public SellDetailService()
        {
            _context = new AppDbContext();
        }

        public SellDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SellDetailModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.SellDetail
                .AsNoTracking()
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .AsQueryable();

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<SellDetailModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.SellDetail
                .AsNoTracking()
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(d =>
                    (d.Article != null && d.Article.Name != null && d.Article.Name.ToLowerInvariant().Contains(searchLower)) ||
                    (d.Article != null && d.Article.Code.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<SellDetailModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.SellDetail
                .AsNoTracking()
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .FirstOrDefaultAsync(d => d.Id == id, ct);
        }

        public async Task<List<SellDetailModel>> GetDetallesByVentaAsync(int ventaId, CancellationToken ct = default)
        {
            return await _context.SellDetail
                .AsNoTracking()
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.SellId == ventaId)
                .ToListAsync(ct);
        }

        public async Task<List<SellDetailModel>> GetDetallesByArticuloAsync(int articuloId, CancellationToken ct = default)
        {
            return await _context.SellDetail
                .AsNoTracking()
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.ArticleId == articuloId)
                .ToListAsync(ct);
        }

        public async Task<bool> CreateAsync(SellDetailModel detalle, CancellationToken ct = default)
        {
            try
            {
                _context.SellDetail.Add(detalle);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(SellDetailModel detalle, CancellationToken ct = default)
        {
            try
            {
                var existingDetalle = await _context.SellDetail.FindAsync(new object[] { detalle.Id }, ct);
                if (existingDetalle == null)
                    return false;

                existingDetalle.SellId = detalle.SellId;
                existingDetalle.ArticleId = detalle.ArticleId;
                existingDetalle.Quantity = detalle.Quantity;

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
                var detalle = await _context.SellDetail.FindAsync(new object[] { id }, ct);
                if (detalle == null) return false;
                _context.SellDetail.Remove(detalle);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SellDetailModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<SellDetailModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public SellDetailModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(SellDetailModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(SellDetailModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}