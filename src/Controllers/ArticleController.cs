using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ArticleController : IGenericController<ArticleModel>
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

        public List<ArticleModel> GetAll()
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .ToList();
        }

        public ArticleModel? GetById(object id)
        {
            if (id is int intId) return GetArticuloById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetArticuloById(parsed);
            return null;
        }

        public ArticleModel? GetArticuloById(int id)
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

        public bool Create(ArticleModel articulo)
        {
            try
            {
                // Validar que el código de artículo no exista
                if (_context.Article.Any(a => a.Code == articulo.Code))
                    return false;

                _context.Article.Add(articulo);
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

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                if (!int.TryParse(id?.ToString(), out int intId)) return false;
                var articulo = _context.Article.Find(intId);
                if (articulo == null) return false;
                _context.Article.Remove(articulo);
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
