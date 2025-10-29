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

        public List<CategoriaModel> GetAllCategorias()
        {
            return _context.Categorias.ToList();
        }

        public CategoriaModel? GetCategoriaById(int id)
        {
            return _context.Categorias
                .Include(c => c.Subcategorias)
                .FirstOrDefault(c => c.IdCategoria == id);
        }

        public bool CreateCategoria(CategoriaModel categoria)
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

        public bool UpdateCategoria(CategoriaModel categoria)
        {
            try
            {
                var existingCategoria = _context.Categorias.Find(categoria.IdCategoria);
                if (existingCategoria == null)
                    return false;

                existingCategoria.Categoria = categoria.Categoria;

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
