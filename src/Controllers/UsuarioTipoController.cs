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

        public List<UserTypeModel> GetAll()
        {
            return _context.UsuariosTipo.ToList();
        }

        public UserTypeModel? GetById(string id)
        {
            return _context.UsuariosTipo.FirstOrDefault(ut => ut.Id == id);
        }

        public UserTypeModel? GetByDescription(string descripcion)
        {
            return _context.UsuariosTipo.FirstOrDefault(ut => ut.Description == descripcion);
        }

        public bool Create(UserTypeModel usuarioTipo)
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

        public bool UpdateUsuarioTipo(UserTypeModel usuarioTipo)
        {
            try
            {
                var existingUsuarioTipo = _context.UsuariosTipo.Find(usuarioTipo.Id);
                if (existingUsuarioTipo == null)
                    return false;

                existingUsuarioTipo.Description = usuarioTipo.Description;
                existingUsuarioTipo.Read = usuarioTipo.Read;
                existingUsuarioTipo.Write = usuarioTipo.Write;

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
