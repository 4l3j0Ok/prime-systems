using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ClienteController
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

        public List<ClientModel> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public ClientModel? GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public bool CreateCliente(ClientModel cliente)
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

        public bool UpdateCliente(ClientModel cliente)
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

        public bool DeleteCliente(int id)
        {
            try
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente == null)
                    return false;

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
