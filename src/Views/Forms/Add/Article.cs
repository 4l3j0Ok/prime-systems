using PrimeSystems.Services;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class Article : UserControl
    {
        private readonly ArticleService _articleController;
        private readonly CategoryService _categoryController;
        private readonly SubcategoryService _subcategoryController;
        private readonly StockService _stockController;
        private ArticleModel _selectedArticle;
        private StockModel? _selectedStock;
        private Main? _formMain;
        private bool _isEditMode;

        public Article(ArticleModel? article = null)
        {
            _articleController = new ArticleService();
            _categoryController = new CategoryService();
            _subcategoryController = new SubcategoryService();
            _stockController = new StockService();
            _formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
            _isEditMode = article != null;

            InitializeComponent();
            SetupControls();
            LoadCategories();

            if (article == null)
            {
                _selectedArticle = new ArticleModel();
                _selectedStock = new StockModel();
                return;
            }

            mepArticleAdd.Title = "Modificar Artículo";
            mepArticleAdd.Description = "Edita los datos del artículo seleccionado";

            var freshArticle = _articleController.GetById(article.Id);
            _selectedArticle = freshArticle ?? article;
            _selectedStock = _stockController.GetStockByArticuloId(_selectedArticle.Id);

            if (_selectedStock == null)
            {
                _selectedStock = new StockModel { ArticleId = _selectedArticle.Id };
            }

            tbArticleCode.Text = _selectedArticle.Code;
            cbArticleName.Text = _selectedArticle.Name;
            cbArticleDescription.Text = _selectedArticle.Description;

            if (_selectedArticle.CategoryId.HasValue && _selectedArticle.Category != null)
            {
                cbArticleCategory.SelectedItem = _selectedArticle.Category.Name;
                LoadSubcategories(_selectedArticle.CategoryId.Value);
            }

            if (_selectedArticle.SubcategoryId.HasValue && _selectedArticle.Subcategory != null)
            {
                cbArticleSubcategory.SelectedItem = _selectedArticle.Subcategory.Name;
            }

            tbStockQuantity.Text = _selectedStock.Stock?.ToString() ?? "0";

            if (decimal.TryParse(_selectedStock.Cost, out decimal cost))
                tbStockCost.Text = cost.ToString("F2");

            tbCostProfit.Text = _selectedStock.Profit?.ToString() ?? "0";

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
                var categories = _articleController.GetAllCategories();
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
                var subcategories = _articleController.GetSubcategoriesByCategory(categoryId);
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
                var category = _categoryController.GetAll().FirstOrDefault(c => c.Name == categoryName);

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
                    decimal sellPrice = _articleController.CalculateSellPrice(cost, profit);
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

        private void mepArticleAdd_SaveClick(object? sender, EventArgs e)
        {
            int.TryParse(tbStockQuantity.Text, out int stockQty);
            decimal.TryParse(tbStockCost.Text, out decimal cost);
            int.TryParse(tbCostProfit.Text, out int profit);

            var validationResult = _articleController.ValidateArticle(
                tbArticleCode.Text.Trim(),
                cbArticleName.Text.Trim(),
                cbArticleCategory.Text,
                stockQty,
                cost,
                profit
            );

            if (!validationResult.IsValid)
            {
                MessageBox.Show("Los siguientes campos son obligatorios o inválidos:\n\n" + string.Join("\n", validationResult.Errors),
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var result = _articleController.SaveArticle(
                    _selectedArticle.Id,
                    tbArticleCode.Text.Trim(),
                    cbArticleName.Text.Trim(),
                    cbArticleDescription.Text,
                    cbArticleCategory.Text.Trim(),
                    cbArticleSubcategory.Text,
                    stockQty,
                    cost,
                    profit
                );

                if (result.Success)
                {
                    string action = _isEditMode ? ActivityActions.Update : ActivityActions.Create;
                    ActivityLogger.LogActivity(action, ActivityModules.Articles, result.ArticleId);

                    MessageBox.Show("Artículo guardado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ReturnToArticlesView();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Error al guardar el artículo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (_formMain != null)
            {
                _formMain.RestoreTabPage(_formMain.tpArticles);
            }
        }
    }
}