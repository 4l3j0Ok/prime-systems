namespace PrimeSystems.Views.Controls
{
    partial class Filters
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            mepFilters = new ReaLTaiizor.Controls.MaterialExpansionPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tbSearchParam = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            btnSearch = new ReaLTaiizor.Controls.MaterialButton();
            chbShowInactive = new ReaLTaiizor.Controls.MaterialCheckBox();
            mepFilters.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // mepFilters
            // 
            mepFilters.AutoSize = true;
            mepFilters.BackColor = Color.FromArgb(255, 255, 255);
            mepFilters.Collapse = true;
            mepFilters.Controls.Add(tableLayoutPanel6);
            mepFilters.Depth = 0;
            mepFilters.Description = "Busqueda en los elementos mostrados";
            mepFilters.Dock = DockStyle.Fill;
            mepFilters.ExpandHeight = 200;
            mepFilters.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepFilters.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepFilters.Location = new Point(0, 0);
            mepFilters.Margin = new Padding(16, 1, 16, 0);
            mepFilters.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepFilters.Name = "mepFilters";
            mepFilters.Padding = new Padding(24, 64, 24, 24);
            mepFilters.ShowValidationButtons = false;
            mepFilters.Size = new Size(722, 48);
            mepFilters.TabIndex = 3;
            mepFilters.Title = "Filtros";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel6.Controls.Add(tbSearchParam, 0, 0);
            tableLayoutPanel6.Controls.Add(btnSearch, 1, 0);
            tableLayoutPanel6.Controls.Add(chbShowInactive, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(24, 64);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.Size = new Size(674, 0);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // tbSearchParam
            // 
            tbSearchParam.AnimateReadOnly = false;
            tbSearchParam.AutoCompleteMode = AutoCompleteMode.None;
            tbSearchParam.AutoCompleteSource = AutoCompleteSource.None;
            tbSearchParam.BackgroundImageLayout = ImageLayout.None;
            tbSearchParam.CharacterCasing = CharacterCasing.Normal;
            tbSearchParam.Depth = 0;
            tbSearchParam.Dock = DockStyle.Fill;
            tbSearchParam.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSearchParam.HideSelection = true;
            tbSearchParam.Hint = "Busca por título o descripción";
            tbSearchParam.LeadingIcon = null;
            tbSearchParam.Location = new Point(3, 3);
            tbSearchParam.MaxLength = 32767;
            tbSearchParam.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSearchParam.Name = "tbSearchParam";
            tbSearchParam.PasswordChar = '\0';
            tbSearchParam.PrefixSuffixText = null;
            tbSearchParam.ReadOnly = false;
            tbSearchParam.RightToLeft = RightToLeft.No;
            tbSearchParam.SelectedText = "";
            tbSearchParam.SelectionLength = 0;
            tbSearchParam.SelectionStart = 0;
            tbSearchParam.ShortcutsEnabled = true;
            tbSearchParam.Size = new Size(555, 48);
            tbSearchParam.TabIndex = 3;
            tbSearchParam.TabStop = false;
            tbSearchParam.TextAlign = HorizontalAlignment.Left;
            tbSearchParam.TrailingIcon = null;
            tbSearchParam.UseSystemPasswordChar = false;
            // 
            // btnSearch
            // 
            btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearch.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearch.Depth = 0;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.HighEmphasis = true;
            btnSearch.Icon = Properties.Resources.search;
            btnSearch.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSearch.Location = new Point(565, 6);
            btnSearch.Margin = new Padding(4, 6, 4, 6);
            btnSearch.MaximumSize = new Size(0, 40);
            btnSearch.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSearch.Name = "btnSearch";
            btnSearch.NoAccentTextColor = Color.Empty;
            btnSearch.Size = new Size(105, 40);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Buscar";
            btnSearch.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearch.UseAccentColor = false;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chbShowInactive
            // 
            chbShowInactive.AutoSize = true;
            chbShowInactive.Depth = 0;
            chbShowInactive.Location = new Point(0, 54);
            chbShowInactive.Margin = new Padding(0);
            chbShowInactive.MouseLocation = new Point(-1, -1);
            chbShowInactive.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbShowInactive.Name = "chbShowInactive";
            chbShowInactive.ReadOnly = false;
            chbShowInactive.Ripple = true;
            chbShowInactive.Size = new Size(158, 37);
            chbShowInactive.TabIndex = 5;
            chbShowInactive.Text = "Mostrar Inactivos";
            chbShowInactive.UseAccentColor = false;
            chbShowInactive.UseVisualStyleBackColor = true;
            chbShowInactive.CheckedChanged += chbShowInactive_CheckedChanged;
            // 
            // Filters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepFilters);
            MaximumSize = new Size(0, 200);
            MinimumSize = new Size(0, 48);
            Name = "Filters";
            Size = new Size(722, 200);
            mepFilters.ResumeLayout(false);
            mepFilters.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialExpansionPanel mepFilters;
        private TableLayoutPanel tableLayoutPanel6;
        public ReaLTaiizor.Controls.MaterialButton btnSearch;
        public ReaLTaiizor.Controls.MaterialTextBoxEdit tbSearchParam;
        public ReaLTaiizor.Controls.MaterialCheckBox chbShowInactive;
    }
}
