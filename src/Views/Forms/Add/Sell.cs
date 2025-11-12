using PrimeSystems.Controllers;
using PrimeSystems.Core;
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
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
        public Sell()
        {
            InitializeComponent();
            SetupTextBoxes();
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            var newArticleItem = new Controls.ArticleItem();
            newArticleItem.Dock = DockStyle.Top;
            gbArticlesData.Controls.Add(newArticleItem);
        }

        private void SetupTextBoxes()
        {
            tbDiscount.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbDiscount.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);
        }

        private void mepSellAdd_SaveClick(object sender, EventArgs e)
        {
            SellController controller = new SellController();

        }

        private void mepSellAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToSellView();
        }

        private void ReturnToSellView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpSells);
            }
        }
    }
}
