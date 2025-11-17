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

        public List<RoleModel> GetAll()
        {
            return _context.UserType.ToList();
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

                _context.UserType.Add(usuarioTipo);
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
                existingRole.FinancialStatePermission = role.FinancialStatePermission;
                existingRole.UserPermission = role.UserPermission;

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
                _context.UserType.Remove(usuarioTipo);
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
