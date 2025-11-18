using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class Article : UserControl
    {
        private ArticleController articleController;
        private CategoryController categoryController;
        private SubcategoryController subcategoryController;
        private StockController stockController;
        private ArticleModel selectedArticle;
        private StockModel? selectedStock;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();

        public Article(ArticleModel? article = null)
        {
            articleController = new ArticleController();
            categoryController = new CategoryController();
            subcategoryController = new SubcategoryController();
            stockController = new StockController();

            InitializeComponent();
            SetupControls();
            LoadCategories();

            if (article == null)
            {
                selectedArticle = new ArticleModel();
                selectedStock = new StockModel();
                return;
            }
            mepArticleAdd.Title = "Modificar Artículo";
            mepArticleAdd.Description = "Edita los datos del artículo seleccionado";
            var freshArticle = articleController.GetById(article.Id);
            if (freshArticle != null)
            {
                selectedArticle = freshArticle;
            }
            else
            {
                selectedArticle = article;
            }
            selectedStock = stockController.GetStockByArticuloId(selectedArticle.Id);
            if (selectedStock == null)
            {
                selectedStock = new StockModel { ArticleId = selectedArticle.Id };
            }

            tbArticleCode.Text = selectedArticle.Code;
            cbArticleName.Text = selectedArticle.Name;
            cbArticleDescription.Text = selectedArticle.Description;

            if (selectedArticle.CategoryId.HasValue && selectedArticle.Category != null)
            {
                cbArticleCategory.SelectedItem = selectedArticle.Category.Name;
                LoadSubcategories(selectedArticle.CategoryId.Value);
            }

            if (selectedArticle.SubcategoryId.HasValue && selectedArticle.Subcategory != null)
            {
                cbArticleSubcategory.SelectedItem = selectedArticle.Subcategory.Name;
            }

            tbStockQuantity.Text = selectedStock.Stock?.ToString() ?? "0";

            if (decimal.TryParse(selectedStock.Cost, out decimal cost))
                tbStockCost.Text = cost.ToString("F2");

            tbCostProfit.Text = selectedStock.Profit?.ToString() ?? "0";

            CalculateSellPrice();
        }

        private void SetupControls()
        {
            tbStockQuantity.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbStockQuantity.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);

            tbStockCost.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbStockCost.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);

            tbCostProfit.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbCostProfit.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);

            mepArticleAdd.SaveClick += mepArticleAdd_SaveClick;
            mepArticleAdd.CancelClick += mepArticleAdd_CancelClick;

            cbArticleCategory.SelectedIndexChanged += cbArticleCategory_SelectedIndexChanged;
            cbArticleCategory.KeyPress += (s, e) => Utils.HandleTextBoxInput(s, e, ValidationType.LettersAndNumbers);

            tbStockCost.TextChanged += (s, e) => CalculateSellPrice();
            tbCostProfit.TextChanged += (s, e) => CalculateSellPrice();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = categoryController.GetAll();
                cbArticleCategory.Items.Clear();

                foreach (var category in categories)
                {
                    if (!string.IsNullOrWhiteSpace(category.Name))
                        cbArticleCategory.Items.Add(category.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubcategories(int categoryId)
        {
            try
            {
                var subcategories = subcategoryController.GetSubcategoriesByCategoria(categoryId);
                cbArticleSubcategory.Items.Clear();

                foreach (var subcategory in subcategories)
                {
                    if (!string.IsNullOrWhiteSpace(subcategory.Name))
                        cbArticleSubcategory.Items.Add(subcategory.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar subcategorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbArticleCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbArticleCategory.SelectedItem != null)
            {
                string categoryName = cbArticleCategory.SelectedItem.ToString() ?? "";
                var category = categoryController.GetAll().FirstOrDefault(c => c.Name == categoryName);

                if (category != null)
                {
                    LoadSubcategories(category.Id);
                }
            }
        }

        private void CalculateSellPrice()
        {
            try
            {
                if (decimal.TryParse(tbStockCost.Text, out decimal cost) &&
                    int.TryParse(tbCostProfit.Text, out int profit))
                {
                    decimal sellPrice = cost + (cost * profit / 100);
                    tbSellPrice.Text = sellPrice.ToString("F2");
                }
                else
                {
                    tbSellPrice.Text = "0.00";
                }
            }
            catch
            {
                tbSellPrice.Text = "0.00";
            }
        }

        private bool ValidateFields()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(tbArticleCode.Text))
                errors.Add("Código del artículo");

            if (string.IsNullOrWhiteSpace(cbArticleName.Text))
                errors.Add("Nombre del artículo");

            if (string.IsNullOrWhiteSpace(cbArticleCategory.Text))
                errors.Add("Categoría");

            if (string.IsNullOrWhiteSpace(tbStockQuantity.Text) || !int.TryParse(tbStockQuantity.Text, out int qty) || qty < 0)
                errors.Add("Cantidad de stock (debe ser un número mayor o igual a 0)");

            if (string.IsNullOrWhiteSpace(tbStockCost.Text) || !decimal.TryParse(tbStockCost.Text, out decimal cost) || cost < 0)
                errors.Add("Costo (debe ser un número mayor o igual a 0)");

            if (string.IsNullOrWhiteSpace(tbCostProfit.Text) || !int.TryParse(tbCostProfit.Text, out int profit) || profit < 0)
                errors.Add("Ganancia (debe ser un porcentaje mayor o igual a 0)");

            if (errors.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios o inválidos:\n\n" + string.Join("\n", errors);
                MessageBox.Show(message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepArticleAdd_SaveClick(object? sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string categoryName = cbArticleCategory.Text.Trim();
                var category = categoryController.GetAll().FirstOrDefault(c => c.Name == categoryName);

                if (category == null)
                {
                    var newCategory = new CategoryModel
                    {
                        Name = categoryName
                    };

                    if (!categoryController.Create(newCategory))
                    {
                        MessageBox.Show("Error al crear la nueva categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    category = categoryController.GetAll().FirstOrDefault(c => c.Name == categoryName);
                    if (category == null)
                    {
                        MessageBox.Show("Error al obtener la categoría creada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int? subcategoryId = null;
                if (!string.IsNullOrWhiteSpace(cbArticleSubcategory.Text))
                {
                    string subcategoryName = cbArticleSubcategory.Text.Trim();
                    var subcategory = subcategoryController.GetAll()
                        .FirstOrDefault(s => s.Name == subcategoryName && s.CategoryId == category.Id);

                    if (subcategory == null)
                    {
                        var newSubcategory = new SubcategoryModel
                        {
                            Name = subcategoryName,
                            CategoryId = category.Id
                        };

                        if (!subcategoryController.Create(newSubcategory))
                        {
                            MessageBox.Show("Error al crear la nueva subcategoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        subcategory = subcategoryController.GetAll()
                            .FirstOrDefault(s => s.Name == subcategoryName && s.CategoryId == category.Id);
                    }

                    subcategoryId = subcategory?.Id;
                }

                int originalId = selectedArticle.Id;
                selectedArticle.Code = tbArticleCode.Text.Trim().ToUpper();
                selectedArticle.Name = cbArticleName.Text.Trim();
                selectedArticle.Description = string.IsNullOrWhiteSpace(cbArticleDescription.Text)
                    ? null
                    : cbArticleDescription.Text.Trim();
                selectedArticle.CategoryId = category.Id;
                selectedArticle.SubcategoryId = subcategoryId;

                bool articleSuccess;
                if (selectedArticle.Id == 0)
                    articleSuccess = articleController.Create(selectedArticle);
                else
                    articleSuccess = articleController.Update(selectedArticle);

                if (!articleSuccess)
                {
                    MessageBox.Show("Error al guardar el artículo. El código ya existe o hay un problema con los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedStock?.ArticleId == null || selectedStock.ArticleId == 0)
                {
                    var savedArticle = articleController.GetArticuloByCodigo(selectedArticle.Code);
                    if (savedArticle != null)
                    {
                        selectedArticle.Id = savedArticle.Id;
                        selectedStock = new StockModel { ArticleId = savedArticle.Id };
                    }
                }

                selectedStock.ArticleId = selectedArticle.Id;
                selectedStock.Stock = int.TryParse(tbStockQuantity.Text, out int stock) ? stock : 0;
                selectedStock.Cost = decimal.TryParse(tbStockCost.Text, out decimal cost) ? cost.ToString("F2") : "0.00";
                selectedStock.Profit = int.TryParse(tbCostProfit.Text, out int profit) ? profit : 0;

                // Guardar stock
                bool stockSuccess;
                if (selectedStock.Id == 0)
                    stockSuccess = stockController.Create(selectedStock);
                else
                    stockSuccess = stockController.Update(selectedStock);

                if (!stockSuccess)
                {
                    MessageBox.Show("Artículo guardado, pero hubo un error al guardar el stock.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Artículo guardado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Registrar actividad usando el helper
                string action = originalId == 0 ? ActivityActions.Create : ActivityActions.Update;
                ActivityLogger.LogActivity(action, ActivityModules.Articles, articleId: selectedArticle.Id);
                
                ReturnToArticlesView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el artículo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepArticleAdd_CancelClick(object? sender, EventArgs e)
        {
            ReturnToArticlesView();
        }

        private void ReturnToArticlesView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpSellsArticles);
            }
        }
    }
}
