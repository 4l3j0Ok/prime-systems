using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ClientController : IGenericController<ClientModel, int>
    {
        private readonly AppDbContext _context;

        public ClientController()
        {
            _context = new AppDbContext();
        }

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        public List<ClientModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Client.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(c => c.Active);
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<ClientModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Client.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(c => c.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(c =>
                    (c.Title != null && c.Title.ToLower().Contains(searchTerm)) ||
                    (c.Description != null && c.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public ClientModel? GetById(int id)
        {
            return _context.Client.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(ClientModel cliente)
        {
            try
            {
                cliente.Active = true;
                _context.Client.Add(cliente);
                _context.SaveChanges();
                
                // Set Title and Description after saving
                cliente.Title = cliente.Name;
                cliente.Description = $"CUIT: {cliente.Cuit?.ToString() ?? "N/A"} | Entidad: {cliente.Entity ?? "N/A"}";
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(ClientModel cliente)
        {
            try
            {
                var existingCliente = _context.Client.Find(cliente.Id);
                if (existingCliente == null)
                    return false;

                existingCliente.Cuit = cliente.Cuit;
                existingCliente.Name = cliente.Name;
                existingCliente.Entity = cliente.Entity;
                existingCliente.Phone = cliente.Phone;
                existingCliente.Email = cliente.Email;
                existingCliente.Active = cliente.Active;
                
                // Update Title and Description
                existingCliente.Title = cliente.Name;
                existingCliente.Description = $"CUIT: {cliente.Cuit?.ToString() ?? "N/A"} | Entidad: {cliente.Entity ?? "N/A"}";

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
                var cliente = _context.Client.Find(id);
                if (cliente == null) return false;
                
                // Baja lógica
                cliente.Active = false;
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
