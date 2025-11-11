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
        public Sell()
        {
            InitializeComponent();
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia de ArticleItem
            var newArticleItem = new Controls.ArticleItem();
            newArticleItem.Dock = DockStyle.Top;
            gbArticlesData.Controls.Add(newArticleItem);
        }
    }
}
