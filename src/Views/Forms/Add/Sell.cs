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
    public partial class Sell : UserControl
    {
        private SellController sellController;
        private ClientController clientController;
        private SellDetailController sellDetailController;
        private ArticleController articleController;
        private StockController stockController;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
        private TabPage ParentTabPage;
        private SellModel? currentSell;
        private bool isEditMode = false;

        public Sell(SellModel? sell = null, TabPage? parentTabPage = null)
        {
            if (parentTabPage != null)
                ParentTabPage = parentTabPage;
            else
                ParentTabPage = formMain?.tpSellsList ?? new TabPage();
            sellController = new SellController();
            clientController = new ClientController();
            sellDetailController = new SellDetailController();
            articleController = new ArticleController();
            stockController = new StockController();
            InitializeComponent();
            SetupControls();

            if (sell != null)
            {
                currentSell = sell;
                isEditMode = true;
                LoadSellData(sell);
            }
        }

        private void SetupControls()
        {
            tbDiscount.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbDiscount.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
            tbDiscount.TextChanged += CalculateTotals;
        }

        private void LoadSellData(SellModel sell)
        {
            try
            {
                if (sell.Client != null)
                {
                    LoadClients();
                    cbClient.Text = sell.Client.Name;
                }
                else if (sell.ClientId.HasValue)
                {
                    var client = clientController.GetById(sell.ClientId.Value);
                    if (client != null)
                    {
                        LoadClients();
                        cbClient.Text = client.Name;
                    }
                }
                if (!string.IsNullOrWhiteSpace(sell.Discount) && decimal.TryParse(sell.Discount, out decimal discountAmount))
                {
                    if (!string.IsNullOrWhiteSpace(sell.Subtotal) && decimal.TryParse(sell.Subtotal, out decimal subtotal) && subtotal > 0)
                    {
                        decimal discountPercent = (discountAmount / subtotal) * 100;
                        tbDiscount.Text = discountPercent.ToString("F2");
                    }
                }
                foreach (var detail in sell.Detail)
                {
                    var articleItem = new Controls.ArticleItem();
                    articleItem.Dock = DockStyle.Top;
                    articleItem.cbArticleName.SelectedIndexChanged += (s, ev) => CalculateTotals(s, ev);
                    articleItem.tbArticleUnitPrice.TextChanged += (s, ev) => CalculateTotals(s, ev);
                    articleItem.tbArticleQuantity.TextChanged += (s, ev) => CalculateTotals(s, ev);
                    gbArticlesData.Controls.Add(articleItem);
                    gbArticlesData.Controls.SetChildIndex(articleItem, 0);
                    if (detail.Article != null)
                    {
                        articleItem.cbArticleName.Items.Add(detail.Article.Name);
                        articleItem.cbArticleName.SelectedIndex = articleItem.cbArticleName.Items.Count - 1;
                    }
                    else if (detail.ArticleId.HasValue)
                    {
                        var article = articleController.GetById(detail.ArticleId.Value);
                        if (article != null)
                        {
                            articleItem.cbArticleName.Items.Add(article.Name);
                            articleItem.cbArticleName.SelectedIndex = articleItem.cbArticleName.Items.Count - 1;
                        }
                    }
                    if (detail.Quantity.HasValue)
                        articleItem.tbArticleQuantity.Text = detail.Quantity.Value.ToString();
                }
                CalculateTotals(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                MessageBox.Show(
                    $"Error al cargar los datos de la venta:",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            var newArticleItem = new Controls.ArticleItem();
            newArticleItem.Dock = DockStyle.Top;
            newArticleItem.cbArticleName.SelectedIndexChanged += (s, ev) => CalculateTotals(s, ev);
            newArticleItem.tbArticleUnitPrice.TextChanged += (s, ev) => CalculateTotals(s, ev);
            newArticleItem.tbArticleQuantity.TextChanged += (s, ev) => CalculateTotals(s, ev);
            gbArticlesData.Controls.Add(newArticleItem);
            gbArticlesData.Controls.SetChildIndex(newArticleItem, 0);
        }

        private void LoadClients()
        {
            try
            {
                var clients = clientController.GetAll();

                cbClient.Items.Clear();
                cbClient.Items.Add("-- Seleccione un cliente --");

                foreach (var client in clients)
                {
                    cbClient.Items.Add(client.Name);
                }

                if (cbClient.Items.Count > 0 && string.IsNullOrWhiteSpace(cbClient.Text))
                    cbClient.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals(object? sender, EventArgs e)
        {
            try
            {
                decimal subtotal = 0;
                var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();

                foreach (var item in articleItems)
                {
                    var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (tbUnitPrice != null && tbQuantity != null)
                    {
                        if (decimal.TryParse(tbUnitPrice.Text, out decimal price) &&
                            int.TryParse(tbQuantity.Text, out int quantity))
                        {
                            subtotal += price * quantity;
                        }
                    }
                }

                tbSubtotal.Text = subtotal.ToString("F2");

                decimal discountAmount = 0;
                if (decimal.TryParse(tbDiscount.Text, out decimal discountPercent) && discountPercent > 0)
                {
                    discountAmount = subtotal * (discountPercent / 100);
                }

                decimal total = subtotal - discountAmount;
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
            if (cbClient.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(cbClient.Text) || cbClient.Text.StartsWith("--"))
            {
                errors.Add("Debe seleccionar un cliente");
            }
            var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();
            if (articleItems.Count == 0)
            {
                errors.Add("Debe agregar al menos un artículo");
            }
            foreach (var item in articleItems)
            {
                var cbArticle = item.Controls.Find("cbArticleName", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
                var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                if (cbArticle == null || cbArticle.SelectedIndex < 0)
                {
                    errors.Add("Todos los artículos deben tener un nombre seleccionado");
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
                var article = articleController.GetByName(cbArticle.Text);
                if (article != null)
                {
                    var stock = stockController.GetStockByArticuloId(article.Id);
                    if (stock != null)
                    {
                        int availableStock = stock.Stock ?? 0;
                        int requestedQty = int.Parse(tbQuantity.Text);
                        if (isEditMode)
                        {
                            var originalDetail = currentSell.Detail?.FirstOrDefault(d => d.ArticleId == article.Id);
                            if (originalDetail != null && originalDetail.Quantity.HasValue)
                            {
                                availableStock += originalDetail.Quantity.Value;
                            }
                        }
                        if (requestedQty > availableStock)
                        {
                            errors.Add($"Stock insuficiente para '{cbArticle.Text}'. Disponible: {availableStock}, Solicitado: {requestedQty}");
                        }
                    }
                }
            }
            if (errors.Count > 0)
            {
                string message = "Se encontraron los siguientes errores:\n\n" + string.Join("\n", errors);
                MessageBox.Show(message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void mepSellAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
            try
            {
                var clients = clientController.GetAll();
                var selectedClient = clients.FirstOrDefault(c => c.Name == cbClient.Text);

                if (selectedClient == null)
                {
                    MessageBox.Show("Cliente no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SellModel sell;
                if (isEditMode)
                {
                    sell = currentSell;
                    sell.UserId = Session.CurrentUser?.Id;
                    sell.ClientId = selectedClient.Id;
                    sell.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    sell = new SellModel
                    {
                        UserId = Session.CurrentUser?.Id,
                        ClientId = selectedClient.Id,
                        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
                sell.Subtotal = tbSubtotal.Text;
                sell.Discount = decimal.TryParse(tbDiscount.Text, out decimal discPercent)
                    ? (decimal.Parse(tbSubtotal.Text) * (discPercent / 100)).ToString("F2")
                    : "0.00";
                sell.Total = tbTotal.Text;

                var details = new List<SellDetailModel>();
                var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();

                foreach (var item in articleItems)
                {
                    var cbArticle = item.Controls.Find("cbArticleName", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (cbArticle != null && tbQuantity != null)
                    {
                        int quantity = int.Parse(tbQuantity.Text);
                        var article = articleController.GetByName(cbArticle.Text);
                        var detail = new SellDetailModel
                        {
                            ArticleId = article?.Id,
                            Quantity = quantity
                        };
                        details.Add(detail);
                    }
                }
                bool success;
                if (isEditMode) success = sellController.UpdateVentaConDetalles(sell, details);
                else success = sellController.CreateVentaConDetalles(sell, details);

                if (success)
                {
                    string message = isEditMode ? "Venta actualizada correctamente." : "Venta registrada correctamente.";
                    MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int sellId = isEditMode ? currentSell.Id : sell.Id;
                    string action = isEditMode ? "Actualizó una venta" : "Registró una nueva venta";
                    ActivityLogger.LogActivity(action, ActivityModules.Sells, sellId: sellId, clientId: selectedClient.Id);
                    ReturnToSellView();
                }
                else
                {
                    string message = isEditMode ? "Error al actualizar la venta." : "Error al registrar la venta.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mepSellAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToSellView();
        }
        private void ReturnToSellView()
        {
            if (ParentTabPage != null && formMain != null)
            {
                formMain.RestoreTabPage(ParentTabPage);
            }
        }
        private void cbClient_DropDown(object sender, EventArgs e)
        {
            LoadClients();
        }
    }
}
