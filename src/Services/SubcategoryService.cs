using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public List<SubcategoryModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Subcategory
                .Include(s => s.Category)
                .AsQueryable();

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<SubcategoryModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Subcategory
                .Include(s => s.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(s =>
                    (s.Name != null && s.Name.ToLower().Contains(searchTerm)) ||
                    (s.Category != null && s.Category.Name != null && s.Category.Name.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public SubcategoryModel? GetById(int id)
        {
            return _context.Subcategory
                .Include(s => s.Category)
                .Include(s => s.Articles)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<SubcategoryModel> GetSubcategoriesByCategoria(int categoryId)
        {
            return _context.Subcategory
                .Include(s => s.Category)
                .Where(s => s.CategoryId == categoryId)
                .ToList();
        }

        public bool Create(SubcategoryModel subcategory)
        {
            try
            {
                _context.Subcategory.Add(subcategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(SubcategoryModel subcategory)
        {
            try
            {
                var existingSubcategory = _context.Subcategory.Find(subcategory.Id);
                if (existingSubcategory == null)
                    return false;

                existingSubcategory.Name = subcategory.Name;
                existingSubcategory.CategoryId = subcategory.CategoryId;

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
                var subcategory = _context.Subcategory.Find(id);
                if (subcategory == null) return false;
                _context.Subcategory.Remove(subcategory);
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
