using PrimeSystems.Core;
using PrimeSystems.Controllers;
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
    public partial class SupplierArticleItem : UserControl
    {
        private ArticleController articleController;
        private List<ArticleModel> articles;

        public SupplierArticleItem()
        {
            articleController = new ArticleController();
            articles = new List<ArticleModel>();
            InitializeComponent();
            SetupTextBoxes();
            LoadArticles();
        }
        
        private void SetupTextBoxes()
        {
            // Validate unit price as decimal
            tbArticleUnitPrice.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbArticleUnitPrice.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
            
            // Validate quantity as number
            tbArticleQuantity.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbArticleQuantity.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
        }
        
        private void LoadArticles()
        {
            try
            {
                articles = articleController.GetAll();
                cbArticleName.Items.Clear();
                
                cbArticleName.Items.Add("-- Seleccione un artículo --");
                
                foreach (var article in articles)
                {
                    cbArticleName.Items.Add(article.Name);
                }
                
                if (cbArticleName.Items.Count > 0)
                    cbArticleName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public int? GetSelectedArticleId()
        {
            if (cbArticleName.SelectedIndex <= 0 || cbArticleName.SelectedItem == null)
                return null;
            
            string selectedName = cbArticleName.SelectedItem.ToString() ?? "";
            if (selectedName.StartsWith("--"))
                return null;
                
            var article = articles.FirstOrDefault(a => a.Name == selectedName);
            return article?.Id;
        }
        
        public void SetArticleById(int articleId)
        {
            var article = articles.FirstOrDefault(a => a.Id == articleId);
            if (article != null)
            {
                cbArticleName.SelectedItem = article.Name;
            }
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
    }
}
