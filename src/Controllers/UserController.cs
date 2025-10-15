using PrimeSystems.Data;
using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<UserModel> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Role)
                .Where(u => u.IsActive)
                .ToList();
        }

        public UserModel? GetUserByUsername(string username)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
        }

        public UserModel? GetUserById(int id)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == id);
        }

        public bool CreateUser(UserModel user)
        {
            try
            {
                // Validar que el username no exista
                if (_context.Users.Any(u => u.Username == user.Username))
                    return false;

                // Validar que el email no exista
                if (!string.IsNullOrEmpty(user.Email) && _context.Users.Any(u => u.Email == user.Email))
                    return false;

                // Limpiar la propiedad de navegación para evitar que Entity Framework intente insertar el Role
                user.Role = null;
                
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                var existingUser = _context.Users.Find(user.Id);
                if (existingUser == null)
                    return false;

                // Validar que el username no exista (excepto el usuario actual)
                if (_context.Users.Any(u => u.Username == user.Username && u.Id != user.Id))
                    return false;

                // Validar que el email no exista (excepto el usuario actual)
                if (!string.IsNullOrEmpty(user.Email) && _context.Users.Any(u => u.Email == user.Email && u.Id != user.Id))
                    return false;

                // Validar que el PersonId no exista (excepto el usuario actual)
                if (!string.IsNullOrEmpty(user.PersonId) && _context.Users.Any(u => u.PersonId == user.PersonId && u.Id != user.Id))
                    return false;

                // Actualizar propiedades
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.PersonId = user.PersonId;
                existingUser.ProfilePicture = user.ProfilePicture;
                existingUser.RoleId = user.RoleId;
                existingUser.IsActive = user.IsActive;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeactivateUser(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                    return false;

                user.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActivateUser(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                    return false;

                user.IsActive = true;
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
