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
    public class CurrentAccountService : IGenericController<CurrentAccountModel, int>
    {
        private readonly AppDbContext _context;

        public CurrentAccountService()
        {
            _context = new AppDbContext();
        }

        public CurrentAccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentAccountModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.CurrentAccount
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            query = query.OrderBy(ca => ca.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<CurrentAccountModel>> GetByEntityTypeAsync(CurrentAccountType entityType, bool includeInactive = false, CancellationToken ct = default)
        {
            var query = _context.CurrentAccount
                .AsNoTracking()
                .Where(ca => ca.EntityType == entityType);

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            return await query.OrderBy(ca => ca.Id).ToListAsync(ct);
        }

        public async Task<CurrentAccountModel?> GetByEntityIdAsync(CurrentAccountType entityType, int entityId, CancellationToken ct = default)
        {
            return await _context.CurrentAccount
                .AsNoTracking()
                .FirstOrDefaultAsync(ca => ca.EntityType == entityType && ca.EntityId == entityId, ct);
        }

        public async Task<List<CurrentAccountModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.CurrentAccount
                .AsNoTracking()
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(ca =>
                    (ca.Title != null && ca.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (ca.Description != null && ca.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(ca => ca.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<CurrentAccountModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.CurrentAccount
                .AsNoTracking()
                .FirstOrDefaultAsync(ca => ca.Id == id, ct);
        }

        public async Task<bool> CreateAsync(CurrentAccountModel cuenta, CancellationToken ct = default)
        {
            try
            {
                var existing = await GetByEntityIdAsync(cuenta.EntityType, cuenta.EntityId, ct);
                if (existing != null)
                {
                    Debug.WriteLine("CurrentAccount already exists for this entity");
                    return false;
                }

                cuenta.Active = true;
                cuenta.CreatedAt = DateTime.Now;
                cuenta.Balance = 0;
                _context.CurrentAccount.Add(cuenta);
                await _context.SaveChangesAsync(ct);

                UpdateTitleAndDescription(cuenta);
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CurrentAccountModel cuenta, CancellationToken ct = default)
        {
            try
            {
                var existing = await _context.CurrentAccount.FindAsync(new object[] { cuenta.Id }, ct);
                if (existing == null)
                    return false;

                existing.Balance = cuenta.Balance;
                existing.Active = cuenta.Active;
                existing.UpdatedAt = DateTime.Now;

                UpdateTitleAndDescription(existing);
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
                var cuenta = await _context.CurrentAccount.FindAsync(new object[] { id }, ct);
                if (cuenta == null) return false;

                cuenta.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UpdateTitleAndDescription(CurrentAccountModel cuenta)
        {
            string entityName;
            string typeName;

            switch (cuenta.EntityType)
            {
                case CurrentAccountType.Client:
                    entityName = _context.Client.Find(cuenta.EntityId)?.Name ?? $"Cliente {cuenta.EntityId}";
                    typeName = "Cliente";
                    break;
                case CurrentAccountType.Supplier:
                    entityName = _context.Supplier.Find(cuenta.EntityId)?.Name ?? $"Proveedor {cuenta.EntityId}";
                    typeName = "Proveedor";
                    break;
                case CurrentAccountType.User:
                    entityName = _context.User.Find(cuenta.EntityId)?.Username ?? $"Usuario {cuenta.EntityId}";
                    typeName = "Usuario";
                    break;
                default:
                    entityName = $"Entidad {cuenta.EntityId}";
                    typeName = "Entidad";
                    break;
            }

            cuenta.Title = $"{typeName}: {entityName}";
            cuenta.Description = $"Saldo: ${cuenta.Balance:N2} | Creado: {cuenta.CreatedAt:g}";
        }

        public async Task<bool> AddMovementAsync(
            int cuentaId, 
            MovementType type, 
            decimal amount, 
            string? reference = null, 
            string? description = null, 
            int? userId = null, 
            int? relatedSellId = null, 
            int? relatedPurchaseId = null,
            CancellationToken ct = default)
        {
            try
            {
                var cuenta = await _context.CurrentAccount.FindAsync(new object[] { cuentaId }, ct);
                if (cuenta == null) return false;

                var movement = new CurrentAccountMovementModel
                {
                    CurrentAccountId = cuentaId,
                    Type = type,
                    Amount = amount,
                    Reference = reference,
                    Description = description,
                    Date = DateTime.Now,
                    UserId = userId ?? Session.CurrentUser?.Id,
                    RelatedSellId = relatedSellId,
                    RelatedPurchaseId = relatedPurchaseId,
                    BalanceBefore = cuenta.Balance,
                    BalanceAfter = cuenta.Balance
                };

                switch (type)
                {
                    case MovementType.Credit:
                    case MovementType.Payment:
                        movement.BalanceAfter = cuenta.Balance + amount;
                        cuenta.Balance += amount;
                        break;
                    case MovementType.Debit:
                    case MovementType.Charge:
                        movement.BalanceAfter = cuenta.Balance - amount;
                        cuenta.Balance -= amount;
                        break;
                }

                cuenta.UpdatedAt = DateTime.Now;
                _context.CurrentAccountMovement.Add(movement);
                await _context.SaveChangesAsync(ct);

                UpdateTitleAndDescription(cuenta);
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<CurrentAccountMovementModel>> GetMovementsAsync(int cuentaId, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .AsNoTracking()
                .Where(m => m.CurrentAccountId == cuentaId)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return await orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).Include(m => m.User).ToListAsync(ct);
            }

            return await orderedQuery.Include(m => m.User).ToListAsync(ct);
        }

        public List<CurrentAccountModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<CurrentAccountModel> GetByEntityType(CurrentAccountType entityType, bool includeInactive = false)
            => GetByEntityTypeAsync(entityType, includeInactive).GetAwaiter().GetResult();

        public CurrentAccountModel? GetByEntityId(CurrentAccountType entityType, int entityId)
            => GetByEntityIdAsync(entityType, entityId).GetAwaiter().GetResult();

        public List<CurrentAccountModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public CurrentAccountModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(CurrentAccountModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(CurrentAccountModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public bool AddMovement(int cuentaId, MovementType type, decimal amount, string? reference = null, string? description = null, int? userId = null, int? relatedSellId = null, int? relatedPurchaseId = null)
            => AddMovementAsync(cuentaId, type, amount, reference, description, userId, relatedSellId, relatedPurchaseId).GetAwaiter().GetResult();

        public List<CurrentAccountMovementModel> GetMovements(int cuentaId, int? pageNumber = null, int? pageSize = null)
            => GetMovementsAsync(cuentaId, pageNumber, pageSize).GetAwaiter().GetResult();
    }
}