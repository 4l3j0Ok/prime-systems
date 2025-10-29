using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ArticuloController
    {
        private readonly AppDbContext _context;

        public ArticuloController()
        {
            _context = new AppDbContext();
        }

        public ArticuloController(AppDbContext context)
        {
            _context = context;
        }

        public List<ArticleModel> GetAllArticulos()
        {
            return _context.Articulos
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .ToList();
        }

        public ArticleModel? GetArticuloById(int id)
        {
            return _context.Articulos
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Id == id);
        }

        public ArticleModel? GetArticuloByCodigo(string codigo)
        {
            return _context.Articulos
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Code == codigo);
        }

        public bool CreateArticulo(ArticleModel articulo)
        {
            try
            {
                // Validar que el código de artículo no exista
                if (_context.Articulos.Any(a => a.Code == articulo.Code))
                    return false;

                _context.Articulos.Add(articulo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateArticulo(ArticleModel articulo)
        {
            try
            {
                var existingArticulo = _context.Articulos.Find(articulo.Id);
                if (existingArticulo == null)
                    return false;

                // Validar que el código no exista (excepto el artículo actual)
                if (_context.Articulos.Any(a => a.Code == articulo.Code && a.Id != articulo.Id))
                    return false;

                existingArticulo.Code = articulo.Code;
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

        public bool DeleteArticulo(int id)
        {
            try
            {
                var articulo = _context.Articulos.Find(id);
                if (articulo == null)
                    return false;

                _context.Articulos.Remove(articulo);
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
