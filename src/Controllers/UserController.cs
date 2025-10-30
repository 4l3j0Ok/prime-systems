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
    public class UserController : IGenericController<UserModel>
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

        public List<UserModel> GetAll()
        {
            return _context.Usuarios
                .Include(u => u.UserType)
                .ToList();
        }

        public UserModel? GetByUsername(string username)
        {
            return _context.Usuarios
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Username == username);
        }

        public UserModel? GetById(int id)
        {
            return _context.Usuarios
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Id == id);
        }

        // Interface implementation that accepts object id
        public UserModel? GetById(object id)
        {
            if (id is int intId)
                return GetById(intId);
            if (int.TryParse(id?.ToString(), out int parsed))
                return GetById(parsed);
            return null;
        }

        public bool Create(UserModel user)
        {
            try
            {
                // Validar que el username no exista
                if (_context.Usuarios.Any(u => u.Username == user.Username))
                    return false;

                // Validar que el email no exista
                if (!string.IsNullOrEmpty(user.Email) && _context.Usuarios.Any(u => u.Email == user.Email))
                    return false;

                // Validar que el DNI no exista
                if (user.PersonId.HasValue && _context.Usuarios.Any(u => u.PersonId == user.PersonId))
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

        public bool Update(UserModel user)
        {
            try
            {
                var existingUser = _context.Usuarios.Find(user.Id);
                if (existingUser == null)
                    return false;

                // Validar que el username no exista (excepto el usuario actual)
                if (_context.Usuarios.Any(u => u.Username == user.Username && u.Id != user.Id))
                    return false;

                // Validar que el email no exista (excepto el usuario actual)
                if (!string.IsNullOrEmpty(user.Email) && _context.Usuarios.Any(u => u.Email == user.Email && u.Id != user.Id))
                    return false;

                // Validar que el DNI no exista (excepto el usuario actual)
                if (user.PersonId.HasValue && _context.Usuarios.Any(u => u.PersonId == user.PersonId && u.Id != user.Id))
                    return false;

                // Actualizar propiedades
                existingUser.Username = user.Username;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.PersonId = user.PersonId;
                existingUser.UserTypeId = user.UserTypeId;

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
                var user = _context.Usuarios.Find(intId);
                if (user == null) return false;
                _context.Usuarios.Remove(user);
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
