using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
 public class TransactionController : IGenericController<TransactionModel>
    {
        private readonly AppDbContext _context;

        public TransactionController()
        {
   _context = new AppDbContext();
}

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        public List<TransactionModel> GetAll()
        {
          return _context.Transaction
           .Include(t => t.User)
       .ToList();
        }

        public TransactionModel? GetById(object id)
        {
        if (id is int intId) return GetMovimientoById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetMovimientoById(parsed);
            return null;
        }

        public TransactionModel? GetMovimientoById(int id)
        {
 return _context.Transaction
    .Include(t => t.User)
             .FirstOrDefault(t => t.Id == id);
        }

        public List<TransactionModel> GetMovimientosByUsuario(int usuarioId)
        {
            return _context.Transaction
    .Include(t => t.User)
      .Where(t => t.UserId == usuarioId)
         .ToList();
        }

        public List<TransactionModel> GetMovimientosByTipo(int tipo)
        {
   return _context.Transaction
    .Include(t => t.User)
      .Where(t => t.Type == tipo)
      .ToList();
        }

      public List<TransactionModel> GetMovimientosByFecha(DateTime fecha)
        {
return _context.Transaction
   .Include(t => t.User)
            .Where(t => t.Date.HasValue && t.Date.Value.Date == fecha.Date)
    .ToList();
        }

        public bool Create(TransactionModel movimiento)
        {
  try
            {
    _context.Transaction.Add(movimiento);
  _context.SaveChanges();
        return true;
    }
 catch (Exception ex)
    {
       Debug.WriteLine(ex);
            return false;
       }
        }

        public bool Update(TransactionModel movimiento)
        {
            try
            {
     var existingMovimiento = _context.Transaction.Find(movimiento.Id);
   if (existingMovimiento == null)
        return false;

     existingMovimiento.UserId = movimiento.UserId;
     existingMovimiento.Type = movimiento.Type;
                existingMovimiento.Date = movimiento.Date;

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
 var movimiento = _context.Transaction.Find(intId);
 if (movimiento == null) return false;
                _context.Transaction.Remove(movimiento);
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