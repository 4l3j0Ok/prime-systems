using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeSystems.Controllers
{
    public class UsuarioTipoController
    {
        private readonly AppDbContext _context;

        public UsuarioTipoController()
        {
            _context = new AppDbContext();
        }

        public UsuarioTipoController(AppDbContext context)
        {
            _context = context;
        }

        public List<UsuarioTipoModel> GetAllUsuariosTipo()
        {
            return _context.UsuariosTipo.ToList();
        }

        public UsuarioTipoModel? GetUsuarioTipoById(string id)
        {
            return _context.UsuariosTipo.FirstOrDefault(ut => ut.Id == id);
        }

        public UsuarioTipoModel? GetUsuarioTipoByDescripcion(string descripcion)
        {
            return _context.UsuariosTipo.FirstOrDefault(ut => ut.Descripcion == descripcion);
        }

        public bool CreateUsuarioTipo(UsuarioTipoModel usuarioTipo)
        {
            try
            {
                // Validar que el ID no exista
                if (_context.UsuariosTipo.Any(ut => ut.Id == usuarioTipo.Id))
                    return false;

                _context.UsuariosTipo.Add(usuarioTipo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateUsuarioTipo(UsuarioTipoModel usuarioTipo)
        {
            try
            {
                var existingUsuarioTipo = _context.UsuariosTipo.Find(usuarioTipo.Id);
                if (existingUsuarioTipo == null)
                    return false;

                existingUsuarioTipo.Descripcion = usuarioTipo.Descripcion;
                existingUsuarioTipo.Escritura = usuarioTipo.Escritura;
                existingUsuarioTipo.Lectura = usuarioTipo.Lectura;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUsuarioTipo(string id)
        {
            try
            {
                var usuarioTipo = _context.UsuariosTipo.Find(id);
                if (usuarioTipo == null)
                    return false;

                _context.UsuariosTipo.Remove(usuarioTipo);
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
