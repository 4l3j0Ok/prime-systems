using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
public class SellDetailController : IGenericController<SellDetailModel>
    {
private readonly AppDbContext _context;

        public SellDetailController()
        {
        _context = new AppDbContext();
        }

        public SellDetailController(AppDbContext context)
        {
            _context = context;
        }

        public List<SellDetailModel> GetAll()
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .ToList();
        }

        public SellDetailModel? GetById(object id)
        {
            if (id is int intId) return GetDetalleById(intId);
            if (int.TryParse(id?.ToString(), out int parsed)) return GetDetalleById(parsed);
                return null;
        }

        public SellDetailModel? GetDetalleById(int id)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .FirstOrDefault(d => d.Id == id);
        }

        public List<SellDetailModel> GetDetallesByVenta(int ventaId)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.SellId == ventaId)
                .ToList();
        }

        public List<SellDetailModel> GetDetallesByArticulo(int articuloId)
        {
            return _context.SellDetail
                .Include(d => d.Sell)
                .Include(d => d.Article)
                .Where(d => d.ArticleId == articuloId)
                .ToList();
        }

        public bool Create(SellDetailModel detalle)
    {
   try
   {
 _context.SellDetail.Add(detalle);
     _context.SaveChanges();
       return true;
       }
      catch (Exception ex)
     {
    Debug.WriteLine(ex);
   return false;
     }
  }

    public bool Update(SellDetailModel detalle)
        {
    try
         {
   var existingDetalle = _context.SellDetail.Find(detalle.Id);
     if (existingDetalle == null)
       return false;

    existingDetalle.SellId = detalle.SellId;
 existingDetalle.ArticleId = detalle.ArticleId;
  existingDetalle.Quantity = detalle.Quantity;
  existingDetalle.Description = detalle.Description;
     existingDetalle.Subtotal = detalle.Subtotal;
    existingDetalle.Discount = detalle.Discount;
 existingDetalle.Total = detalle.Total;

     _context.SaveChanges();
    return true;
   }
         catch
     {
      return false;
            }
      }

    public bool Delete(object id)
  {
            try
  {
 if (!int.TryParse(id?.ToString(), out int intId)) return false;
     var detalle = _context.SellDetail.Find(intId);
         if (detalle == null) return false;
  _context.SellDetail.Remove(detalle);
 _context.SaveChanges();
 return true;
 }
        catch
            {
    return false;
     }
      }

     public bool CreateBatch(List<SellDetailModel> detalles)
        {
      try
     {
       _context.SellDetail.AddRange(detalles);
       _context.SaveChanges();
      return true;
     }
       catch (Exception ex)
  {
      Debug.WriteLine(ex);
     return false;
    }
        }

        public bool DeleteByVenta(int ventaId)
 {
   try
       {
      var detalles = _context.SellDetail.Where(d => d.SellId == ventaId);
      _context.SellDetail.RemoveRange(detalles);
     _context.SaveChanges();
      return true;
   }
      catch
    {
          return false;
    }
        }

 public decimal GetTotalByVenta(int ventaId)
        {
     try
     {
          var detalles = GetDetallesByVenta(ventaId);
   decimal total = 0;
      foreach (var detalle in detalles)
         {
   if (decimal.TryParse(detalle.Total, out decimal detalleTotal))
    {
      total += detalleTotal;
     }
  }
       return total;
            }
catch
    {
return 0;
      }
  }
    }
}