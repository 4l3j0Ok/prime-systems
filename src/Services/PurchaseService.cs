using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public List<PurchaseModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<PurchaseModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(c =>
                    (c.Title != null && c.Title.ToLower().Contains(searchTerm)) ||
                    (c.Description != null && c.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderByDescending(c => c.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public PurchaseModel? GetById(int id)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Include(c => c.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool Create(PurchaseModel compra)
        {
            try
            {
                _context.Purchase.Add(compra);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(PurchaseModel compra)
        {
            try
            {
                var existing = _context.Purchase.Find(compra.Id);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

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
                var entity = _context.Purchase.Find(id);
                if (entity == null) return false;
                _context.Purchase.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                _context.Purchase.Add(compra);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);
                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = _stockService.AdjustStock(detalle.ArticleId.Value, quantity);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateCompraConDetalles(PurchaseModel compra, List<PurchaseDetailModel> detalles)
        {
            try
            {
                var existing = _context.Purchase.Find(compra.Id);
                if (existing == null) return false;

                existing.UserId = compra.UserId;
                existing.SupplierId = compra.SupplierId;
                existing.Date = compra.Date;
                existing.Subtotal = compra.Subtotal;
                existing.Discount = compra.Discount;
                existing.Total = compra.Total;
                existing.Title = compra.Title;
                existing.Description = compra.Description;

                var oldDetails = _context.PurchaseDetail.Where(d => d.PurchaseId == compra.Id).ToList();

                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && int.TryParse(oldDetail.Quantity, out int quantity))
                    {
                        _stockService.AdjustStock(oldDetail.ArticleId.Value, -quantity);
                    }
                }

                // Eliminar los detalles anteriores
                _context.PurchaseDetail.RemoveRange(oldDetails);

                // Agregar los nuevos detalles y aumentar el stock
                foreach (var detalle in detalles)
                {
                    detalle.PurchaseId = compra.Id;
                    _context.PurchaseDetail.Add(detalle);

                    // Aumentar el stock si el detalle tiene un artículo asociado
                    if (detalle.ArticleId.HasValue && int.TryParse(detalle.Quantity, out int quantity))
                    {
                        bool stockAdjusted = _stockService.AdjustStock(detalle.ArticleId.Value, quantity);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el artículo {detalle.ArticleId.Value}");
                        }
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public List<PurchaseModel> GetComprasByProveedor(int proveedorId)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.SupplierId == proveedorId)
                .ToList();
        }

        public List<PurchaseModel> GetComprasByUsuario(int usuarioId)
        {
            return _context.Purchase
                .Include(c => c.User)
                .Include(c => c.Supplier)
                .Where(c => c.UserId == usuarioId)
                .ToList();
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            var supplierService = new SupplierService(_context);
            return supplierService.GetAll();
        }

        public SupplierModel? GetSupplierByName(string name)
        {
            var supplierService = new SupplierService(_context);
            return supplierService.GetAll().FirstOrDefault(s => s.Name == name);
        }

        public ArticleModel? GetArticleById(int id)
        {
            var articleService = new ArticleService(_context);
            return articleService.GetById(id);
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

        public PurchaseValidationResult ValidatePurchase(
            int? supplierId,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> items,
            decimal total)
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

        public PurchaseSaveResult SavePurchase(
            int supplierId,
            decimal total,
            List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> details,
            bool isEditMode,
            PurchaseModel? existingPurchase)
        {
            var result = new PurchaseSaveResult { Success = false };

            var supplier = GetSupplierByName(GetAllSuppliers().FirstOrDefault(s => s.Id == supplierId)?.Name ?? "");
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
                success = UpdateCompraConDetalles(purchase, purchaseDetails);
            }
            else
            {
                success = CreateCompraConDetalles(purchase, purchaseDetails);
                if (success)
                {
                    purchase.Title = $"Compra #{purchase.Id}";
                    purchase.Description = $"Proveedor: {supplier.Name} | Total: ${purchase.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                    Update(purchase);
                }
            }

            result.Success = success;
            result.PurchaseId = purchase.Id;
            result.SupplierId = supplierId;
            result.ErrorMessage = success ? null : "Error al guardar la compra";

            return result;
        }
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
