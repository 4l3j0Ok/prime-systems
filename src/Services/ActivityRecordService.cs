using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Services
{
    public class ActivityRecordService : IGenericController<ActivityRecordModel, int>
    {
        private readonly AppDbContext _context;

        public ActivityRecordService()
        {
            _context = new AppDbContext();
        }

        public ActivityRecordService(AppDbContext context)
        {
            _context = context;
        }

        public List<ActivityRecordModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .AsQueryable();

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<ActivityRecordModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(t =>
                    (t.Module != null && t.Module.ToLower().Contains(searchTerm)) ||
                    (t.Action != null && t.Action.ToLower().Contains(searchTerm)) ||
                    (t.User != null && t.User.Username.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderByDescending(t => t.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<ActivityRecordModel> GetPaged(int pageNumber, int pageSize)
        {
            return GetAll(false, pageNumber, pageSize);
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

        public List<ActivityRecordModel> GetRecordByModulesAndDateRange(List<string> modules, DateTime dateFrom, DateTime dateTo)
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
                .Where(t => modules.Contains(t.Module ?? string.Empty)
                    && t.Date.HasValue
                    && t.Date.Value.Date >= dateFrom.Date
                    && t.Date.Value.Date <= dateTo.Date)
                .ToList();
        }

        public List<ActivityRecordModel> GetRecordByModulesAndDateRangePaged(List<string> modules, DateTime dateFrom, DateTime dateTo, int pageNumber, int pageSize)
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
                .Where(t => modules.Contains(t.Module ?? string.Empty)
                    && t.Date.HasValue
                    && t.Date.Value.Date >= dateFrom.Date
                    && t.Date.Value.Date <= dateTo.Date)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetTotalCountByModulesAndDateRange(List<string> modules, DateTime dateFrom, DateTime dateTo)
        {
            return _context.Transaction
                .Where(t => modules.Contains(t.Module ?? string.Empty)
                    && t.Date.HasValue
                    && t.Date.Value.Date >= dateFrom.Date
                    && t.Date.Value.Date <= dateTo.Date)
                .Count();
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