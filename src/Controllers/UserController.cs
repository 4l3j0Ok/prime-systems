using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class UserController
    {
        private readonly AppDbContext _context;

        public UserController()
        {
            _context = new AppDbContext();
        }

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public List<UsuarioModel> GetAllUsers()
        {
            return _context.Usuarios
                .Include(u => u.UsuarioTipo)
                .ToList();
        }

        public UsuarioModel? GetUserByUsername(string username)
        {
            return _context.Usuarios
                .Include(u => u.UsuarioTipo)
                .FirstOrDefault(u => u.NombreUsuario == username);
        }

        public UsuarioModel? GetUserById(int id)
        {
            return _context.Usuarios
                .Include(u => u.UsuarioTipo)
                .FirstOrDefault(u => u.IdUsuario == id);
        }

        public bool CreateUser(UsuarioModel user)
        {
            try
            {
                // Validar que el username no exista
                if (_context.Usuarios.Any(u => u.NombreUsuario == user.NombreUsuario))
                    return false;

                // Validar que el email no exista
                if (!string.IsNullOrEmpty(user.Mail) && _context.Usuarios.Any(u => u.Mail == user.Mail))
                    return false;

                // Validar que el DNI no exista
                if (user.Dni.HasValue && _context.Usuarios.Any(u => u.Dni == user.Dni))
                    return false;
                
                _context.Usuarios.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateUser(UsuarioModel user)
        {
            try
            {
                var existingUser = _context.Usuarios.Find(user.IdUsuario);
                if (existingUser == null)
                    return false;

                // Validar que el username no exista (excepto el usuario actual)
                if (_context.Usuarios.Any(u => u.NombreUsuario == user.NombreUsuario && u.IdUsuario != user.IdUsuario))
                    return false;

                // Validar que el email no exista (excepto el usuario actual)
                if (!string.IsNullOrEmpty(user.Mail) && _context.Usuarios.Any(u => u.Mail == user.Mail && u.IdUsuario != user.IdUsuario))
                    return false;

                // Validar que el DNI no exista (excepto el usuario actual)
                if (user.Dni.HasValue && _context.Usuarios.Any(u => u.Dni == user.Dni && u.IdUsuario != user.IdUsuario))
                    return false;

                // Actualizar propiedades
                existingUser.NombreUsuario = user.NombreUsuario;
                existingUser.Contrasena = user.Contrasena;
                existingUser.Nombre = user.Nombre;
                existingUser.Apellido = user.Apellido;
                existingUser.Mail = user.Mail;
                existingUser.Tel = user.Tel;
                existingUser.Dni = user.Dni;
                existingUser.PCompra = user.PCompra;
                existingUser.PVenta = user.PVenta;
                existingUser.PRrhh = user.PRrhh;
                existingUser.PContable = user.PContable;
                existingUser.UsuarioTipoId = user.UsuarioTipoId;

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
