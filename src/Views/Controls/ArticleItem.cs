using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems.Views.Controls
{
    public partial class ArticleItem : UserControl
    {
        private ArticleController articleController = new();
        private StockController stockController = new();
        private ArticleModel? selectedArticle;
        
        public ArticleItem()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            // Validate unit price as decimal
            tbArticleUnitPrice.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbArticleUnitPrice.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
            
            // Validate quantity as number
            tbArticleQuantity.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbArticleQuantity.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
            
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            // Remover este control de su contenedor padre
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void cbArticleName_DropDown(object sender, EventArgs e)
        {
            var articles = articleController.GetAll();
            cbArticleName.Items.Clear();
            cbArticleName.Items.AddRange(articles.Select(a => a.Name).ToArray());
        }

        private void cbArticleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbArticleName.Text))
            {
                selectedArticle = null;
                tbArticleUnitPrice.Text = "";
                tbArticleQuantity.Text = "";
                return;
            }

            selectedArticle = articleController.GetByName(cbArticleName.Text);
            
            if (selectedArticle != null)
            {
                // Obtener el stock asociado para obtener el precio
                var stock = stockController.GetStockByArticuloId(selectedArticle.Id);
                
                if (stock != null)
                {
                    // Calcular el precio de venta basado en costo + ganancia
                    if (decimal.TryParse(stock.Cost, out decimal cost) && stock.Profit.HasValue)
                    {
                        decimal sellPrice = cost + (cost * stock.Profit.Value / 100);
                        tbArticleUnitPrice.Text = sellPrice.ToString("F2");
                    }
                    else if (decimal.TryParse(stock.Cost, out decimal costOnly))
                    {
                        tbArticleUnitPrice.Text = costOnly.ToString("F2");
                    }
                    else
                    {
                        tbArticleUnitPrice.Text = "0.00";
                    }
                }
                else
                {
                    tbArticleUnitPrice.Text = "0.00";
                }
                
                // Inicializar cantidad en 1
                tbArticleQuantity.Text = "1";
            }
            else
            {
                tbArticleUnitPrice.Text = "";
                tbArticleQuantity.Text = "";
            }

            // Disparar eventos TextChanged manualmente después de la selección
            tbArticleUnitPrice_TextChanged(tbArticleUnitPrice, EventArgs.Empty);
            tbArticleQuantity_TextChanged(tbArticleQuantity, EventArgs.Empty);
        }

        private void tbArticleUnitPrice_TextChanged(object sender, EventArgs e)
        {
            Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
        }

        private void tbArticleQuantity_TextChanged(object sender, EventArgs e)
        {
            Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
        }

        // Método público para obtener el artículo seleccionado
        public ArticleModel? GetSelectedArticle()
        {
            return selectedArticle;
        }

        // Método público para obtener el precio unitario
        public decimal GetUnitPrice()
        {
            return decimal.TryParse(tbArticleUnitPrice.Text, out decimal price) ? price : 0;
        }

        // Método público para obtener la cantidad
        public int GetQuantity()
        {
            return int.TryParse(tbArticleQuantity.Text, out int qty) ? qty : 0;
        }
    }
}
