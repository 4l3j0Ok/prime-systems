using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class ActivityRecordController : IGenericController<ActivityRecordModel, int>
    {
        private readonly AppDbContext _context;

        public ActivityRecordController()
        {
            _context = new AppDbContext();
        }

        public ActivityRecordController(AppDbContext context)
        {
            _context = context;
        }

        public List<ActivityRecordModel> GetAll()
        {
            return _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .ToList();
        }

        public ActivityRecordModel? GetById(int id)
        {
            return _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<ActivityRecordModel> GetMovimientosByUsuario(int usuarioId)
        {
            return _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => t.UserId == usuarioId)
                .ToList();
        }

        public List<ActivityRecordModel> GetRecordByModules(List<string> modules)
        {
            return _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                    .ThenInclude(s => s.Client)
                .Include(t => t.Purchase)
                    .ThenInclude(p => p.Supplier)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => modules.Contains(t.Module ?? string.Empty))
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public List<ActivityRecordModel> GetMovimientosByFecha(DateTime fecha)
        {
            return _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => t.Date.HasValue && t.Date.Value.Date == fecha.Date)
                .ToList();
        }

        public bool Create(ActivityRecordModel movimiento)
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

        public bool Update(ActivityRecordModel movimiento)
        {
            try
            {
                var existingMovimiento = _context.Transaction.Find(movimiento.Id);
                if (existingMovimiento == null)
                    return false;

                existingMovimiento.UserId = movimiento.UserId;
                existingMovimiento.Module = movimiento.Module;
                existingMovimiento.Date = movimiento.Date;

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
                var movimiento = _context.Transaction.Find(id);
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