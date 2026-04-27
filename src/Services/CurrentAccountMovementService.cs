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
    public class CurrentAccountMovementService
    {
        private readonly AppDbContext _context;

        public CurrentAccountMovementService()
        {
            _context = new AppDbContext();
        }

        public CurrentAccountMovementService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentAccountMovementModel>> GetByCurrentAccountIdAsync(int currentAccountId, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .AsNoTracking()
                .Where(m => m.CurrentAccountId == currentAccountId)
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return await orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToListAsync(ct);
            }

            return await orderedQuery.ToListAsync(ct);
        }

        public async Task<List<CurrentAccountMovementModel>> GetByReferenceAsync(string reference, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .AsNoTracking()
                .Where(m => m.Reference != null && m.Reference.Contains(reference))
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return await orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToListAsync(ct);
            }

            return await orderedQuery.ToListAsync(ct);
        }

        public async Task<CurrentAccountMovementModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.CurrentAccountMovement
                .AsNoTracking()
                .Include(m => m.User)
                .Include(m => m.RelatedSell)
                .Include(m => m.RelatedPurchase)
                .FirstOrDefaultAsync(m => m.Id == id, ct);
        }

        public async Task<bool> CreateAsync(CurrentAccountMovementModel movement, CancellationToken ct = default)
        {
            try
            {
                _context.CurrentAccountMovement.Add(movement);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var movement = await _context.CurrentAccountMovement.FindAsync(new object[] { id }, ct);
                if (movement == null) return false;

                _context.CurrentAccountMovement.Remove(movement);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CurrentAccountMovementModel>> GetByDateRangeAsync(DateTime dateFrom, DateTime dateTo, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .AsNoTracking()
                .Where(m => m.Date >= dateFrom && m.Date <= dateTo)
                .Include(m => m.User)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return await orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).ToListAsync(ct);
            }

            return await orderedQuery.ToListAsync(ct);
        }

        public List<CurrentAccountMovementModel> GetByCurrentAccountId(int currentAccountId, int? pageNumber = null, int? pageSize = null)
            => GetByCurrentAccountIdAsync(currentAccountId, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<CurrentAccountMovementModel> GetByReference(string reference, int? pageNumber = null, int? pageSize = null)
            => GetByReferenceAsync(reference, pageNumber, pageSize).GetAwaiter().GetResult();

        public CurrentAccountMovementModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(CurrentAccountMovementModel movement)
            => CreateAsync(movement).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public List<CurrentAccountMovementModel> GetByDateRange(DateTime dateFrom, DateTime dateTo, int? pageNumber = null, int? pageSize = null)
            => GetByDateRangeAsync(dateFrom, dateTo, pageNumber, pageSize).GetAwaiter().GetResult();
    }
}