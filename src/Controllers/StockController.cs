using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
    public class StockController
    {
        private readonly AppDbContext _context;

        public StockController()
        {
            _context = new AppDbContext();
        }

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        public List<StockModel> GetAllStock()
        {
            return _context.Stock
                .Include(s => s.Articulo)
                .ToList();
        }

        public StockModel? GetStockById(int id)
        {
            return _context.Stock
                .Include(s => s.Articulo)
                .FirstOrDefault(s => s.CodStock == id);
        }

        public StockModel? GetStockByArticuloId(int articuloId)
        {
            return _context.Stock
                .Include(s => s.Articulo)
                .FirstOrDefault(s => s.IdArticulo == articuloId);
        }

        public bool CreateStock(StockModel stock)
        {
            try
            {
                _context.Stock.Add(stock);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateStock(StockModel stock)
        {
            try
            {
                var existingStock = _context.Stock.Find(stock.CodStock);
                if (existingStock == null)
                    return false;

                existingStock.IdArticulo = stock.IdArticulo;
                existingStock.Cantidad = stock.Cantidad;
                existingStock.Costo = stock.Costo;
                existingStock.Ganancia = stock.Ganancia;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStock(int id)
        {
            try
            {
                var stock = _context.Stock.Find(id);
                if (stock == null)
                    return false;

                _context.Stock.Remove(stock);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AdjustStock(int articuloId, int cantidad)
        {
            try
            {
                var stock = GetStockByArticuloId(articuloId);
                if (stock == null)
                    return false;

                stock.Cantidad = (stock.Cantidad ?? 0) + cantidad;
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
