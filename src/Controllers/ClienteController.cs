using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ClienteController : IGenericController<ClientModel>
    {
        private readonly AppDbContext _context;

        public ClienteController()
        {
            _context = new AppDbContext();
        }

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        public List<ClientModel> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public ClientModel? GetById(object id)
        {
            if (id is int intId) return GetClienteById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetClienteById(parsed);
            return null;
        }

        public ClientModel? GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(ClientModel cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
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
                var existingCliente = _context.Clientes.Find(cliente.Id);
                if (existingCliente == null)
                    return false;

                existingCliente.Cuit = cliente.Cuit;
                existingCliente.Name = cliente.Name;
                existingCliente.Entity = cliente.Entity;
                existingCliente.Phone = cliente.Phone;
                existingCliente.Email = cliente.Email;

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
                var cliente = _context.Clientes.Find(intId);
                if (cliente == null) return false;
                _context.Clientes.Remove(cliente);
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
