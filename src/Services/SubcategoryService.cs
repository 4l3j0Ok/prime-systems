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
    public class SubcategoryService : IGenericController<SubcategoryModel, int>
    {
        private readonly AppDbContext _context;

        public SubcategoryService()
        {
            _context = new AppDbContext();
        }

        public SubcategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubcategoryModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Subcategory
                .AsNoTracking()
                .Include(s => s.Category)
                .AsQueryable();

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<SubcategoryModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Subcategory
                .AsNoTracking()
                .Include(s => s.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(s =>
                    (s.Name != null && s.Name.ToLowerInvariant().Contains(searchLower)) ||
                    (s.Category != null && s.Category.Name != null && s.Category.Name.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<SubcategoryModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Subcategory
                .AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.Articles)
                .FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public async Task<List<SubcategoryModel>> GetSubcategoriesByCategoriaAsync(int categoryId, CancellationToken ct = default)
        {
            return await _context.Subcategory
                .AsNoTracking()
                .Include(s => s.Category)
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync(ct);
        }

        public List<SubcategoryModel> GetSubcategoriesByCategoria(int categoryId)
            => GetSubcategoriesByCategoriaAsync(categoryId).GetAwaiter().GetResult();

        public async Task<bool> CreateAsync(SubcategoryModel subcategory, CancellationToken ct = default)
        {
            try
            {
                _context.Subcategory.Add(subcategory);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(SubcategoryModel subcategory, CancellationToken ct = default)
        {
            try
            {
                var existingSubcategory = await _context.Subcategory.FindAsync(new object[] { subcategory.Id }, ct);
                if (existingSubcategory == null)
                    return false;

                existingSubcategory.Name = subcategory.Name;
                existingSubcategory.CategoryId = subcategory.CategoryId;

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
                var subcategory = await _context.Subcategory.FindAsync(new object[] { id }, ct);
                if (subcategory == null) return false;
                _context.Subcategory.Remove(subcategory);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SubcategoryModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<SubcategoryModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public SubcategoryModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(SubcategoryModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(SubcategoryModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}