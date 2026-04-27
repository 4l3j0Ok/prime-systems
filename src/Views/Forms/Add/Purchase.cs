using PrimeSystems.Services;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class Purchase : UserControl
    {
        private readonly PurchaseService _purchaseController;
        private readonly SupplierService _supplierController;
        private readonly ArticleService _articleController;
        private Main? _formMain;
        private TabPage _parentTabPage;
        private PurchaseModel? _currentPurchase;
        private bool _isEditMode;
        private bool _isLoadingData;

        public Purchase(PurchaseModel? purchase = null, TabPage? parentTabPage = null)
        {
            _purchaseController = new PurchaseService();
            _supplierController = new SupplierService();
            _articleController = new ArticleService();
            _formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
            _parentTabPage = parentTabPage ?? _formMain?.tpPurchasesList ?? new TabPage();
            _currentPurchase = purchase;
            _isEditMode = purchase != null;

            InitializeComponent();
            SetupControls();
            LoadSuppliers();

            if (purchase != null)
            {
                LoadPurchaseData(purchase);
            }
        }

        private void SetupControls()
        {
            tbTotal.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbTotal.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
        }

        private void LoadPurchaseData(PurchaseModel purchase)
        {
            try
            {
                _isLoadingData = true;

                if (purchase.Supplier != null)
                {
                    LoadSuppliers();
                    cbProvider.Text = purchase.Supplier.Name;
                }
                else if (purchase.SupplierId.HasValue)
                {
                    var supplier = _supplierController.GetById(purchase.SupplierId.Value);
                    if (supplier != null)
                    {
                        LoadSuppliers();
                        cbProvider.Text = supplier.Name;
                    }
                }

                var details = purchase.Detail?.ToList()
                    ?? _purchaseController.GetById(purchase.Id)?.Detail?.ToList()
                    ?? new List<PurchaseDetailModel>();

                foreach (var detail in details)
                {
                    var articleItem = new Controls.SupplierArticleItem();
                    articleItem.Dock = DockStyle.Top;

                    articleItem.tbArticleUnitPrice.TextChanged += CalculateTotals;
                    articleItem.tbArticleQuantity.TextChanged += CalculateTotals;
                    articleItem.btnRemove.Click += CalculateTotals;

                    gbArticlesData.Controls.Add(articleItem);
                    gbArticlesData.Controls.SetChildIndex(articleItem, 1);

                    if (detail.ArticleId.HasValue)
                    {
                        articleItem.SetArticleById(detail.ArticleId.Value);
                    }
                    else if (detail.Article != null)
                    {
                        var article = _articleController.GetByName(detail.Article.Name);
                        if (article != null)
                        {
                            articleItem.SetArticleById(article.Id);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(detail.Description))
                    {
                        var article = _articleController.GetByName(detail.Description);
                        if (article != null)
                        {
                            articleItem.SetArticleById(article.Id);
                        }
                    }

                    var tbUnitPrice = articleItem.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                    var tbQuantity = articleItem.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (tbUnitPrice != null && !string.IsNullOrWhiteSpace(detail.UnitPrice))
                    {
                        tbUnitPrice.Text = detail.UnitPrice;
                    }

                    if (tbQuantity != null && !string.IsNullOrWhiteSpace(detail.Quantity))
                    {
                        tbQuantity.Text = detail.Quantity;
                    }
                }

                if (!string.IsNullOrWhiteSpace(purchase.Total))
                {
                    tbTotal.Text = purchase.Total;
                }

                _isLoadingData = false;
                CalculateTotals(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _isLoadingData = false;
                MessageBox.Show($"Error al cargar los datos de la compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _purchaseController.GetAllSuppliers();

                cbProvider.Items.Clear();
                cbProvider.Items.Add("-- Seleccione un proveedor --");

                foreach (var supplier in suppliers)
                {
                    cbProvider.Items.Add(supplier.Name);
                }

                if (cbProvider.Items.Count > 0 && string.IsNullOrWhiteSpace(cbProvider.Text))
                    cbProvider.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals(object? sender, EventArgs e)
        {
            if (_isLoadingData)
                return;

            try
            {
                decimal total = 0;
                var articleItems = gbArticlesData.Controls.OfType<Controls.SupplierArticleItem>().ToList();

                foreach (var item in articleItems)
                {
                    var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (tbUnitPrice != null && tbQuantity != null)
                    {
                        if (decimal.TryParse(tbUnitPrice.Text, out decimal price) &&
                            int.TryParse(tbQuantity.Text, out int quantity))
                        {
                            total += price * quantity;
                        }
                    }
                }

                tbTotal.Text = total.ToString("F2");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al calcular totales: {ex.Message}");
            }
        }

        private List<(int? ArticleId, string Description, string UnitPrice, string Quantity)> GetArticleItemsData()
        {
            var items = new List<(int? ArticleId, string Description, string UnitPrice, string Quantity)>();
            var articleItems = gbArticlesData.Controls.OfType<Controls.SupplierArticleItem>().ToList();

            foreach (var item in articleItems)
            {
                var articleId = item.GetSelectedArticleId();
                var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                if (articleId.HasValue && tbUnitPrice != null && tbQuantity != null)
                {
                    var article = _articleController.GetById(articleId.Value);
                    items.Add((
                        articleId,
                        article?.Name ?? "",
                        tbUnitPrice.Text,
                        tbQuantity.Text
                    ));
                }
            }

            return items;
        }

        private void mepPurchaseAdd_SaveClick(object sender, EventArgs e)
        {
            try
            {
                var suppliers = _purchaseController.GetAllSuppliers();
                var selectedSupplier = suppliers.FirstOrDefault(s => s.Name == cbProvider.Text);

                if (selectedSupplier == null)
                {
                    MessageBox.Show("Proveedor no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal.TryParse(tbTotal.Text, out decimal total);
                var articleItems = GetArticleItemsData();

                var validationResult = _purchaseController.ValidatePurchase(
                    selectedSupplier.Id,
                    articleItems,
                    total
                );

                if (!validationResult.IsValid)
                {
                    MessageBox.Show("Se encontraron los siguientes errores:\n\n" + string.Join("\n", validationResult.Errors),
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = _purchaseController.SavePurchase(
                    selectedSupplier.Id,
                    total,
                    articleItems,
                    _isEditMode,
                    _currentPurchase
                );

                if (result.Success)
                {
                    string action = _isEditMode ? ActivityActions.Update : ActivityActions.Create;
                    ActivityLogger.LogActivity(action, ActivityModules.Purchases, purchaseId: result.PurchaseId, supplierId: result.SupplierId);

                    string message = _isEditMode ? "Compra actualizada correctamente." : "Compra registrada correctamente.";
                    MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnToPurchaseView();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Error al guardar la compra", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepPurchaseAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToPurchaseView();
        }

        private void ReturnToPurchaseView()
        {
            if (_parentTabPage != null && _formMain != null)
            {
                _formMain.RestoreTabPage(_parentTabPage);
            }
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            SupplierArticleItem newArticleItem = new Controls.SupplierArticleItem();
            newArticleItem.Dock = DockStyle.Top;
            gbArticlesData.Controls.Add(newArticleItem);
            gbArticlesData.Controls.SetChildIndex(newArticleItem, 1);
            newArticleItem.tbArticleUnitPrice.TextChanged += CalculateTotals;
            newArticleItem.tbArticleQuantity.TextChanged += CalculateTotals;
            newArticleItem.btnRemove.Click += CalculateTotals;
        }

        private void cbProvider_DropDown(object sender, EventArgs e)
        {
            LoadSuppliers();
        }
    }
}