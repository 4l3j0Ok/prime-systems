using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class SupplierController : IGenericController<SupplierModel, int>
    {
        private readonly AppDbContext _context;

        public SupplierController()
        {
            _context = new AppDbContext();
        }

        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        public List<SupplierModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Supplier.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(s => s.Active);
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<SupplierModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Supplier.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(s => s.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(s =>
                    (s.Title != null && s.Title.ToLower().Contains(searchTerm)) ||
                    (s.Description != null && s.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public SupplierModel? GetById(int id)
        {
            return _context.Supplier.FirstOrDefault(p => p.Id == id);
        }

        public bool Create(SupplierModel proveedor)
        {
            try
            {
                proveedor.Active = true;
                _context.Supplier.Add(proveedor);
                _context.SaveChanges();
                
                // Set Title and Description after saving
                proveedor.Title = proveedor.Name;
                proveedor.Description = $"CUIT: {proveedor.Cuit?.ToString() ?? "N/A"} | Contacto: {proveedor.ContactName ?? "N/A"}";
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(SupplierModel proveedor)
        {
            try
            {
                var existingProveedor = _context.Supplier.Find(proveedor.Id);
                if (existingProveedor == null)
                    return false;

                existingProveedor.Cuit = proveedor.Cuit;
                existingProveedor.Name = proveedor.Name;
                existingProveedor.ContactName = proveedor.ContactName;
                existingProveedor.Phone = proveedor.Phone;
                existingProveedor.Email = proveedor.Email;
                existingProveedor.Active = proveedor.Active;
                
                // Update Title and Description
                existingProveedor.Title = proveedor.Name;
                existingProveedor.Description = $"CUIT: {proveedor.Cuit?.ToString() ?? "N/A"} | Contacto: {proveedor.ContactName ?? "N/A"}";

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
                var proveedor = _context.Supplier.Find(id);
                if (proveedor == null) return false;
                
                // Baja lógica
                proveedor.Active = false;
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
