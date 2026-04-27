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
    public class SellService : IGenericController<SellModel, int>
    {
        private readonly AppDbContext _context;
        private readonly StockService _stockService;
        private readonly ClientService _clientService;

        public SellService()
        {
            _context = new AppDbContext();
            _stockService = new StockService(_context);
            _clientService = new ClientService(_context);
        }

        public SellService(AppDbContext context)
        {
            _context = context;
            _stockService = new StockService(context);
            _clientService = new ClientService(context);
        }

        public async Task<List<SellModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Sell
                .AsNoTracking()
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(v => v.Active);
            }

            query = query.OrderByDescending(v => v.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<List<SellModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Sell
                .AsNoTracking()
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(v => v.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(v =>
                    (v.Title != null && v.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (v.Description != null && v.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderByDescending(v => v.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<SellModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Sell
                .AsNoTracking()
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefaultAsync(v => v.Id == id, ct);
        }

        public async Task<bool> CreateAsync(SellModel venta, CancellationToken ct = default)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(SellModel venta, CancellationToken ct = default)
        {
            try
            {
                var existing = await _context.Sell.FindAsync(new object[] { venta.Id }, ct);
                if (existing == null) return false;

                existing.UserId = venta.UserId;
                existing.ClientId = venta.ClientId;
                existing.Date = venta.Date;
                existing.Active = venta.Active;
                existing.Subtotal = venta.Subtotal;
                existing.Discount = venta.Discount;
                existing.Total = venta.Total;
                existing.Title = venta.Title;
                existing.Description = venta.Description;

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
                var venta = await _context.Sell.FindAsync(new object[] { id }, ct);
                if (venta == null) return false;
                
                venta.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateVentaConDetallesAsync(SellModel venta, List<SellDetailModel> detalles, CancellationToken ct = default)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                await _context.SaveChangesAsync(ct);

                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = await _stockService.AdjustStockAsync(detalle.ArticleId.Value, -detalle.Quantity.Value, ct);
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

        public async Task<bool> UpdateVentaConDetallesAsync(SellModel venta, List<SellDetailModel> detalles, CancellationToken ct = default)
        {
            try
            {
                var existing = await _context.Sell.FindAsync(new object[] { venta.Id }, ct);
                if (existing == null) return false;

                existing.UserId = venta.UserId;
                existing.ClientId = venta.ClientId;
                existing.Date = venta.Date;
                existing.Active = venta.Active;
                existing.Subtotal = venta.Subtotal;
                existing.Discount = venta.Discount;
                existing.Total = venta.Total;
                existing.Title = venta.Title;
                existing.Description = venta.Description;

                var oldDetails = await _context.SellDetail.Where(d => d.SellId == venta.Id).ToListAsync(ct);
                
                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && oldDetail.Quantity.HasValue)
                    {
                        await _stockService.AdjustStockAsync(oldDetail.ArticleId.Value, oldDetail.Quantity.Value, ct);
                    }
                }

                _context.SellDetail.RemoveRange(oldDetails);

                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = await _stockService.AdjustStockAsync(detalle.ArticleId.Value, -detalle.Quantity.Value, ct);
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

        public async Task<List<SellModel>> GetVentasByClienteAsync(int clienteId, CancellationToken ct = default)
        {
            return await _context.Sell
                .AsNoTracking()
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.ClientId == clienteId)
                .OrderByDescending(v => v.Id)
                .ToListAsync(ct);
        }

        public async Task<List<SellModel>> GetVentasByUsuarioAsync(int usuarioId, CancellationToken ct = default)
        {
            return await _context.Sell
                .AsNoTracking()
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.UserId == usuarioId)
                .OrderByDescending(v => v.Id)
                .ToListAsync(ct);
        }

        public async Task<List<ClientModel>> GetAllClientsAsync(CancellationToken ct = default)
        {
            return await _clientService.GetAllAsync(ct: ct);
        }

        public async Task<ClientModel?> GetClientByNameAsync(string name, CancellationToken ct = default)
        {
            var allClients = await GetAllClientsAsync(ct);
            return allClients.FirstOrDefault(c => c.Name == name);
        }

        public async Task<ArticleModel?> GetArticleByNameAsync(string name, CancellationToken ct = default)
        {
            var articleService = new ArticleService(_context);
            return await articleService.GetByNameAsync(name, ct);
        }

        public async Task<StockModel?> GetStockByArticleIdAsync(int articleId, CancellationToken ct = default)
        {
            return await _stockService.GetStockByArticuloIdAsync(articleId, ct);
        }

        public decimal CalculateSubtotal(List<(decimal UnitPrice, int Quantity)> items)
        {
            decimal subtotal = 0;
            foreach (var item in items)
            {
                subtotal += item.UnitPrice * item.Quantity;
            }
            return subtotal;
        }

        public (decimal Subtotal, decimal DiscountAmount, decimal Total) CalculateTotals(decimal subtotal, decimal discountPercent)
        {
            decimal discountAmount = subtotal * (discountPercent / 100);
            decimal total = subtotal - discountAmount;
            return (subtotal, discountAmount, total);
        }

        public async Task<SellValidationResult> ValidateSellAsync(
            int? clientId,
            List<(int ArticleId, int Quantity, decimal UnitPrice, string ArticleName)> items,
            bool isEditMode,
            SellModel? existingSell,
            CancellationToken ct = default)
        {
            var errors = new List<string>();

            if (!clientId.HasValue)
            {
                errors.Add("Debe seleccionar un cliente");
            }

            if (items.Count == 0)
            {
                errors.Add("Debe agregar al menos un artículo");
            }

            foreach (var item in items)
            {
                if (item.Quantity <= 0)
                {
                    errors.Add($"La cantidad del artículo '{item.ArticleName}' debe ser mayor a 0");
                    break;
                }

                if (item.UnitPrice <= 0)
                {
                    errors.Add($"El precio unitario del artículo '{item.ArticleName}' debe ser mayor a 0");
                    break;
                }

                var stock = await _stockService.GetStockByArticuloIdAsync(item.ArticleId, ct);
                if (stock != null)
                {
                    int availableStock = stock.Stock ?? 0;
                    int requestedQty = item.Quantity;

                    if (isEditMode && existingSell?.Detail != null)
                    {
                        var originalDetail = existingSell.Detail.FirstOrDefault(d => d.ArticleId == item.ArticleId);
                        if (originalDetail != null && originalDetail.Quantity.HasValue)
                        {
                            availableStock += originalDetail.Quantity.Value;
                        }
                    }

                    if (requestedQty > availableStock)
                    {
                        errors.Add($"Stock insuficiente para '{item.ArticleName}'. Disponible: {availableStock}, Solicitado: {requestedQty}");
                    }
                }
            }

            return new SellValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }

        public List<SellDetailModel> CreateSellDetails(List<(int ArticleId, int Quantity)> items)
        {
            return items.Select(item => new SellDetailModel
            {
                ArticleId = item.ArticleId,
                Quantity = item.Quantity
            }).ToList();
        }

        public async Task<SellSaveResult> SaveSellAsync(
            int? clientId,
            decimal subtotal,
            decimal discountPercent,
            List<(int ArticleId, int Quantity)> details,
            bool isEditMode,
            SellModel? existingSell,
            CancellationToken ct = default)
        {
            var result = new SellSaveResult { Success = false };

            if (!clientId.HasValue)
            {
                result.ErrorMessage = "Cliente no válido";
                return result;
            }

            var client = await GetClientByNameAsync(GetAllClientsAsync(ct).Result.FirstOrDefault(c => c.Id == clientId.Value)?.Name ?? "", ct);
            if (client == null)
            {
                result.ErrorMessage = "Cliente no encontrado";
                return result;
            }

            var sell = isEditMode && existingSell != null
                ? existingSell
                : new SellModel();

            sell.UserId = Session.CurrentUser?.Id;
            sell.ClientId = clientId.Value;
            sell.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sell.Subtotal = subtotal.ToString("F2");
            sell.Discount = (subtotal * (discountPercent / 100)).ToString("F2");
            sell.Total = (subtotal - (subtotal * (discountPercent / 100))).ToString("F2");

            var sellDetails = CreateSellDetails(details);

            bool success;
            if (isEditMode && existingSell != null)
            {
                sell.Title = $"Venta #{sell.Id}";
                sell.Description = $"Cliente: {client.Name} | Total: ${sell.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                success = await UpdateVentaConDetallesAsync(sell, sellDetails, ct);
            }
            else
            {
                success = await CreateVentaConDetallesAsync(sell, sellDetails, ct);
                if (success)
                {
                    sell.Title = $"Venta #{sell.Id}";
                    sell.Description = $"Cliente: {client.Name} | Total: ${sell.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                    await UpdateAsync(sell, ct);
                }
            }

            result.Success = success;
            result.SellId = sell.Id;
            result.ClientId = clientId.Value;
            result.ErrorMessage = success ? null : "Error al guardar la venta";

            return result;
        }

        public List<SellModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<SellModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public SellModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(SellModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(SellModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public List<ClientModel> GetAllClients()
            => GetAllClientsAsync().GetAwaiter().GetResult();

        public ClientModel? GetClientByName(string name)
            => GetClientByNameAsync(name).GetAwaiter().GetResult();

        public ArticleModel? GetArticleByName(string name)
            => GetArticleByNameAsync(name).GetAwaiter().GetResult();

        public StockModel? GetStockByArticleId(int articleId)
            => GetStockByArticleIdAsync(articleId).GetAwaiter().GetResult();

        public SellValidationResult ValidateSell(
            int? clientId,
            List<(int ArticleId, int Quantity, decimal UnitPrice, string ArticleName)> items,
            bool isEditMode,
            SellModel? existingSell)
            => ValidateSellAsync(clientId, items, isEditMode, existingSell).GetAwaiter().GetResult();

        public SellSaveResult SaveSell(
            int? clientId,
            decimal subtotal,
            decimal discountPercent,
            List<(int ArticleId, int Quantity)> details,
            bool isEditMode,
            SellModel? existingSell)
            => SaveSellAsync(clientId, subtotal, discountPercent, details, isEditMode, existingSell).GetAwaiter().GetResult();
    }

    public class SellValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class SellSaveResult
    {
        public bool Success { get; set; }
        public int SellId { get; set; }
        public int ClientId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}