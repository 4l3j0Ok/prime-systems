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
        // Hacemos que sea modificable desde el designer lblTitle.Text y lblValue.Text
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
    }
}
