using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystems.Core;

namespace PrimeSystems.Services
{
    public class UserService : IGenericController<UserModel, int>
    {
        private readonly AppDbContext _context;

        public UserService()
        {
            _context = new AppDbContext();
        }

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.User
                .Include(u => u.Role)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(u => u.Active);
            }

            query = query.OrderBy(u => u.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<UserModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.User
                .Include(u => u.Role)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(u => u.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    (u.Title != null && u.Title.ToLower().Contains(searchTerm)) ||
                    (u.Description != null && u.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(u => u.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public UserModel? GetByUsername(string username)
        {
            return _context.User
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
        }

        public UserModel? GetById(int id)
        {
            return _context.User
                .Include(u => u.Role)
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
                if (_context.User.Any(u => u.Username == user.Username))
                    return false;
                if (!string.IsNullOrEmpty(user.Email) && _context.User.Any(u => u.Email == user.Email))
                    return false;
                if (user.PersonId.HasValue && _context.User.Any(u => u.PersonId == user.PersonId))
                    return false;

                user.Active = true;
                _context.User.Add(user);
                _context.SaveChanges();
                
                // Set Title and Description after saving
                user.Title = user.Username;
                user.Description = $"{user.Name} {user.LastName} - {user.Role?.Name ?? "Sin rol"}";
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
                var existingUser = _context.User.Find(user.Id);
                if (existingUser == null)
                    return false;
                if (_context.User.Any(u => u.Username == user.Username && u.Id != user.Id))
                    return false;
                if (!string.IsNullOrEmpty(user.Email) && _context.User.Any(u => u.Email == user.Email && u.Id != user.Id))
                    return false;
                if (user.PersonId.HasValue && _context.User.Any(u => u.PersonId == user.PersonId && u.Id != user.Id))
                    return false;
                    
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.PersonId = user.PersonId;
                existingUser.ProfilePicture = user.ProfilePicture;
                existingUser.RoleId = user.RoleId;
                existingUser.Active = user.Active;
                
                // Update Title and Description
                existingUser.Title = user.Username;
                existingUser.Description = $"{user.Name} {user.LastName} - {user.Role?.Name ?? "Sin rol"}";
                
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = _context.User.Find(id);
                if (user == null) return false;
                
                // Baja lógica
                user.Active = false;
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
