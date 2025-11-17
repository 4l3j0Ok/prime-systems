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

        public List<ClientModel> GetAll()
        {
            return _context.Client.ToList();
        }

        public ClientModel? GetById(int id)
        {
            return _context.Client.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(ClientModel cliente)
        {
            try
            {
                _context.Client.Add(cliente);
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
                _context.Client.Remove(cliente);
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
