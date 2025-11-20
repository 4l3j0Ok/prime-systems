using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ArticleController : IGenericController<ArticleModel, int>
    {
        private readonly AppDbContext _context;

        public ArticleController()
        {
            _context = new AppDbContext();
        }

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }

        public List<ArticleModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(a => a.Active);
            }

            query = query.OrderBy(a => a.Title);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<ArticleModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(a => a.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(a =>
                    (a.Title != null && a.Title.ToLower().Contains(searchTerm)) ||
                    (a.Description != null && a.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(a => a.Title);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public ArticleModel? GetById(int id)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Id == id);
        }

        public ArticleModel? GetArticuloByCodigo(string codigo)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Code == codigo);
        }

        public ArticleModel? GetByName(string name)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Name == name);
        }

        public bool Create(ArticleModel articulo)
        {
            try
            {
                // Validar que el código de artículo no exista
                if (_context.Article.Any(a => a.Code == articulo.Code))
                    return false;

                articulo.Active = true;
                _context.Article.Add(articulo);
                _context.SaveChanges();
                
                // Set Title and Description after saving
                articulo.Title = articulo.Name;
                articulo.Description = $"Código: {articulo.Code} | Categoría: {articulo.Category?.Name ?? "Sin categoría"}";
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(ArticleModel articulo)
        {
            try
            {
                var existingArticulo = _context.Article.Find(articulo.Id);
                if (existingArticulo == null)
                    return false;

                // Validar que el código no exista (excepto el artículo actual)
                if (_context.Article.Any(a => a.Code == articulo.Code && a.Id != articulo.Id))
                    return false;

                existingArticulo.Code = articulo.Code;
                existingArticulo.Name = articulo.Name;
                existingArticulo.Description = articulo.Description;
                existingArticulo.CategoryId = articulo.CategoryId;
                existingArticulo.SubcategoryId = articulo.SubcategoryId;
                existingArticulo.SupplierId = articulo.SupplierId;
                existingArticulo.Active = articulo.Active;
                
                // Update Title and Description
                existingArticulo.Title = articulo.Name;
                var category = _context.Category.Find(articulo.CategoryId);
                existingArticulo.Description = $"Código: {articulo.Code} | Categoría: {category?.Name ?? "Sin categoría"}";

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
                var articulo = _context.Article.Find(id);
                if (articulo == null) return false;
                
                // Baja lógica
                articulo.Active = false;
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
