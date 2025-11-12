namespace PrimeSystems.Views.Forms.Add
{
    partial class Purchase
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
            mepPurchaseAdd = new PrimeSystems.Views.Controls.MaterialExpansionPanelNonCollapsible();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbArticlesData = new GroupBox();
            panel4 = new Panel();
            btnAddArticle = new ReaLTaiizor.Controls.MaterialButton();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel5 = new Panel();
            cbProvider = new ReaLTaiizor.Controls.HopeComboBox();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            gbBillingData = new GroupBox();
            panel11 = new Panel();
            tbTotal = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel9 = new ReaLTaiizor.Controls.MaterialLabel();
            mepPurchaseAdd.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbArticlesData.SuspendLayout();
            panel4.SuspendLayout();
            gbRegisterData.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel5.SuspendLayout();
            gbBillingData.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // mepPurchaseAdd
            // 
            mepPurchaseAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mepPurchaseAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepPurchaseAdd.CancelButtonText = "Cancelar";
            mepPurchaseAdd.Controls.Add(tableLayoutPanel3);
            mepPurchaseAdd.Depth = 0;
            mepPurchaseAdd.Description = "";
            mepPurchaseAdd.Dock = DockStyle.Fill;
            mepPurchaseAdd.ExpandHeight = 518;
            mepPurchaseAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepPurchaseAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepPurchaseAdd.Location = new Point(0, 0);
            mepPurchaseAdd.Margin = new Padding(3, 16, 3, 16);
            mepPurchaseAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepPurchaseAdd.Name = "mepPurchaseAdd";
            mepPurchaseAdd.Padding = new Padding(24, 64, 24, 70);
            mepPurchaseAdd.ShowCollapseExpand = false;
            mepPurchaseAdd.Size = new Size(904, 518);
            mepPurchaseAdd.TabIndex = 2;
            mepPurchaseAdd.Title = "Registrar Compra";
            mepPurchaseAdd.ValidationButtonEnable = true;
            mepPurchaseAdd.ValidationButtonText = "Guardar";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(gbArticlesData, 0, 1);
            tableLayoutPanel3.Controls.Add(gbRegisterData, 0, 0);
            tableLayoutPanel3.Controls.Add(gbBillingData, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(24, 64);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(856, 384);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // gbArticlesData
            // 
            gbArticlesData.AutoSize = true;
            gbArticlesData.Controls.Add(panel4);
            gbArticlesData.Dock = DockStyle.Fill;
            gbArticlesData.Location = new Point(3, 149);
            gbArticlesData.Name = "gbArticlesData";
            gbArticlesData.Padding = new Padding(10);
            gbArticlesData.Size = new Size(850, 72);
            gbArticlesData.TabIndex = 8;
            gbArticlesData.TabStop = false;
            gbArticlesData.Text = "Artículos";
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Controls.Add(btnAddArticle);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 26);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(200, 0, 200, 0);
            panel4.Size = new Size(830, 36);
            panel4.TabIndex = 1;
            // 
            // btnAddArticle
            // 
            btnAddArticle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddArticle.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddArticle.Depth = 0;
            btnAddArticle.Dock = DockStyle.Top;
            btnAddArticle.HighEmphasis = true;
            btnAddArticle.Icon = Properties.Resources.add;
            btnAddArticle.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnAddArticle.Location = new Point(200, 0);
            btnAddArticle.Margin = new Padding(4, 6, 4, 6);
            btnAddArticle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.NoAccentTextColor = Color.Empty;
            btnAddArticle.Size = new Size(430, 36);
            btnAddArticle.TabIndex = 2;
            btnAddArticle.Text = "Agregar";
            btnAddArticle.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddArticle.UseAccentColor = false;
            btnAddArticle.UseVisualStyleBackColor = true;
            // 
            // gbRegisterData
            // 
            gbRegisterData.AutoSize = true;
            gbRegisterData.Controls.Add(tableLayoutPanel4);
            gbRegisterData.Dock = DockStyle.Fill;
            gbRegisterData.Location = new Point(3, 3);
            gbRegisterData.MinimumSize = new Size(0, 140);
            gbRegisterData.Name = "gbRegisterData";
            gbRegisterData.Padding = new Padding(10);
            gbRegisterData.Size = new Size(850, 140);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de registro";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(panel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 26);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(830, 104);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbProvider);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(830, 104);
            panel5.TabIndex = 5;
            // 
            // cbProvider
            // 
            cbProvider.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProvider.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbProvider.Dock = DockStyle.Fill;
            cbProvider.DrawMode = DrawMode.OwnerDrawFixed;
            cbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvider.FlatStyle = FlatStyle.Flat;
            cbProvider.Font = new Font("Segoe UI", 12F);
            cbProvider.FormattingEnabled = true;
            cbProvider.ItemHeight = 40;
            cbProvider.Location = new Point(15, 34);
            cbProvider.Name = "cbProvider";
            cbProvider.Size = new Size(800, 46);
            cbProvider.TabIndex = 2;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Dock = DockStyle.Top;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(15, 15);
            materialLabel4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(72, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "Proveedor";
            // 
            // gbBillingData
            // 
            gbBillingData.AutoSize = true;
            gbBillingData.Controls.Add(panel11);
            gbBillingData.Dock = DockStyle.Fill;
            gbBillingData.Location = new Point(3, 227);
            gbBillingData.MinimumSize = new Size(0, 140);
            gbBillingData.Name = "gbBillingData";
            gbBillingData.Padding = new Padding(10);
            gbBillingData.Size = new Size(850, 154);
            gbBillingData.TabIndex = 6;
            gbBillingData.TabStop = false;
            gbBillingData.Text = "Datos de facturación";
            // 
            // panel11
            // 
            panel11.Controls.Add(tbTotal);
            panel11.Controls.Add(materialLabel9);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(10, 26);
            panel11.Margin = new Padding(0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(15);
            panel11.Size = new Size(830, 118);
            panel11.TabIndex = 4;
            // 
            // tbTotal
            // 
            tbTotal.AnimateReadOnly = false;
            tbTotal.AutoCompleteMode = AutoCompleteMode.None;
            tbTotal.AutoCompleteSource = AutoCompleteSource.None;
            tbTotal.BackgroundImageLayout = ImageLayout.None;
            tbTotal.CharacterCasing = CharacterCasing.Normal;
            tbTotal.Depth = 0;
            tbTotal.Dock = DockStyle.Fill;
            tbTotal.Enabled = false;
            tbTotal.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbTotal.HideSelection = true;
            tbTotal.LeadingIcon = null;
            tbTotal.Location = new Point(15, 34);
            tbTotal.MaxLength = 32767;
            tbTotal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbTotal.Name = "tbTotal";
            tbTotal.PasswordChar = '\0';
            tbTotal.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Prefix;
            tbTotal.PrefixSuffixText = "$";
            tbTotal.ReadOnly = false;
            tbTotal.RightToLeft = RightToLeft.No;
            tbTotal.SelectedText = "";
            tbTotal.SelectionLength = 0;
            tbTotal.SelectionStart = 0;
            tbTotal.ShortcutsEnabled = true;
            tbTotal.Size = new Size(800, 48);
            tbTotal.TabIndex = 2;
            tbTotal.TabStop = false;
            tbTotal.TextAlign = HorizontalAlignment.Left;
            tbTotal.TrailingIcon = null;
            tbTotal.UseSystemPasswordChar = false;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Dock = DockStyle.Top;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(15, 15);
            materialLabel9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(38, 19);
            materialLabel9.TabIndex = 0;
            materialLabel9.Text = "Total";
            // 
            // Purchase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepPurchaseAdd);
            Name = "Purchase";
            Size = new Size(904, 518);
            mepPurchaseAdd.ResumeLayout(false);
            mepPurchaseAdd.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            gbArticlesData.ResumeLayout(false);
            gbArticlesData.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            gbRegisterData.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            gbBillingData.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.MaterialExpansionPanelNonCollapsible mepPurchaseAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbArticlesData;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialButton btnAddArticle;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel5;
        private ReaLTaiizor.Controls.HopeComboBox cbProvider;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private GroupBox gbBillingData;
        private Panel panel11;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbTotal;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel9;
    }
}
