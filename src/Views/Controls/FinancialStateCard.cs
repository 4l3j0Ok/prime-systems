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
    public partial class FinancialStateCard : UserControl
    {
        public FinancialStateCard()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }
        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }

        private void tableLayoutPanel2_ClientSizeChanged(object sender, EventArgs e)
        {
            // Hacemos que sea modificable desde el designer lblTitle.Text y lblValue.Text
            if (this.Width < 1000)
            {
                lblValue.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H5;
            }
            else if (this.Width >= 1000)
            {
                lblValue.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            }
        }
    }
}
