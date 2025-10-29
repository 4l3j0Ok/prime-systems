using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ProveedorController
    {
        private readonly AppDbContext _context;

        public ProveedorController()
        {
            _context = new AppDbContext();
        }

        public ProveedorController(AppDbContext context)
        {
            _context = context;
        }

        public List<SupplierModel> GetAllProveedores()
        {
            return _context.Proveedores.ToList();
        }

        public SupplierModel? GetProveedorById(int id)
        {
            return _context.Proveedores.FirstOrDefault(p => p.Id == id);
        }

        public bool CreateProveedor(SupplierModel proveedor)
        {
            try
            {
                _context.Proveedores.Add(proveedor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateProveedor(SupplierModel proveedor)
        {
            try
            {
                var existingProveedor = _context.Proveedores.Find(proveedor.Id);
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

        public bool DeleteProveedor(int id)
        {
            try
            {
                var proveedor = _context.Proveedores.Find(id);
                if (proveedor == null)
                    return false;

                _context.Proveedores.Remove(proveedor);
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
