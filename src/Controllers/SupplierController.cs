using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class SupplierController : IGenericController<SupplierModel>
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

        public List<SupplierModel> GetAll()
        {
            return _context.Supplier.ToList();
        }

        public SupplierModel? GetById(object id)
        {
            if (id is int intId) return GetProveedorById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetProveedorById(parsed);
            return null;
        }

        public SupplierModel? GetProveedorById(int id)
        {
            return _context.Supplier.FirstOrDefault(p => p.Id == id);
        }

        public bool Create(SupplierModel proveedor)
        {
            try
            {
                _context.Supplier.Add(proveedor);
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
                var proveedor = _context.Supplier.Find(intId);
                if (proveedor == null) return false;
                _context.Supplier.Remove(proveedor);
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
