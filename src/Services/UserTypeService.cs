using PrimeSystems.Core;
using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeSystems.Services
{
    public class UserTypeService : IGenericController<RoleModel, string>
    {
        private readonly AppDbContext _context;

        public UserTypeService()
        {
            _context = new AppDbContext();
        }

        public UserTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoleModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.UserType.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(r => r.Active);
            }

            query = query.OrderBy(r => r.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<RoleModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.UserType.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(r => r.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(r =>
                    (r.Title != null && r.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (r.Description != null && r.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(r => r.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<RoleModel?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            return await _context.UserType.FirstOrDefaultAsync(ut => ut.Id == id, ct);
        }

        public async Task<RoleModel?> GetByDescriptionAsync(string descripcion, CancellationToken ct = default)
        {
            return await _context.UserType.FirstOrDefaultAsync(ut => ut.Name == descripcion, ct);
        }

        public async Task<bool> CreateAsync(RoleModel usuarioTipo, CancellationToken ct = default)
        {
            try
            {
                if (await _context.UserType.AnyAsync(ut => ut.Id == usuarioTipo.Id, ct))
                    return false;

                usuarioTipo.Active = true;
                _context.UserType.Add(usuarioTipo);
                await _context.SaveChangesAsync(ct);

                usuarioTipo.Title = usuarioTipo.Name;
                usuarioTipo.Description = usuarioTipo.Id;
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(RoleModel role, CancellationToken ct = default)
        {
            try
            {
                var existingRole = await _context.UserType.FindAsync(new object[] { role.Id }, ct);
                if (existingRole == null)
                    return false;

                existingRole.Name = role.Name;
                existingRole.SellsPermission = role.SellsPermission;
                existingRole.PurchasesPermission = role.PurchasesPermission;
                existingRole.ArticlePermissions = role.ArticlePermissions;
                existingRole.ActivityLogPermission = role.ActivityLogPermission;
                existingRole.FinancialStatePermission = role.FinancialStatePermission;
                existingRole.UserPermission = role.UserPermission;
                existingRole.Active = role.Active;

                existingRole.Title = role.Name;
                existingRole.Description = role.Id;

                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            try
            {
                var usuarioTipo = await _context.UserType.FindAsync(new object[] { id }, ct);
                if (usuarioTipo == null) return false;

                usuarioTipo.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<RoleModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<RoleModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public RoleModel? GetById(string id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(RoleModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(RoleModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(string id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public RoleModel? GetByDescription(string descripcion)
            => GetByDescriptionAsync(descripcion).GetAwaiter().GetResult();
    }
}