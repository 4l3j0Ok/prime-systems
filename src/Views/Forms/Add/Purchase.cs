using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class Purchase : UserControl
    {
        private PurchaseController purchaseController;
        private SupplierController supplierController;
        private PurchaseDetailController purchaseDetailController;
        private ArticleController articleController;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
        private TabPage ParentTabPage = null;
        private PurchaseModel? currentPurchase;
        private bool isEditMode = false;
        private bool isLoadingData = false;

        public Purchase(PurchaseModel? purchase = null, TabPage? parentTabPage = null)
        {
            if (parentTabPage != null)
                ParentTabPage = parentTabPage;
            else
                ParentTabPage = formMain?.tpPurchasesList ?? new TabPage();
            purchaseController = new PurchaseController();
            supplierController = new SupplierController();
            purchaseDetailController = new PurchaseDetailController();
            articleController = new ArticleController();
            InitializeComponent();
            SetupControls();

            if (purchase != null)
            {
                currentPurchase = purchase;
                isEditMode = true;
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
                isLoadingData = true;

                if (purchase.Supplier != null)
                {
                    LoadSuppliers();
                    cbProvider.Text = purchase.Supplier.Name;
                }
                else if (purchase.SupplierId.HasValue)
                {
                    var supplier = supplierController.GetById(purchase.SupplierId.Value);
                    if (supplier != null)
                    {
                        LoadSuppliers();
                        cbProvider.Text = supplier.Name;
                    }
                }

                List<PurchaseDetailModel> details;
                if (purchase.Detail != null && purchase.Detail.Any())
                {
                    details = purchase.Detail.ToList();
                }
                else
                {
                    details = purchaseDetailController.GetDetallesByCompra(purchase.Id);
                }

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
                        var article = articleController.GetByName(detail.Article.Name);
                        if (article != null)
                        {
                            articleItem.SetArticleById(article.Id);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(detail.Description))
                    {
                        var article = articleController.GetByName(detail.Description);
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

                isLoadingData = false;
                CalculateTotals(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                MessageBox.Show($"Error al cargar los datos de la compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = supplierController.GetAll();

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
            if (isLoadingData)
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

        private bool ValidateFields()
        {
            List<string> errors = new List<string>();

            if (cbProvider.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(cbProvider.Text) || cbProvider.Text.StartsWith("--"))
            {
                errors.Add("Debe seleccionar un proveedor");
            }

            var articleItems = gbArticlesData.Controls.OfType<Controls.SupplierArticleItem>().ToList();
            if (articleItems.Count == 0)
            {
                errors.Add("Debe agregar al menos un artículo");
            }

            foreach (var item in articleItems)
            {
                var articleId = item.GetSelectedArticleId();
                var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                if (!articleId.HasValue)
                {
                    errors.Add("Todos los artículos deben estar seleccionados");
                    break;
                }

                if (string.IsNullOrWhiteSpace(tbUnitPrice?.Text) || !decimal.TryParse(tbUnitPrice.Text, out decimal price) || price <= 0)
                {
                    errors.Add("Todos los artículos deben tener un precio unitario válido mayor a 0");
                    break;
                }

                if (string.IsNullOrWhiteSpace(tbQuantity?.Text) || !int.TryParse(tbQuantity.Text, out int qty) || qty <= 0)
                {
                    errors.Add("Todos los artículos deben tener una cantidad válida mayor a 0");
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(tbTotal.Text) || !decimal.TryParse(tbTotal.Text, out decimal total) || total <= 0)
            {
                errors.Add("El total debe ser mayor a 0");
            }

            if (errors.Count > 0)
            {
                string message = "Se encontraron los siguientes errores:\n\n" + string.Join("\n", errors);
                MessageBox.Show(message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepPurchaseAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                var suppliers = supplierController.GetAll();
                var selectedSupplier = suppliers.FirstOrDefault(s => s.Name == cbProvider.Text);

                if (selectedSupplier == null)
                {
                    MessageBox.Show("Proveedor no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PurchaseModel purchase;

                if (isEditMode && currentPurchase != null)
                {
                    purchase = currentPurchase;
                    purchase.UserId = Session.CurrentUser?.Id;
                    purchase.SupplierId = selectedSupplier.Id;
                    purchase.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    purchase = new PurchaseModel
                    {
                        UserId = Session.CurrentUser?.Id,
                        SupplierId = selectedSupplier.Id,
                        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }

                purchase.Subtotal = tbTotal.Text;
                purchase.Discount = "0.00";
                purchase.Total = tbTotal.Text;

                var details = new List<PurchaseDetailModel>();
                var articleItems = gbArticlesData.Controls.OfType<Controls.SupplierArticleItem>().ToList();

                foreach (var item in articleItems)
                {
                    var articleId = item.GetSelectedArticleId();
                    var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (articleId.HasValue && tbUnitPrice != null && tbQuantity != null)
                    {
                        var article = articleController.GetById(articleId.Value);

                        var detail = new PurchaseDetailModel
                        {
                            ArticleId = articleId.Value,
                            Description = article?.Name ?? "",
                            UnitPrice = tbUnitPrice.Text,
                            Quantity = tbQuantity.Text
                        };

                        details.Add(detail);
                    }
                }

                bool success;
                if (isEditMode && currentPurchase != null)
                {
                    // Set Title and Description for update
                    purchase.Title = $"Compra #{purchase.Id}";
                    purchase.Description = $"Proveedor: {selectedSupplier.Name} | Total: ${purchase.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                    success = purchaseController.UpdateCompraConDetalles(purchase, details);
                }
                else
                {
                    // For new purchases, save first to get ID
                    success = purchaseController.CreateCompraConDetalles(purchase, details);
                    
                    if (success)
                    {
                        // Update with Title and Description
                        purchase.Title = $"Compra #{purchase.Id}";
                        purchase.Description = $"Proveedor: {selectedSupplier.Name} | Total: ${purchase.Total} | Fecha: {DateTime.Now:dd/MM/yyyy}";
                        purchaseController.Update(purchase);
                    }
                }

                if (success)
                {
                    string message = isEditMode ? "Compra actualizada correctamente." : "Compra registrada correctamente.";
                    MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    int purchaseId = isEditMode ? currentPurchase.Id : purchase.Id;
                    string action = isEditMode ? ActivityActions.Update : ActivityActions.Create;
                    ActivityLogger.LogActivity(action, ActivityModules.Purchases, purchaseId: purchaseId, supplierId: selectedSupplier.Id);
                    
                    ReturnToPurchaseView();
                }
                else
                {
                    string message = isEditMode ? "Error al actualizar la compra." : "Error al registrar la compra.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepPurchaseAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToPurchaseView();
        }

        private void ReturnToPurchaseView()
        {
            if (ParentTabPage != null && formMain != null)
            {
                formMain.RestoreTabPage(ParentTabPage);
            }
        }

        private void cbProvider_DropDown(object sender, EventArgs e)
        {
            LoadSuppliers();
        }
    }
}
