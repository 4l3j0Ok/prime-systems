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
        public ArticleItem()
        {
            InitializeComponent();
            
            // Asignar evento al botón de remover
            btnRemove.Click += BtnRemove_Click;
        }
        
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            // Remover este control de su contenedor padre
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
    }
}
