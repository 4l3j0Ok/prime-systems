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

        public async Task<List<ArticleModel>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Article
                .AsNoTracking()
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

            return await query.ToListAsync(ct);
        }

        public async Task<List<ArticleModel>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default)
        {
            var query = _context.Article
                .AsNoTracking()
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
                var searchLower = searchTerm.ToLowerInvariant();
                query = query.Where(a =>
                    (a.Title != null && a.Title.ToLowerInvariant().Contains(searchLower)) ||
                    (a.Description != null && a.Description.ToLowerInvariant().Contains(searchLower))
                );
            }

            query = query.OrderBy(a => a.Title);

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<ArticleModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Article
                .AsNoTracking()
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefaultAsync(a => a.Id == id, ct);
        }

        public async Task<ArticleModel?> GetArticuloByCodigoAsync(string codigo, CancellationToken ct = default)
        {
            return await _context.Article
                .AsNoTracking()
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefaultAsync(a => a.Code == codigo, ct);
        }

        public async Task<ArticleModel?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return await _context.Article
                .AsNoTracking()
                .Include(a => a.Category)
                .Include(a => a.Subcategory)
                .Include(a => a.Supplier)
                .Include(a => a.Stock)
                .FirstOrDefaultAsync(a => a.Name == name, ct);
        }

        public async Task<bool> CreateAsync(ArticleModel articulo, CancellationToken ct = default)
        {
            try
            {
                if (await _context.Article.AnyAsync(a => a.Code == articulo.Code, ct))
                    return false;

                articulo.Active = true;
                _context.Article.Add(articulo);
                await _context.SaveChangesAsync(ct);
                articulo.Title = articulo.Name;
                articulo.Description = $"Código: {articulo.Code} | Categoría: {articulo.Category?.Name ?? "Sin categoría"}";
                await _context.SaveChangesAsync(ct);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ArticleModel articulo, CancellationToken ct = default)
        {
            try
            {
                var existingArticulo = await _context.Article.FindAsync(new object[] { articulo.Id }, ct);
                if (existingArticulo == null)
                    return false;

                if (await _context.Article.AnyAsync(a => a.Code == articulo.Code && a.Id != articulo.Id, ct))
                    return false;

                existingArticulo.Code = articulo.Code;
                existingArticulo.Name = articulo.Name;
                existingArticulo.Description = articulo.Description;
                existingArticulo.CategoryId = articulo.CategoryId;
                existingArticulo.SubcategoryId = articulo.SubcategoryId;
                existingArticulo.SupplierId = articulo.SupplierId;
                existingArticulo.Active = articulo.Active;

                existingArticulo.Title = articulo.Name;
                var category = await _context.Category.FindAsync(new object[] { articulo.CategoryId }, ct);
                existingArticulo.Description = $"Código: {articulo.Code} | Categoría: {category?.Name ?? "Sin categoría"}";

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
                var articulo = await _context.Article.FindAsync(new object[] { id }, ct);
                if (articulo == null) return false;

                articulo.Active = false;
                await _context.SaveChangesAsync(ct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ArticleModel> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => GetAllAsync(includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public List<ArticleModel> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null)
            => SearchAsync(searchTerm, includeInactive, pageNumber, pageSize).GetAwaiter().GetResult();

        public ArticleModel? GetById(int id)
            => GetByIdAsync(id).GetAwaiter().GetResult();

        public bool Create(ArticleModel item)
            => CreateAsync(item).GetAwaiter().GetResult();

        public bool Update(ArticleModel item)
            => UpdateAsync(item).GetAwaiter().GetResult();

        public bool Delete(int id)
            => DeleteAsync(id).GetAwaiter().GetResult();

        public async Task<StockModel?> GetStockByArticuloIdAsync(int articleId, CancellationToken ct = default)
        {
            var stockService = new StockService(_context);
            return await stockService.GetStockByArticuloIdAsync(articleId, ct);
        }

        public StockModel? GetStockByArticuloId(int articleId)
        {
            var stockService = new StockService(_context);
            return stockService.GetStockByArticuloId(articleId);
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync(CancellationToken ct = default)
        {
            var categoryService = new CategoryService(_context);
            return await categoryService.GetAllAsync(ct: ct);
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categoryService = new CategoryService(_context);
            return categoryService.GetAll();
        }

        public async Task<CategoryModel?> GetCategoryByNameAsync(string name, CancellationToken ct = default)
        {
            var categoryService = new CategoryService(_context);
            return await categoryService.GetAllAsync(ct: ct)
                .ContinueWith(t => t.Result.FirstOrDefault(c => c.Name == name), ct);
        }

        public CategoryModel? GetCategoryByName(string name)
        {
            var categoryService = new CategoryService(_context);
            return categoryService.GetAll().FirstOrDefault(c => c.Name == name);
        }

        public async Task<CategoryModel?> CreateCategoryAsync(string name, CancellationToken ct = default)
        {
            var categoryService = new CategoryService(_context);
            var newCategory = new CategoryModel { Name = name };
            if (await categoryService.CreateAsync(newCategory, ct))
            {
                var allCategories = await categoryService.GetAllAsync(ct: ct);
                return allCategories.FirstOrDefault(c => c.Name == name);
            }
            return null;
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

        public async Task<List<SubcategoryModel>> GetSubcategoriesByCategoryAsync(int categoryId, CancellationToken ct = default)
        {
            var subcategoryService = new SubcategoryService(_context);
            return await subcategoryService.GetSubcategoriesByCategoriaAsync(categoryId, ct);
        }

        public List<SubcategoryModel> GetSubcategoriesByCategory(int categoryId)
        {
            var subcategoryService = new SubcategoryService(_context);
            return subcategoryService.GetSubcategoriesByCategoria(categoryId);
        }

        public async Task<SubcategoryModel?> GetSubcategoryByNameAndCategoryAsync(string name, int categoryId, CancellationToken ct = default)
        {
            var subcategoryService = new SubcategoryService(_context);
            var all = await subcategoryService.GetAllAsync(ct: ct);
            return all.FirstOrDefault(s => s.Name == name && s.CategoryId == categoryId);
        }

        public SubcategoryModel? GetSubcategoryByNameAndCategory(string name, int categoryId)
        {
            var subcategoryService = new SubcategoryService(_context);
            return subcategoryService.GetAll()
                .FirstOrDefault(s => s.Name == name && s.CategoryId == categoryId);
        }

        public async Task<SubcategoryModel?> CreateSubcategoryAsync(string name, int categoryId, CancellationToken ct = default)
        {
            var subcategoryService = new SubcategoryService(_context);
            var newSubcategory = new SubcategoryModel { Name = name, CategoryId = categoryId };
            if (await subcategoryService.CreateAsync(newSubcategory, ct))
            {
                var all = await subcategoryService.GetAllAsync(ct: ct);
                return all.FirstOrDefault(s => s.Name == name && s.CategoryId == categoryId);
            }
            return null;
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

        public async Task<ArticleSaveResult> SaveArticleAsync(
            int originalId,
            string code,
            string name,
            string? description,
            string categoryName,
            string? subcategoryName,
            int stockQuantity,
            decimal cost,
            int profitPercent,
            CancellationToken ct = default)
        {
            var result = new ArticleSaveResult { Success = false };

            var category = await GetCategoryByNameAsync(categoryName, ct);
            if (category == null)
            {
                category = await CreateCategoryAsync(categoryName, ct);
                if (category == null)
                {
                    result.ErrorMessage = "Error al crear la nueva categoría";
                    return result;
                }
            }

            int? subcategoryId = null;
            if (!string.IsNullOrWhiteSpace(subcategoryName))
            {
                var subcategory = await GetSubcategoryByNameAndCategoryAsync(subcategoryName, category.Id, ct);
                if (subcategory == null)
                {
                    subcategory = await CreateSubcategoryAsync(subcategoryName, category.Id, ct);
                }
                subcategoryId = subcategory?.Id;
            }

            var article = originalId == 0 ? new ArticleModel() : (await GetByIdAsync(originalId, ct) ?? new ArticleModel());
            article.Code = code.Trim().ToUpper();
            article.Name = name.Trim();
            article.Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
            article.CategoryId = category.Id;
            article.SubcategoryId = subcategoryId;

            bool articleSuccess;
            if (originalId == 0)
                articleSuccess = await CreateAsync(article, ct);
            else
                articleSuccess = await UpdateAsync(article, ct);

            if (!articleSuccess)
            {
                result.ErrorMessage = "Error al guardar el artículo. El código ya existe o hay un problema con los datos";
                return result;
            }

            if (article.Stock == null || article.Stock.ArticleId == 0)
            {
                var savedByCode = await GetArticuloByCodigoAsync(article.Code, ct);
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
                stockSuccess = await stockService.CreateAsync(stock, ct);
            else
                stockSuccess = await stockService.UpdateAsync(stock, ct);

            result.Success = stockSuccess;
            result.ArticleId = article.Id;
            result.ErrorMessage = stockSuccess ? null : "Artículo guardado, pero hubo un error al guardar el stock";

            return result;
        }

        public ArticleModel? GetByName(string name)
            => GetByNameAsync(name).GetAwaiter().GetResult();

        public ArticleModel? GetArticuloByCodigo(string codigo)
            => GetArticuloByCodigoAsync(codigo).GetAwaiter().GetResult();

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
            => SaveArticleAsync(originalId, code, name, description, categoryName, subcategoryName, stockQuantity, cost, profitPercent).GetAwaiter().GetResult();
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