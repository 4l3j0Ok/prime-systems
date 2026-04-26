using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class CurrentAccountMovementController
    {
        private readonly AppDbContext _context;

        public CurrentAccountMovementController()
        {
            _context = new AppDbContext();
        }

        public CurrentAccountMovementController(AppDbContext context)
        {
            _context = context;
        }

        public List<CurrentAccountMovementModel> GetByCurrentAccountId(int currentAccountId, int? pageNumber = null, int? pageSize = null)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .Where(m => m.CurrentAccountId == currentAccountId)
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToList();
            }

            return orderedQuery.ToList();
        }

        public List<CurrentAccountMovementModel> GetByReference(string reference, int? pageNumber = null, int? pageSize = null)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .Where(m => m.Reference != null && m.Reference.Contains(reference))
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToList();
            }

            return orderedQuery.ToList();
        }

        public CurrentAccountMovementModel? GetById(int id)
        {
            return _context.CurrentAccountMovement
                .Include(m => m.User)
                .Include(m => m.RelatedSell)
                .Include(m => m.RelatedPurchase)
                .FirstOrDefault(m => m.Id == id);
        }

        public bool Create(CurrentAccountMovementModel movement)
        {
            try
            {
                _context.CurrentAccountMovement.Add(movement);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var movement = _context.CurrentAccountMovement.Find(id);
                if (movement == null) return false;

                _context.CurrentAccountMovement.Remove(movement);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CurrentAccountMovementModel> GetByDateRange(DateTime dateFrom, DateTime dateTo, int? pageNumber = null, int? pageSize = null)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .Where(m => m.Date >= dateFrom && m.Date <= dateTo)
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToList();
            }

            return orderedQuery.ToList();
        }
    }
}