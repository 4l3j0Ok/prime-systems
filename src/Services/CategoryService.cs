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
    public class CategoryService : IGenericController<CategoryModel, int>
    {
        private readonly AppDbContext _context;

        public CategoryService()
        {
            _context = new AppDbContext();
        }

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Category
                .AsNoTracking()
                .AsQueryable();

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<CategoryModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Category
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(c =>
                    c.Name != null && c.Name.ToLowerInvariant().Contains(searchLower)
                );
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<CategoryModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Category
                .AsNoTracking()
                .Include(c => c.Subcategory)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<bool> CreateAsync(CategoryModel category, CancellationToken ct = default)
        {
            try
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CategoryModel category, CancellationToken ct = default)
        {
            try
            {
                var existingCategoria = await _context.Category.FindAsync(new object[] { category.Id }, ct);
                if (existingCategoria == null)
                    return false;

                existingCategoria.Name = category.Name;

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
                var category = await _context.Category.FindAsync(new object[] { id }, ct);
                if (category == null) return false;
                _context.Category.Remove(category);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CategoryModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<CategoryModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public CategoryModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(CategoryModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(CategoryModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}