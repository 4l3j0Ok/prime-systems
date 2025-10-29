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

        public List<ArticuloModel> GetAllArticulos()
        {
            return _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Subcategoria)
                .Include(a => a.Proveedor)
                .ToList();
        }

        public ArticuloModel? GetArticuloById(int id)
        {
            return _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Subcategoria)
                .Include(a => a.Proveedor)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.IdArticulo == id);
        }

        public ArticuloModel? GetArticuloByCodigo(string codigo)
        {
            return _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Subcategoria)
                .Include(a => a.Proveedor)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.CodArticulo == codigo);
        }

        public bool CreateArticulo(ArticuloModel articulo)
        {
            try
            {
                // Validar que el código de artículo no exista
                if (_context.Articulos.Any(a => a.CodArticulo == articulo.CodArticulo))
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

        public bool UpdateArticulo(ArticuloModel articulo)
        {
            try
            {
                var existingArticulo = _context.Articulos.Find(articulo.IdArticulo);
                if (existingArticulo == null)
                    return false;

                // Validar que el código no exista (excepto el artículo actual)
                if (_context.Articulos.Any(a => a.CodArticulo == articulo.CodArticulo && a.IdArticulo != articulo.IdArticulo))
                    return false;

                existingArticulo.CodArticulo = articulo.CodArticulo;
                existingArticulo.ArtDesc = articulo.ArtDesc;
                existingArticulo.CodCategoria = articulo.CodCategoria;
                existingArticulo.CodSubcat = articulo.CodSubcat;
                existingArticulo.IdProveedor = articulo.IdProveedor;

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
