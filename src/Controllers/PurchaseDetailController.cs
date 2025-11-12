using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Controllers
{
 public class PurchaseDetailController : IGenericController<PurchaseDetailModel>
   {
        private readonly AppDbContext _context;

        public PurchaseDetailController()
        {
     _context = new AppDbContext();
        }

    public PurchaseDetailController(AppDbContext context)
        {
            _context = context;
   }

        public List<PurchaseDetailModel> GetAll()
        {
    return _context.PurchaseDetail
 .Include(d => d.Purchase)
     .Include(d => d.Article)
   .ToList();
        }

        public PurchaseDetailModel? GetById(object id)
        {
          if (id is int intId) return GetDetalleById(intId);
    if (int.TryParse(id?.ToString(), out int parsed)) return GetDetalleById(parsed);
       return null;
        }

    public PurchaseDetailModel? GetDetalleById(int id)
   {
 return _context.PurchaseDetail
  .Include(d => d.Purchase)
            .Include(d => d.Article)
      .FirstOrDefault(d => d.Id == id);
        }

 public List<PurchaseDetailModel> GetDetallesByCompra(int compraId)
    {
      return _context.PurchaseDetail
      .Include(d => d.Purchase)
.Include(d => d.Article)
           .Where(d => d.PurchaseId == compraId)
       .ToList();
   }

        public List<PurchaseDetailModel> GetDetallesByArticulo(int articuloId)
        {
return _context.PurchaseDetail
      .Include(d => d.Purchase)
       .Include(d => d.Article)
 .Where(d => d.ArticleId == articuloId)
          .ToList();
        }

        public bool Create(PurchaseDetailModel detalle)
      {
 try
            {
       _context.PurchaseDetail.Add(detalle);
    _context.SaveChanges();
 return true;
      }
   catch (Exception ex)
         {
   Debug.WriteLine(ex);
       return false;
            }
   }

   public bool Update(PurchaseDetailModel detalle)
        {
    try
 {
       var existingDetalle = _context.PurchaseDetail.Find(detalle.Id);
 if (existingDetalle == null)
       return false;

     existingDetalle.PurchaseId = detalle.PurchaseId;
     existingDetalle.ArticleId = detalle.ArticleId;
  existingDetalle.Description = detalle.Description;
 existingDetalle.UnitPrice = detalle.UnitPrice;
      existingDetalle.Quantity = detalle.Quantity;
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
      var detalle = _context.PurchaseDetail.Find(intId);
      if (detalle == null) return false;
  _context.PurchaseDetail.Remove(detalle);
 _context.SaveChanges();
   return true;
   }
catch
 {
           return false;
         }
    }

        public bool CreateBatch(List<PurchaseDetailModel> detalles)
        {
 try
      {
      _context.PurchaseDetail.AddRange(detalles);
       _context.SaveChanges();
     return true;
         }
       catch (Exception ex)
   {
   Debug.WriteLine(ex);
      return false;
     }
        }

   public bool DeleteByCompra(int compraId)
        {
   try
  {
       var detalles = _context.PurchaseDetail.Where(d => d.PurchaseId == compraId);
        _context.PurchaseDetail.RemoveRange(detalles);
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