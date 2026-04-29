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

        public async Task<List<PurchaseDetailModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.PurchaseDetail
                .AsNoTracking()
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .AsQueryable();

            query = query.OrderBy(d => d.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<PurchaseDetailModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.PurchaseDetail
                .AsNoTracking()
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(d =>
                    (d.Description != null && d.Description.ToLowerInvariant().Contains(searchLower)) ||
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

        public async Task<PurchaseDetailModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.PurchaseDetail
                .AsNoTracking()
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .FirstOrDefaultAsync(d => d.Id == id, ct);
        }

        public async Task<List<PurchaseDetailModel>> GetDetallesByCompraAsync(int compraId, CancellationToken ct = default)
        {
            return await _context.PurchaseDetail
                .AsNoTracking()
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .Where(d => d.PurchaseId == compraId)
                .ToListAsync(ct);
        }

        public List<PurchaseDetailModel> GetDetallesByCompra(int compraId)
            => GetDetallesByCompraAsync(compraId).GetAwaiter().GetResult();

        public async Task<List<PurchaseDetailModel>> GetDetallesByArticuloAsync(int articuloId, CancellationToken ct = default)
        {
            return await _context.PurchaseDetail
                .AsNoTracking()
                .Include(d => d.Purchase)
                .Include(d => d.Article)
                .Where(d => d.ArticleId == articuloId)
                .ToListAsync(ct);
        }

        public List<PurchaseDetailModel> GetDetallesByArticulo(int articuloId)
            => GetDetallesByArticuloAsync(articuloId).GetAwaiter().GetResult();

        public async Task<bool> CreateAsync(PurchaseDetailModel detalle, CancellationToken ct = default)
        {
            try
            {
                _context.PurchaseDetail.Add(detalle);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PurchaseDetailModel detalle, CancellationToken ct = default)
        {
            try
            {
                var existingDetalle = await _context.PurchaseDetail.FindAsync(new object[] { detalle.Id }, ct);
                if (existingDetalle == null)
                    return false;

                existingDetalle.PurchaseId = detalle.PurchaseId;
                existingDetalle.ArticleId = detalle.ArticleId;
                existingDetalle.Description = detalle.Description;
                existingDetalle.UnitPrice = detalle.UnitPrice;
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
                var detalle = await _context.PurchaseDetail.FindAsync(new object[] { id }, ct);
                if (detalle == null) return false;
                _context.PurchaseDetail.Remove(detalle);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PurchaseDetailModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<PurchaseDetailModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public PurchaseDetailModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(PurchaseDetailModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(PurchaseDetailModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}