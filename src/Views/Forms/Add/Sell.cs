using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Controls;
using System;
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
        private bool isLoadingData = false; // Para evitar cálculos durante la carga inicial

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

            // Si se recibe una venta, cargar sus datos
            if (sell != null)
            {
                currentSell = sell;
                isEditMode = true;
                LoadSellData(sell);
            }
        }

        private void SetupControls()
        {
            // Configurar validación de campos
            tbDiscount.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbDiscount.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
            // Configurar cálculo automático de totales cuando cambia el descuento
            tbDiscount.TextChanged += CalculateTotals;
        }

        private void LoadSellData(SellModel sell)
        {
            try
            {
                isLoadingData = true; // Deshabilitar cálculos automáticos durante la carga

                // Cargar el cliente
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

                // Cargar el descuento desde el modelo de venta
                if (!string.IsNullOrWhiteSpace(sell.Discount) && decimal.TryParse(sell.Discount, out decimal discountAmount))
                {
                    // Calcular el porcentaje de descuento basado en el subtotal
                    if (!string.IsNullOrWhiteSpace(sell.Subtotal) && decimal.TryParse(sell.Subtotal, out decimal subtotal) && subtotal > 0)
                    {
                        decimal discountPercent = (discountAmount / subtotal) * 100;
                        tbDiscount.Text = discountPercent.ToString("F2");
                    }
                }

                // Cargar los detalles de la venta
                List<SellDetailModel> details;
                if (sell.Detail != null && sell.Detail.Any())
                {
                    details = sell.Detail.ToList();
                }
                else
                {
                    // Si no están cargados los detalles, obtenerlos de la base de datos
                    details = sellDetailController.GetDetallesByVenta(sell.Id);
                }

                // Cargar los artículos
                foreach (var detail in details)
                {
                    var articleItem = new Controls.ArticleItem();
                    articleItem.Dock = DockStyle.Top;

                    // Suscribir eventos
                    articleItem.cbArticleName.SelectedIndexChanged += (s, ev) => CalculateTotals(s, ev);
                    articleItem.tbArticleUnitPrice.TextChanged += (s, ev) => CalculateTotals(s, ev);
                    articleItem.tbArticleQuantity.TextChanged += (s, ev) => CalculateTotals(s, ev);

                    gbArticlesData.Controls.Add(articleItem);
                    gbArticlesData.Controls.SetChildIndex(articleItem, 0);

                    // Cargar datos del artículo en el ArticleItem
                    if (detail.Article != null)
                    {
                        // Si el artículo está cargado, usar su nombre
                        articleItem.cbArticleName.Items.Add(detail.Article.Name);
                        articleItem.cbArticleName.SelectedIndex = articleItem.cbArticleName.Items.Count - 1;
                    }
                    else if (detail.ArticleId.HasValue)
                    {
                        // Si no está cargado, buscarlo por ID
                        var article = articleController.GetById(detail.ArticleId.Value);
                        if (article != null)
                        {
                            articleItem.cbArticleName.Items.Add(article.Name);
                            articleItem.cbArticleName.SelectedIndex = articleItem.cbArticleName.Items.Count - 1;
                        }
                    }

                    // Cargar cantidad
                    if (detail.Quantity.HasValue)
                    {
                        articleItem.tbArticleQuantity.Text = detail.Quantity.Value.ToString();
                    }

                    // El precio unitario se cargará automáticamente al seleccionar el artículo
                    // o se puede calcular desde el subtotal total y las cantidades si es necesario
                }

                isLoadingData = false; // Habilitar cálculos automáticos

                // Recalcular totales para mostrar los valores correctos
                CalculateTotals(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                MessageBox.Show($"Error al cargar los datos de la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // No recalcular si estamos cargando datos iniciales
            if (isLoadingData)
                return;

            try
            {
                decimal subtotal = 0;

                // Obtener todos los ArticleItem del contenedor
                var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();

                // Calcular el subtotal sumando precio * cantidad de cada artículo
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

                // Mostrar el subtotal
                tbSubtotal.Text = subtotal.ToString("F2");

                // Calcular el descuento sobre el subtotal total
                decimal discountAmount = 0;
                if (decimal.TryParse(tbDiscount.Text, out decimal discountPercent) && discountPercent > 0)
                {
                    discountAmount = subtotal * (discountPercent / 100);
                }

                // Calcular el total restando el descuento del subtotal
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

            // Validar cliente seleccionado
            if (cbClient.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(cbClient.Text) || cbClient.Text.StartsWith("--"))
            {
                errors.Add("Debe seleccionar un cliente");
            }

            // Validar que haya al menos un artículo
            var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();
            if (articleItems.Count == 0)
            {
                errors.Add("Debe agregar al menos un artículo");
            }

            // Validar cada artículo
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

                // Validar stock disponible
                var article = articleController.GetByName(cbArticle.Text);
                if (article != null)
                {
                    var stock = stockController.GetStockByArticuloId(article.Id);
                    if (stock != null)
                    {
                        int availableStock = stock.Stock ?? 0;
                        int requestedQty = int.Parse(tbQuantity.Text);

                        // Si estamos editando, considerar la cantidad original para el cálculo
                        if (isEditMode && currentSell != null)
                        {
                            var originalDetail = currentSell.Detail?.FirstOrDefault(d => d.ArticleId == article.Id);
                            if (originalDetail != null && originalDetail.Quantity.HasValue)
                            {
                                // Agregar la cantidad original al stock disponible ya que será devuelta
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
                // Obtener el cliente seleccionado
                var clients = clientController.GetAll();
                var selectedClient = clients.FirstOrDefault(c => c.Name == cbClient.Text);

                if (selectedClient == null)
                {
                    MessageBox.Show("Cliente no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear o actualizar la venta
                SellModel sell;
                int originalId = 0;

                if (isEditMode && currentSell != null)
                {
                    // Modo edición: usar la venta existente
                    originalId = currentSell.Id;
                    sell = currentSell;
                    sell.UserId = Session.CurrentUser?.Id;
                    sell.ClientId = selectedClient.Id;
                    sell.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    // Modo creación: crear nueva venta
                    sell = new SellModel
                    {
                        UserId = Session.CurrentUser?.Id,
                        ClientId = selectedClient.Id,
                        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }

                // Calcular el subtotal total y el descuento global
                decimal subtotalGlobal = 0;
                var articleItems = gbArticlesData.Controls.OfType<Controls.ArticleItem>().ToList();

                foreach (var item in articleItems)
                {
                    var tbUnitPrice = item.Controls.Find("tbArticleUnitPrice", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (tbUnitPrice != null && tbQuantity != null)
                    {
                        decimal unitPrice = decimal.Parse(tbUnitPrice.Text);
                        int quantity = int.Parse(tbQuantity.Text);
                        subtotalGlobal += unitPrice * quantity;
                    }
                }

                // Calcular el descuento global
                decimal discountPercent = decimal.TryParse(tbDiscount.Text, out decimal disc) ? disc : 0;
                decimal discountAmountGlobal = subtotalGlobal * (discountPercent / 100);
                decimal totalGlobal = subtotalGlobal - discountAmountGlobal;

                // Asignar los totales al modelo de venta
                sell.Subtotal = subtotalGlobal.ToString("F2");
                sell.Discount = discountAmountGlobal.ToString("F2");
                sell.Total = totalGlobal.ToString("F2");

                // Crear los detalles de la venta
                var details = new List<SellDetailModel>();

                foreach (var item in articleItems)
                {
                    var cbArticle = item.Controls.Find("cbArticleName", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
                    var tbQuantity = item.Controls.Find("tbArticleQuantity", true).FirstOrDefault() as ReaLTaiizor.Controls.MaterialTextBoxEdit;

                    if (cbArticle != null && tbQuantity != null)
                    {
                        int quantity = int.Parse(tbQuantity.Text);

                        // Obtener el artículo para conseguir su ID
                        var article = articleController.GetByName(cbArticle.Text);

                        var detail = new SellDetailModel
                        {
                            ArticleId = article?.Id,
                            Quantity = quantity
                        };

                        details.Add(detail);
                    }
                }

                // Guardar o actualizar la venta con sus detalles
                bool success;
                if (isEditMode && currentSell != null)
                {
                    success = sellController.UpdateVentaConDetalles(sell, details);
                }
                else
                {
                    success = sellController.CreateVentaConDetalles(sell, details);
                }

                if (success)
                {
                    string message = isEditMode ? "Venta actualizada correctamente." : "Venta registrada correctamente.";
                    MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Registrar actividad usando el helper con las referencias de la venta
                    // Obtener el ID de la venta (sea nuevo o actualizado)
                    int sellId = isEditMode && currentSell != null ? currentSell.Id : sell.Id;
                    string action = originalId == 0 ? ActivityActions.Create : ActivityActions.Update;
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
