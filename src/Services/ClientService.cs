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
    public class ClientService : IGenericController<ClientModel, int>
    {
        private readonly AppDbContext _context;

        public ClientService()
        {
            _context = new AppDbContext();
        }

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Client
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(c => c.Active);
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<ClientModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Client
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(c => c.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(c =>
                    (c.Title != null && c.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (c.Description != null && c.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<ClientModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<bool> CreateAsync(ClientModel cliente, CancellationToken ct = default)
        {
            try
            {
                cliente.Active = true;
                _context.Client.Add(cliente);
                await _context.SaveChangesAsync(ct);

                cliente.Title = cliente.Name;
                cliente.Description = $"CUIT: {cliente.Cuit?.ToString() ?? "N/A"} | Entidad: {cliente.Entity ?? "N/A"}";
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ClientModel cliente, CancellationToken ct = default)
        {
            try
            {
                var existingCliente = await _context.Client.FindAsync(new object[] { cliente.Id }, ct);
                if (existingCliente == null)
                    return false;

                existingCliente.Cuit = cliente.Cuit;
                existingCliente.Name = cliente.Name;
                existingCliente.Entity = cliente.Entity;
                existingCliente.Phone = cliente.Phone;
                existingCliente.Email = cliente.Email;
                existingCliente.Active = cliente.Active;

                existingCliente.Title = cliente.Name;
                existingCliente.Description = $"CUIT: {cliente.Cuit?.ToString() ?? "N/A"} | Entidad: {cliente.Entity ?? "N/A"}";

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
                var cliente = await _context.Client.FindAsync(new object[] { id }, ct);
                if (cliente == null) return false;

                cliente.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ClientModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<ClientModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public ClientModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(ClientModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(ClientModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();
    }
}