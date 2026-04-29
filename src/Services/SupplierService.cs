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
    public class SupplierService : IGenericController<SupplierModel, int>
    {
        private readonly AppDbContext _context;

        public SupplierService()
        {
            _context = new AppDbContext();
        }

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Supplier
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(s => s.Active);
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<SupplierModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Supplier
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(s => s.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(s =>
                    (s.Title != null && s.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (s.Description != null && s.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(s => s.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<SupplierModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Supplier
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task<bool> CreateAsync(SupplierModel proveedor, CancellationToken ct = default)
        {
            try
            {
                proveedor.Active = true;
                _context.Supplier.Add(proveedor);
                await _context.SaveChangesAsync(ct);
                
                proveedor.Title = proveedor.Name;
                proveedor.Description = $"CUIT: {proveedor.Cuit?.ToString() ?? "N/A"} | Contacto: {proveedor.ContactName ?? "N/A"}";
                await _context.SaveChangesAsync(ct);
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(SupplierModel proveedor, CancellationToken ct = default)
        {
            try
            {
                var existingProveedor = await _context.Supplier.FindAsync(new object[] { proveedor.Id }, ct);
                if (existingProveedor == null)
                    return false;

                existingProveedor.Cuit = proveedor.Cuit;
                existingProveedor.Name = proveedor.Name;
                existingProveedor.ContactName = proveedor.ContactName;
                existingProveedor.Phone = proveedor.Phone;
                existingProveedor.Email = proveedor.Email;
                existingProveedor.Active = proveedor.Active;
                
                existingProveedor.Title = proveedor.Name;
                existingProveedor.Description = $"CUIT: {proveedor.Cuit?.ToString() ?? "N/A"} | Contacto: {proveedor.ContactName ?? "N/A"}";

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
                var proveedor = await _context.Supplier.FindAsync(new object[] { id }, ct);
                if (proveedor == null) return false;
                
                proveedor.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SupplierModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<SupplierModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public SupplierModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(SupplierModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(SupplierModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}