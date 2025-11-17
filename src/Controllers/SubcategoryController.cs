using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class SubcategoryController : IGenericController<SubcategoryModel, int>
    {
        private readonly AppDbContext _context;

        public SubcategoryController()
        {
            _context = new AppDbContext();
        }

        public SubcategoryController(AppDbContext context)
        {
            _context = context;
        }

        public List<SubcategoryModel> GetAll()
        {
            return _context.Subcategory
                .Include(s => s.Category)
                .ToList();
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
