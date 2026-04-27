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

        public async Task<List<ActivityRecordModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Transaction
                .AsNoTracking()
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

            return await query.ToListAsync(ct);
        }

        public async Task<List<ActivityRecordModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Transaction
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(t =>
                    (t.Module != null && t.Module.ToLowerInvariant().Contains(searchLower)) ||
                    (t.Action != null && t.Action.ToLowerInvariant().Contains(searchLower)) ||
                    (t.User != null && t.User.Username.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderByDescending(t => t.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<ActivityRecordModel>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            return await GetAllAsync(false, pageNumber, pageSize, ct);
        }

        public async Task<ActivityRecordModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<List<ActivityRecordModel>> GetMovimientosByUsuarioAsync(int usuarioId, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => t.UserId == usuarioId)
                .ToListAsync(ct);
        }

        public async Task<List<ActivityRecordModel>> GetRecordByModulesAsync(List<string> modules, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Sell)
                    .ThenInclude(s => s.Client)
                .Include(t => t.Purchase)
                    .ThenInclude(p => p.Supplier)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => modules.Contains(t.Module ?? string.Empty))
                .ToListAsync(ct);
        }

        public async Task<List<ActivityRecordModel>> GetMovimientosByFechaAsync(DateTime fecha, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Sell)
                .Include(t => t.Purchase)
                .Include(t => t.Article)
                .Include(t => t.Client)
                .Include(t => t.Supplier)
                .Where(t => t.Date.HasValue && t.Date.Value.Date == fecha.Date)
                .ToListAsync(ct);
        }

        public async Task<List<ActivityRecordModel>> GetRecordByModulesAndDateRangeAsync(List<string> modules, DateTime dateFrom, DateTime dateTo, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
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
                .ToListAsync(ct);
        }

        public async Task<(List<ActivityRecordModel> Items, bool HasMore, int TotalCount, int TotalSells, int TotalPurchases, decimal TotalRevenue, decimal TotalExpenses)> 
            GetRecordByModulesAndDateRangePagedWithTotalsAsync(
                List<string> modules, 
                DateTime dateFrom, 
                DateTime dateTo, 
                int pageNumber, 
                int pageSize,
                CancellationToken ct = default)
        {
            var query = _context.Transaction
                .AsNoTracking()
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
                    && t.Date.Value.Date <= dateTo.Date);

            var totalCount = await query.CountAsync(ct);
            
            var items = await query
                .OrderByDescending(t => t.Date)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            int totalSells = 0;
            int totalPurchases = 0;
            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var record in items)
            {
                if (record.Module == ActivityModules.Sells && record.Sell != null)
                {
                    totalSells++;
                    if (decimal.TryParse(record.Sell.Total, out decimal sellAmount))
                    {
                        totalRevenue += sellAmount;
                    }
                }
                else if (record.Module == ActivityModules.Purchases && record.Purchase != null)
                {
                    totalPurchases++;
                    if (decimal.TryParse(record.Purchase.Total, out decimal purchaseAmount))
                    {
                        totalExpenses += purchaseAmount;
                    }
                }
            }

            bool hasMore = items.Count >= pageSize;

            return (items, hasMore, totalCount, totalSells, totalPurchases, totalRevenue, totalExpenses);
        }

        public async Task<List<ActivityRecordModel>> GetRecordByModulesAndDateRangePagedAsync(List<string> modules, DateTime dateFrom, DateTime dateTo, int pageNumber, int pageSize, CancellationToken ct = default)
        {
            return await _context.Transaction
                .AsNoTracking()
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
                .OrderByDescending(t => t.Date)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<int> GetTotalCountByModulesAndDateRangeAsync(List<string> modules, DateTime dateFrom, DateTime dateTo, CancellationToken ct = default)
        {
            return await _context.Transaction
                .Where(t => modules.Contains(t.Module ?? string.Empty)
                    && t.Date.HasValue
                    && t.Date.Value.Date >= dateFrom.Date
                    && t.Date.Value.Date <= dateTo.Date)
                .CountAsync(ct);
        }

        public async Task<bool> CreateAsync(ActivityRecordModel movimiento, CancellationToken ct = default)
        {
            try
            {
                _context.Transaction.Add(movimiento);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ActivityRecordModel movimiento, CancellationToken ct = default)
        {
            try
            {
                var existingMovimiento = await _context.Transaction.FindAsync(new object[] { movimiento.Id }, ct);
                if (existingMovimiento == null)
                    return false;

                existingMovimiento.UserId = movimiento.UserId;
                existingMovimiento.Module = movimiento.Module;
                existingMovimiento.Date = movimiento.Date;

                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var movimiento = await _context.Transaction.FindAsync(new object[] { id }, ct);
                if (movimiento == null) return false;
                _context.Transaction.Remove(movimiento);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ActivityRecordModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<ActivityRecordModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public ActivityRecordModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(ActivityRecordModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(ActivityRecordModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetPaged(int pageNumber, int pageSize)
            => GetPagedAsync(pageNumber, pageSize).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetMovimientosByUsuario(int usuarioId)
            => GetMovimientosByUsuarioAsync(usuarioId).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetRecordByModules(List<string> modules)
            => GetRecordByModulesAsync(modules).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetMovimientosByFecha(DateTime fecha)
            => GetMovimientosByFechaAsync(fecha).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetRecordByModulesAndDateRange(List<string> modules, DateTime dateFrom, DateTime dateTo)
            => GetRecordByModulesAndDateRangeAsync(modules, dateFrom, dateTo).GetAwaiter().GetResult();

        public List<ActivityRecordModel> GetRecordByModulesAndDateRangePaged(List<string> modules, DateTime dateFrom, DateTime dateTo, int pageNumber, int pageSize)
            => GetRecordByModulesAndDateRangePagedAsync(modules, dateFrom, dateTo, pageNumber, pageSize).GetAwaiter().GetResult();

        public int GetTotalCountByModulesAndDateRange(List<string> modules, DateTime dateFrom, DateTime dateTo)
            => GetTotalCountByModulesAndDateRangeAsync(modules, dateFrom, dateTo).GetAwaiter().GetResult();
    }
}