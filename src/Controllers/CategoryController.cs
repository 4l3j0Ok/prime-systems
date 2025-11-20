using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class CategoryController : IGenericController<CategoryModel, int>
    {
        private readonly AppDbContext _context;

        public CategoryController()
        {
            _context = new AppDbContext();
        }

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Category.AsQueryable();

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<CategoryModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Category.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(c =>
                    c.Name != null && c.Name.ToLower().Contains(searchTerm)
                );
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public CategoryModel? GetById(int id)
        {
            return _context.Category
                .Include(c => c.Subcategory)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool Create(CategoryModel category)
        {
            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
        public bool Update(CategoryModel category)
        {
            try
            {
                var existingCategoria = _context.Category.Find(category.Id);
                if (existingCategoria == null)
                    return false;

                existingCategoria.Name = category.Name;

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
                var category = _context.Category.Find(id);
                if (category == null) return false;
                _context.Category.Remove(category);
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
