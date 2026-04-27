using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSystems.Core;

namespace PrimeSystems.Services
{
    public class ArticleService : IGenericController<ArticleModel, int>
    {
        private readonly AppDbContext _context;

        public ArticleService()
        {
            _context = new AppDbContext();
        }

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }

        public List<ArticleModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(a => a.Active);
            }

            query = query.OrderBy(a => a.Title);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public List<ArticleModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(a => a.Active);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(a =>
                    (a.Title != null && a.Title.ToLower().Contains(searchTerm)) ||
                    (a.Description != null && a.Description.ToLower().Contains(searchTerm))
                );
            }

            query = query.OrderBy(a => a.Title);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public ArticleModel? GetById(int id)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Id == id);
        }

        public ArticleModel? GetArticuloByCodigo(string codigo)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Code == codigo);
        }

        public ArticleModel? GetByName(string name)
        {
            return _context.Article
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefault(a => a.Name == name);
        }

        public bool Create(ArticleModel articulo)
        {
            try
            {
                // Validar que el c�digo de art�culo no exista
                if (_context.Article.Any(a => a.Code == articulo.Code))
                    return false;

                articulo.Active = true;
                _context.Article.Add(articulo);
                _context.SaveChanges();
                articulo.Title = articulo.Name;
                articulo.Description = $"C�digo: {articulo.Code} | Categor�a: {articulo.Category?.Name ?? "Sin categor�a"}";
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool Update(ArticleModel articulo)
        {
            try
            {
                var existingArticulo = _context.Article.Find(articulo.Id);
                if (existingArticulo == null)
                    return false;

                if (_context.Article.Any(a => a.Code == articulo.Code && a.Id != articulo.Id))
                    return false;

                existingArticulo.Code = articulo.Code;
                existingArticulo.Name = articulo.Name;
                existingArticulo.Description = articulo.Description;
                existingArticulo.CategoryId = articulo.CategoryId;
                existingArticulo.SubcategoryId = articulo.SubcategoryId;
                existingArticulo.SupplierId = articulo.SupplierId;
                existingArticulo.Active = articulo.Active;

                existingArticulo.Title = articulo.Name;
                var category = _context.Category.Find(articulo.CategoryId);
                existingArticulo.Description = $"C�digo: {articulo.Code} | Categor�a: {category?.Name ?? "Sin categor�a"}";

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
                var articulo = _context.Article.Find(id);
                if (articulo == null) return false;

                articulo.Active = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public StockModel? GetStockByArticuloId(int articleId)
        {
            var stockService = new StockService(_context);
            return stockService.GetStockByArticuloId(articleId);
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categoryService = new CategoryService(_context);
            return categoryService.GetAll();
        }

        public CategoryModel? GetCategoryByName(string name)
        {
            var categoryService = new CategoryService(_context);
            return categoryService.GetAll().FirstOrDefault(c => c.Name == name);
        }

        public CategoryModel? CreateCategory(string name)
        {
            var categoryService = new CategoryService(_context);
            var newCategory = new CategoryModel { Name = name };
            if (categoryService.Create(newCategory))
            {
                return categoryService.GetAll().FirstOrDefault(c => c.Name == name);
            }
            return null;
        }

        public List<SubcategoryModel> GetSubcategoriesByCategory(int categoryId)
        {
            var subcategoryService = new SubcategoryService(_context);
            return subcategoryService.GetSubcategoriesByCategoria(categoryId);
        }

        public SubcategoryModel? GetSubcategoryByNameAndCategory(string name, int categoryId)
        {
            var subcategoryService = new SubcategoryService(_context);
            return subcategoryService.GetAll()
                .FirstOrDefault(s => s.Name == name && s.CategoryId == categoryId);
        }

        public SubcategoryModel? CreateSubcategory(string name, int categoryId)
        {
            var subcategoryService = new SubcategoryService(_context);
            var newSubcategory = new SubcategoryModel { Name = name, CategoryId = categoryId };
            if (subcategoryService.Create(newSubcategory))
            {
                return subcategoryService.GetAll()
                    .FirstOrDefault(s => s.Name == name && s.CategoryId == categoryId);
            }
            return null;
        }

        public decimal CalculateSellPrice(decimal cost, int profitPercent)
        {
            return cost + (cost * profitPercent / 100);
        }

        public ArticleValidationResult ValidateArticle(
            string code,
            string name,
            string? categoryName,
            int stockQuantity,
            decimal cost,
            int profitPercent)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(code))
                errors.Add("Código del artículo");

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Nombre del artículo");

            if (string.IsNullOrWhiteSpace(categoryName))
                errors.Add("Categoría");

            if (stockQuantity < 0)
                errors.Add("Cantidad de stock (debe ser un número mayor o igual a 0)");

            if (cost < 0)
                errors.Add("Costo (debe ser un número mayor o igual a 0)");

            if (profitPercent < 0)
                errors.Add("Ganancia (debe ser un porcentaje mayor o igual a 0)");

            return new ArticleValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }

        public ArticleSaveResult SaveArticle(
            int originalId,
            string code,
            string name,
            string? description,
            string categoryName,
            string? subcategoryName,
            int stockQuantity,
            decimal cost,
            int profitPercent)
        {
            var result = new ArticleSaveResult { Success = false };

            var category = GetCategoryByName(categoryName);
            if (category == null)
            {
                category = CreateCategory(categoryName);
                if (category == null)
                {
                    result.ErrorMessage = "Error al crear la nueva categoría";
                    return result;
                }
            }

            int? subcategoryId = null;
            if (!string.IsNullOrWhiteSpace(subcategoryName))
            {
                var subcategory = GetSubcategoryByNameAndCategory(subcategoryName, category.Id);
                if (subcategory == null)
                {
                    subcategory = CreateSubcategory(subcategoryName, category.Id);
                }
                subcategoryId = subcategory?.Id;
            }

            var article = originalId == 0 ? new ArticleModel() : (GetById(originalId) ?? new ArticleModel());
            article.Code = code.Trim().ToUpper();
            article.Name = name.Trim();
            article.Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
            article.CategoryId = category.Id;
            article.SubcategoryId = subcategoryId;

            bool articleSuccess;
            if (originalId == 0)
                articleSuccess = Create(article);
            else
                articleSuccess = Update(article);

            if (!articleSuccess)
            {
                result.ErrorMessage = "Error al guardar el artículo. El código ya existe o hay un problema con los datos";
                return result;
            }

            if (article.Stock == null || article.Stock.ArticleId == 0)
            {
                var savedByCode = GetArticuloByCodigo(article.Code);
                if (savedByCode != null)
                {
                    article.Id = savedByCode.Id;
                }
            }

            var stockService = new StockService(_context);
            var stock = article.Stock ?? new StockModel { ArticleId = article.Id };
            stock.Stock = stockQuantity;
            stock.Cost = cost.ToString("F2");
            stock.Profit = profitPercent;

            bool stockSuccess;
            if (stock.Id == 0)
                stockSuccess = stockService.Create(stock);
            else
                stockSuccess = stockService.Update(stock);

            result.Success = stockSuccess;
            result.ArticleId = article.Id;
            result.ErrorMessage = stockSuccess ? null : "Artículo guardado, pero hubo un error al guardar el stock";

            return result;
        }
    }

    public class ArticleValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class ArticleSaveResult
    {
        public bool Success { get; set; }
        public int ArticleId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
