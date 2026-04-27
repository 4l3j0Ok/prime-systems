using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public List<SellModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Sell
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

            return query.ToList();
        }

        public List<SellModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Sell
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
                searchTerm = searchTerm.ToLower();
                query = query.Where(v =>
                    (v.Title != null && v.Title.ToLower().Contains(searchTerm)) ||
                    (v.Description != null && v.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderByDescending(v => v.Id);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public SellModel? GetById(int id)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Include(v => v.Detail)
                    .ThenInclude(d => d.Article)
                .FirstOrDefault(v => v.Id == id);
        }

        public bool Create(SellModel venta)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(SellModel venta)
        {
            try
            {
                var existing = _context.Sell.Find(venta.Id);
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
                var venta = _context.Sell.Find(id);
                if (venta == null) return false;
                
                // Baja l�gica
                venta.Active = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateVentaConDetalles(SellModel venta, List<SellDetailModel> detalles)
        {
            try
            {
                venta.Active = true;
                _context.Sell.Add(venta);
                _context.SaveChanges();

                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    // Reducir el stock si el detalle tiene un art�culo asociado
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = _stockService.AdjustStock(detalle.ArticleId.Value, -detalle.Quantity.Value);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el art�culo {detalle.ArticleId.Value}");
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

        public bool UpdateVentaConDetalles(SellModel venta, List<SellDetailModel> detalles)
        {
            try
            {
                // Actualizar la venta
                var existing = _context.Sell.Find(venta.Id);
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

                // Obtener los detalles anteriores para restaurar el stock
                var oldDetails = _context.SellDetail.Where(d => d.SellId == venta.Id).ToList();
                
                // Restaurar el stock de los art�culos vendidos anteriormente
                foreach (var oldDetail in oldDetails)
                {
                    if (oldDetail.ArticleId.HasValue && oldDetail.Quantity.HasValue)
                    {
                        _stockService.AdjustStock(oldDetail.ArticleId.Value, oldDetail.Quantity.Value);
                    }
                }

                // Eliminar los detalles anteriores
                _context.SellDetail.RemoveRange(oldDetails);

                // Agregar los nuevos detalles y reducir el stock
                foreach (var detalle in detalles)
                {
                    detalle.SellId = venta.Id;
                    _context.SellDetail.Add(detalle);
                    
                    // Reducir el stock si el detalle tiene un art�culo asociado
                    if (detalle.ArticleId.HasValue && detalle.Quantity.HasValue)
                    {
                        bool stockAdjusted = _stockService.AdjustStock(detalle.ArticleId.Value, -detalle.Quantity.Value);
                        if (!stockAdjusted)
                        {
                            Debug.WriteLine($"Advertencia: No se pudo ajustar el stock para el art�culo {detalle.ArticleId.Value}");
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

        public List<SellModel> GetVentasByCliente(int clienteId)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.ClientId == clienteId)
                .OrderByDescending(v => v.Id)
                .ToList();
        }

        public List<SellModel> GetVentasByUsuario(int usuarioId)
        {
            return _context.Sell
                .Include(v => v.User)
                .Include(v => v.Client)
                .Where(v => v.UserId == usuarioId)
                .OrderByDescending(v => v.Id)
                .ToList();
        }

        public List<ClientModel> GetAllClients()
        {
            return _clientService.GetAll();
        }

        public ClientModel? GetClientByName(string name)
        {
            return _clientService.GetAll().FirstOrDefault(c => c.Name == name);
        }

        public ArticleModel? GetArticleByName(string name)
        {
            var articleService = new ArticleService(_context);
            return articleService.GetByName(name);
        }

        public StockModel? GetStockByArticleId(int articleId)
        {
            return _stockService.GetStockByArticuloId(articleId);
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

        public SellValidationResult ValidateSell(
            int? clientId,
            List<(int ArticleId, int Quantity, decimal UnitPrice, string ArticleName)> items,
            bool isEditMode,
            SellModel? existingSell)
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

                var stock = _stockService.GetStockByArticuloId(item.ArticleId);
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

        public SellSaveResult SaveSell(
            int? clientId,
            decimal subtotal,
            decimal discountPercent,
            List<(int ArticleId, int Quantity)> details,
            bool isEditMode,
            SellModel? existingSell)
        {
            var result = new SellSaveResult { Success = false };

            if (!clientId.HasValue)
            {
                result.ErrorMessage = "Cliente no válido";
                return result;
            }

            var client = GetClientByName(GetAllClients().FirstOrDefault(c => c.Id == clientId.Value)?.Name ?? "");
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
                success = UpdateVentaConDetalles(sell, sellDetails);
            }
            else
            {
                success = CreateVentaConDetalles(sell, sellDetails);
                if (success)
                {
                    sell.Title = $"Venta #{sell.Id}";
                    sell.Description = $"Cliente: {client.Name} | Total: ${sell.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                    Update(sell);
                }
            }

            result.Success = success;
            result.SellId = sell.Id;
            result.ClientId = clientId.Value;
            result.ErrorMessage = success ? null : "Error al guardar la venta";

            return result;
        }
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
