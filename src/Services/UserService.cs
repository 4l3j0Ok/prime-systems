using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        public async Task<List<UserModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.User
                .AsNoTracking()
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

            return await query.ToListAsync(ct);
        }

        public async Task<List<UserModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.User
                .AsNoTracking()
                .Include(u => u.Role)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(u => u.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(u =>
                    (u.Title != null && u.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (u.Description != null && u.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(u => u.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<UserModel?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            return await _context.User
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username, ct);
        }

        public async Task<UserModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.User
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task<bool> CreateAsync(UserModel user, CancellationToken ct = default)
        {
            try
            {
                if (await _context.User.AnyAsync(u => u.Username == user.Username, ct))
                    return false;
                if (!string.IsNullOrEmpty(user.Email) && await _context.User.AnyAsync(u => u.Email == user.Email, ct))
                    return false;
                if (user.PersonId.HasValue && await _context.User.AnyAsync(u => u.PersonId == user.PersonId, ct))
                    return false;

                user.Active = true;
                _context.User.Add(user);
                await _context.SaveChangesAsync(ct);
                
                user.Title = user.Username;
                user.Description = $"{user.Name} {user.LastName} - {user.Role?.Name ?? "Sin rol"}";
                await _context.SaveChangesAsync(ct);
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UserModel user, CancellationToken ct = default)
        {
            try
            {
                var existingUser = await _context.User.FindAsync(new object[] { user.Id }, ct);
                if (existingUser == null)
                    return false;
                if (await _context.User.AnyAsync(u => u.Username == user.Username && u.Id != user.Id, ct))
                    return false;
                if (!string.IsNullOrEmpty(user.Email) && await _context.User.AnyAsync(u => u.Email == user.Email && u.Id != user.Id, ct))
                    return false;
                if (user.PersonId.HasValue && await _context.User.AnyAsync(u => u.PersonId == user.PersonId && u.Id != user.Id, ct))
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
                
                existingUser.Title = user.Username;
                existingUser.Description = $"{user.Name} {user.LastName} - {user.Role?.Name ?? "Sin rol"}";
                
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var user = await _context.User.FindAsync(new object[] { id }, ct);
                if (user == null) return false;
                
                user.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UserModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<UserModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public UserModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(UserModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(UserModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public UserModel? GetByUsername(string username)
            => GetByUsernameAsync(username).GetAwaiter().GetResult();
    }
}