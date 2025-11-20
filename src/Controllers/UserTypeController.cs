using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeSystems.Controllers
{
    public class UserTypeController : IGenericController<RoleModel, string>
    {
        private readonly AppDbContext _context;

        public UserTypeController()
        {
            _context = new AppDbContext();
        }

        public UserTypeController(AppDbContext context)
        {
            _context = context;
        }

        public List<RoleModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
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

            return query.ToList();
        }

        public List<RoleModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.UserType.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(r => r.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(r =>
                    (r.Title != null && r.Title.ToLower().Contains(searchTerm)) ||
                    (r.Description != null && r.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(r => r.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public RoleModel? GetById(string id)
        {
            return _context.UserType.FirstOrDefault(ut => ut.Id == id);
        }

        public RoleModel? GetByDescription(string descripcion)
        {
            return _context.UserType.FirstOrDefault(ut => ut.Name == descripcion);
        }

        public bool Create(RoleModel usuarioTipo)
        {
            try
            {
                // Validar que el ID no exista
                if (_context.UserType.Any(ut => ut.Id == usuarioTipo.Id))
                    return false;

                usuarioTipo.Active = true;
                _context.UserType.Add(usuarioTipo);
                _context.SaveChanges();

                // Set Title and Description after saving
                usuarioTipo.Title = usuarioTipo.Name;
                usuarioTipo.Description = usuarioTipo.Id;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(RoleModel role)
        {
            try
            {
                var existingRole = _context.UserType.Find(role.Id);
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

                // Update Title and Description
                existingRole.Title = role.Name;
                existingRole.Description = role.Id;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var usuarioTipo = _context.UserType.Find(id);
                if (usuarioTipo == null) return false;

                // Baja lógica
                usuarioTipo.Active = false;
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
