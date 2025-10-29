using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class CategoriaController
    {
        private readonly AppDbContext _context;

        public CategoriaController()
        {
            _context = new AppDbContext();
        }

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryModel> GetAllCategorias()
        {
            return _context.Categorias.ToList();
        }

        public CategoryModel? GetCategoriaById(int id)
        {
            return _context.Categorias
                .Include(c => c.Subcategory)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool CreateCategoria(CategoryModel categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateCategoria(CategoryModel categoria)
        {
            try
            {
                var existingCategoria = _context.Categorias.Find(categoria.Id);
                if (existingCategoria == null)
                    return false;

                existingCategoria.Name = categoria.Name;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategoria(int id)
        {
            try
            {
                var categoria = _context.Categorias.Find(id);
                if (categoria == null)
                    return false;

                _context.Categorias.Remove(categoria);
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
