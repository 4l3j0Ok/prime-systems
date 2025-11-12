namespace PrimeSystems.Views.Forms.Add
{
    partial class Sell
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
            mepSellAdd = new PrimeSystems.Views.Controls.MaterialExpansionPanelNonCollapsible();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbArticlesData = new GroupBox();
            panel4 = new Panel();
            btnAddArticle = new ReaLTaiizor.Controls.MaterialButton();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel5 = new Panel();
            cbClient = new ReaLTaiizor.Controls.HopeComboBox();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            panel6 = new Panel();
            tbDateTime = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel7 = new Panel();
            tbCurrentUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel6 = new ReaLTaiizor.Controls.MaterialLabel();
            gbBillingData = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel9 = new Panel();
            tbSubtotal = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel7 = new ReaLTaiizor.Controls.MaterialLabel();
            panel10 = new Panel();
            tbDiscount = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel8 = new ReaLTaiizor.Controls.MaterialLabel();
            panel11 = new Panel();
            tbTotal = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel9 = new ReaLTaiizor.Controls.MaterialLabel();
            mepSellAdd.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbArticlesData.SuspendLayout();
            panel4.SuspendLayout();
            gbRegisterData.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            gbBillingData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // mepSellAdd
            // 
            mepSellAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mepSellAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepSellAdd.CancelButtonText = "Cancelar";
            mepSellAdd.Controls.Add(tableLayoutPanel3);
            mepSellAdd.Depth = 0;
            mepSellAdd.Description = "";
            mepSellAdd.Dock = DockStyle.Fill;
            mepSellAdd.ExpandHeight = 371;
            mepSellAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepSellAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepSellAdd.Location = new Point(0, 0);
            mepSellAdd.Margin = new Padding(3, 16, 3, 16);
            mepSellAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepSellAdd.Name = "mepSellAdd";
            mepSellAdd.Padding = new Padding(24, 64, 24, 70);
            mepSellAdd.ShowCollapseExpand = false;
            mepSellAdd.Size = new Size(918, 371);
            mepSellAdd.TabIndex = 1;
            mepSellAdd.Title = "Registrar Venta";
            mepSellAdd.ValidationButtonEnable = true;
            mepSellAdd.ValidationButtonText = "Guardar";
            mepSellAdd.SaveClick += mepSellAdd_SaveClick;
            mepSellAdd.CancelClick += mepSellAdd_CancelClick;
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
            tableLayoutPanel3.Size = new Size(870, 237);
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
            gbArticlesData.Size = new Size(847, 72);
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
            panel4.Size = new Size(827, 36);
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
            btnAddArticle.Size = new Size(427, 36);
            btnAddArticle.TabIndex = 2;
            btnAddArticle.Text = "Agregar";
            btnAddArticle.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddArticle.UseAccentColor = false;
            btnAddArticle.UseVisualStyleBackColor = true;
            btnAddArticle.Click += btnAddArticle_Click;
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
            gbRegisterData.Size = new Size(847, 140);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de registro";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(panel5, 0, 0);
            tableLayoutPanel4.Controls.Add(panel6, 1, 0);
            tableLayoutPanel4.Controls.Add(panel7, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 26);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(827, 104);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbClient);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(275, 104);
            panel5.TabIndex = 5;
            // 
            // cbClient
            // 
            cbClient.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbClient.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbClient.Dock = DockStyle.Fill;
            cbClient.DrawMode = DrawMode.OwnerDrawFixed;
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.FlatStyle = FlatStyle.Flat;
            cbClient.Font = new Font("Segoe UI", 12F);
            cbClient.FormattingEnabled = true;
            cbClient.ItemHeight = 40;
            cbClient.Location = new Point(15, 34);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(245, 46);
            cbClient.TabIndex = 2;
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
            materialLabel4.Size = new Size(49, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "Cliente";
            // 
            // panel6
            // 
            panel6.Controls.Add(tbDateTime);
            panel6.Controls.Add(materialLabel5);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(275, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(15);
            panel6.Size = new Size(275, 104);
            panel6.TabIndex = 4;
            // 
            // tbDateTime
            // 
            tbDateTime.AnimateReadOnly = false;
            tbDateTime.AutoCompleteMode = AutoCompleteMode.None;
            tbDateTime.AutoCompleteSource = AutoCompleteSource.None;
            tbDateTime.BackgroundImageLayout = ImageLayout.None;
            tbDateTime.CharacterCasing = CharacterCasing.Normal;
            tbDateTime.Depth = 0;
            tbDateTime.Dock = DockStyle.Fill;
            tbDateTime.Enabled = false;
            tbDateTime.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbDateTime.HideSelection = true;
            tbDateTime.LeadingIcon = null;
            tbDateTime.Location = new Point(15, 34);
            tbDateTime.MaxLength = 32767;
            tbDateTime.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbDateTime.Name = "tbDateTime";
            tbDateTime.PasswordChar = '\0';
            tbDateTime.PrefixSuffixText = null;
            tbDateTime.ReadOnly = false;
            tbDateTime.RightToLeft = RightToLeft.No;
            tbDateTime.SelectedText = "";
            tbDateTime.SelectionLength = 0;
            tbDateTime.SelectionStart = 0;
            tbDateTime.ShortcutsEnabled = true;
            tbDateTime.Size = new Size(245, 48);
            tbDateTime.TabIndex = 1;
            tbDateTime.TabStop = false;
            tbDateTime.Text = "20/20/2020 - 20:20";
            tbDateTime.TextAlign = HorizontalAlignment.Left;
            tbDateTime.TrailingIcon = null;
            tbDateTime.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Dock = DockStyle.Top;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(15, 15);
            materialLabel5.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(44, 19);
            materialLabel5.TabIndex = 0;
            materialLabel5.Text = "Fecha";
            // 
            // panel7
            // 
            panel7.Controls.Add(tbCurrentUser);
            panel7.Controls.Add(materialLabel6);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(550, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(15);
            panel7.Size = new Size(277, 104);
            panel7.TabIndex = 3;
            // 
            // tbCurrentUser
            // 
            tbCurrentUser.AnimateReadOnly = false;
            tbCurrentUser.AutoCompleteMode = AutoCompleteMode.None;
            tbCurrentUser.AutoCompleteSource = AutoCompleteSource.None;
            tbCurrentUser.BackgroundImageLayout = ImageLayout.None;
            tbCurrentUser.CharacterCasing = CharacterCasing.Normal;
            tbCurrentUser.Depth = 0;
            tbCurrentUser.Dock = DockStyle.Fill;
            tbCurrentUser.Enabled = false;
            tbCurrentUser.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbCurrentUser.HideSelection = true;
            tbCurrentUser.LeadingIcon = null;
            tbCurrentUser.Location = new Point(15, 34);
            tbCurrentUser.MaxLength = 32767;
            tbCurrentUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbCurrentUser.Name = "tbCurrentUser";
            tbCurrentUser.PasswordChar = '\0';
            tbCurrentUser.PrefixSuffixText = null;
            tbCurrentUser.ReadOnly = false;
            tbCurrentUser.RightToLeft = RightToLeft.No;
            tbCurrentUser.SelectedText = "";
            tbCurrentUser.SelectionLength = 0;
            tbCurrentUser.SelectionStart = 0;
            tbCurrentUser.ShortcutsEnabled = true;
            tbCurrentUser.Size = new Size(247, 48);
            tbCurrentUser.TabIndex = 2;
            tbCurrentUser.TabStop = false;
            tbCurrentUser.Text = "Pepe Díaz";
            tbCurrentUser.TextAlign = HorizontalAlignment.Left;
            tbCurrentUser.TrailingIcon = null;
            tbCurrentUser.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Dock = DockStyle.Top;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(15, 15);
            materialLabel6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(134, 19);
            materialLabel6.TabIndex = 0;
            materialLabel6.Text = "Usuario registrante";
            // 
            // gbBillingData
            // 
            gbBillingData.AutoSize = true;
            gbBillingData.Controls.Add(tableLayoutPanel2);
            gbBillingData.Dock = DockStyle.Fill;
            gbBillingData.Location = new Point(3, 227);
            gbBillingData.MinimumSize = new Size(0, 140);
            gbBillingData.Name = "gbBillingData";
            gbBillingData.Padding = new Padding(10);
            gbBillingData.Size = new Size(847, 141);
            gbBillingData.TabIndex = 6;
            gbBillingData.TabStop = false;
            gbBillingData.Text = "Datos de facturación";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(panel9, 0, 0);
            tableLayoutPanel2.Controls.Add(panel10, 1, 0);
            tableLayoutPanel2.Controls.Add(panel11, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(10, 26);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(827, 105);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(tbSubtotal);
            panel9.Controls.Add(materialLabel7);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(15);
            panel9.Size = new Size(275, 105);
            panel9.TabIndex = 5;
            // 
            // tbSubtotal
            // 
            tbSubtotal.AnimateReadOnly = false;
            tbSubtotal.AutoCompleteMode = AutoCompleteMode.None;
            tbSubtotal.AutoCompleteSource = AutoCompleteSource.None;
            tbSubtotal.BackgroundImageLayout = ImageLayout.None;
            tbSubtotal.CharacterCasing = CharacterCasing.Normal;
            tbSubtotal.Depth = 0;
            tbSubtotal.Dock = DockStyle.Fill;
            tbSubtotal.Enabled = false;
            tbSubtotal.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSubtotal.HideSelection = true;
            tbSubtotal.LeadingIcon = null;
            tbSubtotal.Location = new Point(15, 34);
            tbSubtotal.MaxLength = 32767;
            tbSubtotal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSubtotal.Name = "tbSubtotal";
            tbSubtotal.PasswordChar = '\0';
            tbSubtotal.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Prefix;
            tbSubtotal.PrefixSuffixText = "$";
            tbSubtotal.ReadOnly = false;
            tbSubtotal.RightToLeft = RightToLeft.No;
            tbSubtotal.SelectedText = "";
            tbSubtotal.SelectionLength = 0;
            tbSubtotal.SelectionStart = 0;
            tbSubtotal.ShortcutsEnabled = true;
            tbSubtotal.Size = new Size(245, 48);
            tbSubtotal.TabIndex = 3;
            tbSubtotal.TabStop = false;
            tbSubtotal.TextAlign = HorizontalAlignment.Left;
            tbSubtotal.TrailingIcon = null;
            tbSubtotal.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Dock = DockStyle.Top;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(15, 15);
            materialLabel7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(61, 19);
            materialLabel7.TabIndex = 2;
            materialLabel7.Text = "Subtotal";
            // 
            // panel10
            // 
            panel10.Controls.Add(tbDiscount);
            panel10.Controls.Add(materialLabel8);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(275, 0);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(15);
            panel10.Size = new Size(275, 105);
            panel10.TabIndex = 4;
            // 
            // tbDiscount
            // 
            tbDiscount.AnimateReadOnly = false;
            tbDiscount.AutoCompleteMode = AutoCompleteMode.None;
            tbDiscount.AutoCompleteSource = AutoCompleteSource.None;
            tbDiscount.BackgroundImageLayout = ImageLayout.None;
            tbDiscount.CharacterCasing = CharacterCasing.Normal;
            tbDiscount.Depth = 0;
            tbDiscount.Dock = DockStyle.Fill;
            tbDiscount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbDiscount.HideSelection = true;
            tbDiscount.LeadingIcon = null;
            tbDiscount.Location = new Point(15, 34);
            tbDiscount.MaxLength = 32767;
            tbDiscount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbDiscount.Name = "tbDiscount";
            tbDiscount.PasswordChar = '\0';
            tbDiscount.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Suffix;
            tbDiscount.PrefixSuffixText = "%";
            tbDiscount.ReadOnly = false;
            tbDiscount.RightToLeft = RightToLeft.No;
            tbDiscount.SelectedText = "";
            tbDiscount.SelectionLength = 0;
            tbDiscount.SelectionStart = 0;
            tbDiscount.ShortcutsEnabled = true;
            tbDiscount.Size = new Size(245, 48);
            tbDiscount.TabIndex = 1;
            tbDiscount.TabStop = false;
            tbDiscount.TextAlign = HorizontalAlignment.Left;
            tbDiscount.TrailingIcon = null;
            tbDiscount.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Dock = DockStyle.Top;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(15, 15);
            materialLabel8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(76, 19);
            materialLabel8.TabIndex = 0;
            materialLabel8.Text = "Descuento";
            // 
            // panel11
            // 
            panel11.Controls.Add(tbTotal);
            panel11.Controls.Add(materialLabel9);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(550, 0);
            panel11.Margin = new Padding(0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(15);
            panel11.Size = new Size(277, 105);
            panel11.TabIndex = 3;
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
            tbTotal.Size = new Size(247, 48);
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
            // Sell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepSellAdd);
            DoubleBuffered = true;
            Name = "Sell";
            Size = new Size(918, 371);
            mepSellAdd.ResumeLayout(false);
            mepSellAdd.PerformLayout();
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
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            gbBillingData.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.MaterialExpansionPanelNonCollapsible mepSellAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private Panel panel6;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbDateTime;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private Panel panel7;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbCurrentUser;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel6;
        private GroupBox gbBillingData;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel9;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSubtotal;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel7;
        private Panel panel10;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbDiscount;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel8;
        private Panel panel11;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbTotal;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel9;
        private GroupBox gbArticlesData;
        private ReaLTaiizor.Controls.HopeComboBox cbClient;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialButton btnAddArticle;
    }
}
