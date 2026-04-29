using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using PrimeSystems.Services;
using PrimeSystems.Services;

namespace PrimeSystems.Views.Controls
{
    public partial class Filters : UserControl
    {
        private TabPage? _parentTabPage;
        private Action<string, bool>? _onSearchCallback;

        public Filters()
        {
            InitializeComponent();
            this.Size = new Size(mepFilters.Size.Width, 48);
            this.mepFilters.PanelCollapse += (s, e) => DynamicAdjustSize(s, e);
            this.mepFilters.PanelExpand += (s, e) => DynamicAdjustSize(s, e);
            tbSearchParam.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnSearch.PerformClick();
                    e.Handled = true;
                }
            };
        }
        public void Initialize<T, TId>(
            TabPage tabPage,
            Func<IGenericController<T, TId>> controllerFactory,
            Action refreshCallback
        )
        {
            _parentTabPage = tabPage;
            _onSearchCallback = (searchTerm, includeInactive) =>
            {
                try
                {
                    refreshCallback();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Filters.Initialize: Error - {ex.Message}");
                    MessageBox.Show($"Error al aplicar filtros: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
        public void ClearFilters()
        {
            tbSearchParam.Text = string.Empty;
            chbShowInactive.Checked = false;
        }
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string searchTerm = tbSearchParam.Text;
            bool includeInactive = chbShowInactive.Checked;
            _onSearchCallback?.Invoke(searchTerm, includeInactive);
        }
        private void DynamicAdjustSize(object sender, EventArgs e)
        {
            this.Size = new Size(mepFilters.Size.Width, mepFilters.Size.Height);
        }

        private void chbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            string searchTerm = tbSearchParam.Text;
            bool includeInactive = chbShowInactive.Checked;
            _onSearchCallback?.Invoke(searchTerm, includeInactive);
        }
    }
}
