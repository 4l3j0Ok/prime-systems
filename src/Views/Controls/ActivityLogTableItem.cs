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
    public partial class ActivityLogTableItem : UserControl
    {
        public ActivityLogTableItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Date
        {
            get { return lblDate.Text; }
            set { lblDate.Text = value; }
        }
        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string UserName
        {
            get { return lblUserUsername.Text; }
            set { lblUserUsername.Text = value; }
        }
        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Module
        {
            get { return lblModule.Text; }
            set { lblModule.Text = value; }
        }
        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Action
        {
            get { return lblAction.Text; }
            set { lblAction.Text = value; }
        }
    }
}
