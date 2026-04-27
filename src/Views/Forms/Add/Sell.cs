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
    public partial class Sell : UserControl
    {
        private readonly SellService _sellController;
        private readonly ClientService _clientController;
        private readonly ArticleService _articleController;
        private Main? _formMain;
        private TabPage _parentTabPage;
        private SellModel? _currentSell;
        private bool _isEditMode;

        public Sell(SellModel? sell = null, TabPage? parentTabPage = null)
        {
            _sellController = new SellService();
            _clientController = new ClientService();
            _articleController = new ArticleService();
            _formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
            _parentTabPage = parentTabPage ?? _formMain?.tpSellsList ?? new TabPage();
            _currentSell = sell;
            _isEditMode = sell != null;

            InitializeComponent();
            SetupControls();
            LoadClients();

            if (sell != null)
            {
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
                    var client = _clientController.GetById(sell.ClientId.Value);
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
                        var article = _articleController.GetById(detail.ArticleId.Value);
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
                MessageBox.Show($"Error al cargar los datos de la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                var clients = _sellController.GetAllClients();

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

        private List<(int ArticleId, int Quantity, decimal UnitPrice, string ArticleName)> GetArticleItemsData()
        {
            var items = new List<(int ArticleId, int Quantity, decimal UnitPrice, string ArticleName)>();
            var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();

            foreach (var item in articleItems)
            {
                var cbArticle = item.Controls.Find("cbArticleName", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
                var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                if (cbArticle?.SelectedIndex > 0 && tbUnitPrice != null && tbQuantity != null)
                {
                    var article = _articleController.GetByName(cbArticle.Text);
                    if (article != null &&
                        decimal.TryParse(tbUnitPrice.Text, out decimal price) &&
                        int.TryParse(tbQuantity.Text, out int quantity))
                    {
                        items.Add((article.Id, quantity, price, article.Name));
                    }
                }
            }

            return items;
        }

        private void mepSellAdd_SaveClick(object sender, EventArgs e)
        {
            try
            {
                var clients = _sellController.GetAllClients();
                var selectedClient = clients.FirstOrDefault(c => c.Name == cbClient.Text);

                if (selectedClient == null)
                {
                    MessageBox.Show("Cliente no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal.TryParse(tbSubtotal.Text, out decimal subtotal);
                decimal.TryParse(tbDiscount.Text, out decimal discountPercent);

                var articleItems = GetArticleItemsData();
                var validationResult = _sellController.ValidateSell(
                    selectedClient.Id,
                    articleItems,
                    _isEditMode,
                    _currentSell
                );

                if (!validationResult.IsValid)
                {
                    MessageBox.Show("Se encontraron los siguientes errores:\n\n" + string.Join("\n", validationResult.Errors),
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var details = articleItems.Select(i => (i.ArticleId, i.Quantity)).ToList();

                var result = _sellController.SaveSell(
                    selectedClient.Id,
                    subtotal,
                    discountPercent,
                    details,
                    _isEditMode,
                    _currentSell
                );

                if (result.Success)
                {
                    string action = _isEditMode ? ActivityActions.Update : ActivityActions.Create;
                    ActivityLogger.LogActivity(action, ActivityModules.Sells, result.SellId, result.ClientId);

                    string message = _isEditMode ? "Venta actualizada correctamente." : "Venta registrada correctamente.";
                    MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnToSellView();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Error al guardar la venta", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepSellAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToSellView();
        }

        private void ReturnToSellView()
        {
            if (_parentTabPage != null && _formMain != null)
            {
                _formMain.RestoreTabPage(_parentTabPage);
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

        private void cbClient_DropDown(object sender, EventArgs e)
        {
            LoadClients();
        }
    }
}