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

        public List<ClienteModel> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public ClienteModel? GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public bool CreateCliente(ClienteModel cliente)
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

        public bool UpdateCliente(ClienteModel cliente)
        {
            try
            {
                var existingCliente = _context.Clientes.Find(cliente.IdCliente);
                if (existingCliente == null)
                    return false;

                existingCliente.Cuit = cliente.Cuit;
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Entidad = cliente.Entidad;
                existingCliente.Tel = cliente.Tel;
                existingCliente.Mail = cliente.Mail;

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
