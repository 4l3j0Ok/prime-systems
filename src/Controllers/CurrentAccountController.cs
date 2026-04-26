using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class CurrentAccountController : IGenericController<CurrentAccountModel, int>
    {
        private readonly AppDbContext _context;

        public CurrentAccountController()
        {
            _context = new AppDbContext();
        }

        public CurrentAccountController(AppDbContext context)
        {
            _context = context;
        }

        public List<CurrentAccountModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.CurrentAccount.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            query = query.OrderBy(ca => ca.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<CurrentAccountModel> GetByEntityType(CurrentAccountType entityType, bool includeInactive = false)
        {
            var query = _context.CurrentAccount.Where(ca => ca.EntityType == entityType);

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            return query.OrderBy(ca => ca.Id).ToList();
        }

        public CurrentAccountModel? GetByEntityId(CurrentAccountType entityType, int entityId)
        {
            return _context.CurrentAccount
                .FirstOrDefault(ca => ca.EntityType == entityType && ca.EntityId == entityId);
        }

        public List<CurrentAccountModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.CurrentAccount.AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(ca => ca.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(ca =>
                    (ca.Title != null && ca.Title.ToLower().Contains(searchTerm)) ||
                    (ca.Description != null && ca.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(ca => ca.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public CurrentAccountModel? GetById(int id)
        {
            return _context.CurrentAccount.FirstOrDefault(ca => ca.Id == id);
        }

        public bool Create(CurrentAccountModel cuenta)
        {
            try
            {
                var existing = GetByEntityId(cuenta.EntityType, cuenta.EntityId);
                if (existing != null)
                {
                    Debug.WriteLine("CurrentAccount already exists for this entity");
                    return false;
                }

                cuenta.Active = true;
                cuenta.CreatedAt = DateTime.Now;
                cuenta.Balance = 0;
                _context.CurrentAccount.Add(cuenta);
                _context.SaveChanges();

                UpdateTitleAndDescription(cuenta);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(CurrentAccountModel cuenta)
        {
            try
            {
                var existing = _context.CurrentAccount.Find(cuenta.Id);
                if (existing == null)
                    return false;

                existing.Balance = cuenta.Balance;
                existing.Active = cuenta.Active;
                existing.UpdatedAt = DateTime.Now;

                UpdateTitleAndDescription(existing);
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
                var cuenta = _context.CurrentAccount.Find(id);
                if (cuenta == null) return false;

                cuenta.Active = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UpdateTitleAndDescription(CurrentAccountModel cuenta)
        {
            var entityName = cuenta.EntityType switch
            {
                CurrentAccountType.Client => _context.Client.Find(cuenta.EntityId)?.Name ?? $"Cliente {cuenta.EntityId}",
                CurrentAccountType.Supplier => _context.Supplier.Find(cuenta.EntityId)?.Name ?? $"Proveedor {cuenta.EntityId}",
                CurrentAccountType.User => _context.User.Find(cuenta.EntityId)?.Username ?? $"Usuario {cuenta.EntityId}",
                _ => $"Entidad {cuenta.EntityId}"
            };

            var typeName = cuenta.EntityType switch
            {
                CurrentAccountType.Client => "Cliente",
                CurrentAccountType.Supplier => "Proveedor",
                CurrentAccountType.User => "Usuario",
                _ => "Entidad"
            };

            cuenta.Title = $"{typeName}: {entityName}";
            cuenta.Description = $"Saldo: ${cuenta.Balance:N2} | Creado: {cuenta.CreatedAt:g}";
        }

        public bool AddMovement(int cuentaId, MovementType type, decimal amount, string? reference = null, string? description = null, int? userId = null, int? relatedSellId = null, int? relatedPurchaseId = null)
        {
            try
            {
                var cuenta = _context.CurrentAccount.Find(cuentaId);
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
                _context.SaveChanges();

                UpdateTitleAndDescription(cuenta);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public List<CurrentAccountMovementModel> GetMovements(int cuentaId, int? pageNumber = null, int? pageSize = null)
        {
            var orderedQuery = _context.CurrentAccountMovement
                .Where(m => m.CurrentAccountId == cuentaId)
                .OrderByDescending(m => m.Date);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return orderedQuery.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value).Include(m => m.User).ToList();
            }

            return orderedQuery.Include(m => m.User).ToList();
        }
    }
}