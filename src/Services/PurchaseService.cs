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
    public class PurchaseService : IGenericController<PurchaseModel, int>
    {
        private readonly AppDbContext _context;
        private readonly StockService _stockService;

        public PurchaseService()
        {
            _context = new AppDbContext();
            _stockService = new StockService(_context);
        }

        public PurchaseService(AppDbContext context)
        {
            _context = context;
            _stockService = new StockService(context);
        }

        public async Task<List<PurchaseModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Purchase
                .AsNoTracking()
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<PurchaseModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Purchase
                .AsNoTracking()
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(c =>
                    (c.Title != null && c.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (c.Description != null && c.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<PurchaseModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Purchase
                .AsNoTracking()
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<bool> CreateAsync(PurchaseModel compra, CancellationToken ct = default)
        {
            try
            {
                _context.Purchase.Add(compra);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PurchaseModel compra, CancellationToken ct = default)
        {
            try
            {
                var existing = await _context.Purchase.FindAsync(new object[] { compra.Id }, ct);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

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
                var entity = await _context.Purchase.FindAsync(new object[] { id }, ct);
                if (entity == null) return false;
                _context.Purchase.Remove(entity);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateCompraConDetallesAsync(PurchaseModel compra, List<PurchaseDetailModel> detalles, CancellationToken ct = default)
        {
            try
            {
                _context.Purchase.Add(compra);
                await _context.SaveChangesAsync(ct);

                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);
                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = await _stockService.AdjustStockAsync(detalle.ArticleId.Value, quantity, ct);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateCompraConDetallesAsync(PurchaseModel compra, List<PurchaseDetailModel> detalles, CancellationToken ct = default)
        {
            try
            {
                var existing = await _context.Purchase.FindAsync(new object[] { compra.Id }, ct);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

                var oldDetails = await _context.PurchaseDetail.Where(d => d.PurchaseId == compra.Id).ToListAsync(ct);

                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && int.TryParse(oldDetail.Quantity, out int quantity))
                    {
                        await _stockService.AdjustStockAsync(oldDetail.ArticleId.Value, -quantity, ct);
                    }
                }

                _context.PurchaseDetail.RemoveRange(oldDetails);

                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);

                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = await _stockService.AdjustStockAsync(detalle.ArticleId.Value, quantity, ct);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }

                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<PurchaseModel>> GetComprasByProveedorAsync(int proveedorId, CancellationToken ct = default)
        {
            return await _context.Purchase
                .AsNoTracking()
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.SupplierId == proveedorId)
                .ToListAsync(ct);
        }

        public async Task<List<PurchaseModel>> GetComprasByUsuarioAsync(int usuarioId, CancellationToken ct = default)
        {
            return await _context.Purchase
                .AsNoTracking()
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.UserId == usuarioId)
                .ToListAsync(ct);
        }

        public async Task<List<SupplierModel>> GetAllSuppliersAsync(CancellationToken ct = default)
        {
            var supplierService = new SupplierService(_context);
            return await supplierService.GetAllAsync(ct: ct);
        }

        public async Task<SupplierModel?> GetSupplierByNameAsync(string name, CancellationToken ct = default)
        {
            var allSuppliers = await GetAllSuppliersAsync(ct);
            return allSuppliers.FirstOrDefault(s => s.Name == name);
        }

        public async Task<ArticleModel?> GetArticleByIdAsync(int id, CancellationToken ct = default)
        {
            var articleService = new ArticleService(_context);
            return await articleService.GetByIdAsync(id, ct);
        }

        public decimal CalculateTotal(List<(decimal UnitPrice, int Quantity)> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.UnitPrice * item.Quantity;
            }
            return total;
        }

        public async Task<PurchaseValidationResult> ValidatePurchaseAsync(
            int? supplierId,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> items,
            decimal total,
            CancellationToken ct = default)
        {
            var errors = new List<string>();

            if (!supplierId.HasValue)
            {
                errors.Add("Debe seleccionar un proveedor");
            }

            if (items.Count == 0)
            {
                errors.Add("Debe agregar al menos un artículo");
            }

            foreach (var item in items)
            {
                if (!item.ArticleId.HasValue)
                {
                    errors.Add("Todos los artículos deben estar seleccionados");
                    break;
                }

                if (string.IsNullOrWhiteSpace(item.UnitPrice) || !decimal.TryParse(item.UnitPrice, out decimal price) || price <= 0)
                {
                    errors.Add("Todos los artículos deben tener un precio unitario válido mayor a 0");
                    break;
                }

                if (string.IsNullOrWhiteSpace(item.Quantity) || !int.TryParse(item.Quantity, out int qty) || qty <= 0)
                {
                    errors.Add("Todos los artículos deben tener una cantidad válida mayor a 0");
                    break;
                }
            }

            if (total <= 0)
            {
                errors.Add("El total debe ser mayor a 0");
            }

            return new PurchaseValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }

        public List<PurchaseDetailModel> CreatePurchaseDetails(List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> items)
        {
            return items.Select(item => new PurchaseDetailModel
            {
                ArticleId = item.ArticleId,
                Description = item.Description,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity
            }).ToList();
        }

        public async Task<PurchaseSaveResult> SavePurchaseAsync(
            int supplierId,
            decimal total,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> details,
            bool isEditMode,
            PurchaseModel? existingPurchase,
            CancellationToken ct = default)
        {
            var result = new PurchaseSaveResult { Success = false };

            var supplier = await GetSupplierByNameAsync(GetAllSuppliersAsync(ct).Result.FirstOrDefault(s => s.Id == supplierId)?.Name ?? "", ct);
            if (supplier == null)
            {
                result.ErrorMessage = "Proveedor no válido";
                return result;
            }

            var purchase = isEditMode && existingPurchase != null
                ? existingPurchase
                : new PurchaseModel();

            purchase.UserId = Session.CurrentUser?.Id;
            purchase.SupplierId = supplierId;
            purchase.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            purchase.Subtotal = total.ToString("F2");
            purchase.Discount = "0.00";
            purchase.Total = total.ToString("F2");

            var purchaseDetails = CreatePurchaseDetails(details);

            bool success;
            if (isEditMode && existingPurchase != null)
            {
                purchase.Title = $"Compra #{purchase.Id}";
                purchase.Description = $"Proveedor: {supplier.Name} | Total: ${purchase.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                success = await UpdateCompraConDetallesAsync(purchase, purchaseDetails, ct);
            }
            else
            {
                success = await CreateCompraConDetallesAsync(purchase, purchaseDetails, ct);
                if (success)
                {
                    purchase.Title = $"Compra #{purchase.Id}";
                    purchase.Description = $"Proveedor: {supplier.Name} | Total: ${purchase.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                    await UpdateAsync(purchase, ct);
                }
            }

            result.Success = success;
            result.PurchaseId = purchase.Id;
            result.SupplierId = supplierId;
            result.ErrorMessage = success ? null : "Error al guardar la compra";

            return result;
        }

        public List<PurchaseModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<PurchaseModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public PurchaseModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(PurchaseModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(PurchaseModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public List<SupplierModel> GetAllSuppliers()
            => GetAllSuppliersAsync().GetAwaiter().GetResult();

        public SupplierModel? GetSupplierByName(string name)
            => GetSupplierByNameAsync(name).GetAwaiter().GetResult();

        public ArticleModel? GetArticleById(int id)
            => GetArticleByIdAsync(id).GetAwaiter().GetResult();

        public PurchaseValidationResult ValidatePurchase(
            int? supplierId,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> items,
            decimal total)
            => ValidatePurchaseAsync(supplierId, items, total).GetAwaiter().GetResult();

        public PurchaseSaveResult SavePurchase(
            int supplierId,
            decimal total,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> details,
            bool isEditMode,
            PurchaseModel? existingPurchase)
            => SavePurchaseAsync(supplierId, total, details, isEditMode, existingPurchase).GetAwaiter().GetResult();
    }

    public class PurchaseValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class PurchaseSaveResult
    {
        public bool Success { get; set; }
        public int PurchaseId { get; set; }
        public int SupplierId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}