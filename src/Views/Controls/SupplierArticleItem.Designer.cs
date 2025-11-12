namespace PrimeSystems.Views.Controls
{
    partial class SupplierArticleItem
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
            tlpArticle0 = new TableLayoutPanel();
            btnRemove = new ReaLTaiizor.Controls.MaterialButton();
            panel1 = new Panel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            tbArticleUnitPrice = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            panel3 = new Panel();
            tbArticleQuantity = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            tbArticleName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            tlpArticle0.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tlpArticle0
            // 
            tlpArticle0.AutoSize = true;
            tlpArticle0.ColumnCount = 4;
            tlpArticle0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpArticle0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpArticle0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpArticle0.ColumnStyles.Add(new ColumnStyle());
            tlpArticle0.Controls.Add(btnRemove, 3, 0);
            tlpArticle0.Controls.Add(panel1, 0, 0);
            tlpArticle0.Controls.Add(panel2, 1, 0);
            tlpArticle0.Controls.Add(panel3, 2, 0);
            tlpArticle0.Dock = DockStyle.Fill;
            tlpArticle0.Location = new Point(0, 0);
            tlpArticle0.Margin = new Padding(0);
            tlpArticle0.Name = "tlpArticle0";
            tlpArticle0.RowCount = 1;
            tlpArticle0.RowStyles.Add(new RowStyle());
            tlpArticle0.Size = new Size(833, 70);
            tlpArticle0.TabIndex = 2;
            // 
            // btnRemove
            // 
            btnRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemove.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemove.Depth = 0;
            btnRemove.Dock = DockStyle.Fill;
            btnRemove.HighEmphasis = true;
            btnRemove.Icon = Properties.Resources.trash;
            btnRemove.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRemove.Location = new Point(711, 20);
            btnRemove.Margin = new Padding(3, 20, 3, 3);
            btnRemove.MaximumSize = new Size(0, 35);
            btnRemove.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRemove.Name = "btnRemove";
            btnRemove.NoAccentTextColor = Color.Empty;
            btnRemove.Size = new Size(119, 35);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remover";
            btnRemove.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemove.UseAccentColor = true;
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tbArticleName);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 3, 15, 3);
            panel1.Size = new Size(236, 70);
            panel1.TabIndex = 5;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Top;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(15, 3);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Artículo";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(tbArticleUnitPrice);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(236, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15, 3, 15, 3);
            panel2.Size = new Size(236, 70);
            panel2.TabIndex = 4;
            // 
            // tbArticleUnitPrice
            // 
            tbArticleUnitPrice.AnimateReadOnly = false;
            tbArticleUnitPrice.AutoCompleteMode = AutoCompleteMode.None;
            tbArticleUnitPrice.AutoCompleteSource = AutoCompleteSource.None;
            tbArticleUnitPrice.BackgroundImageLayout = ImageLayout.None;
            tbArticleUnitPrice.CharacterCasing = CharacterCasing.Normal;
            tbArticleUnitPrice.Depth = 0;
            tbArticleUnitPrice.Dock = DockStyle.Fill;
            tbArticleUnitPrice.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbArticleUnitPrice.HideSelection = true;
            tbArticleUnitPrice.LeadingIcon = null;
            tbArticleUnitPrice.Location = new Point(15, 22);
            tbArticleUnitPrice.MaxLength = 32767;
            tbArticleUnitPrice.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbArticleUnitPrice.Name = "tbArticleUnitPrice";
            tbArticleUnitPrice.PasswordChar = '\0';
            tbArticleUnitPrice.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Prefix;
            tbArticleUnitPrice.PrefixSuffixText = "$";
            tbArticleUnitPrice.ReadOnly = false;
            tbArticleUnitPrice.RightToLeft = RightToLeft.No;
            tbArticleUnitPrice.SelectedText = "";
            tbArticleUnitPrice.SelectionLength = 0;
            tbArticleUnitPrice.SelectionStart = 0;
            tbArticleUnitPrice.ShortcutsEnabled = true;
            tbArticleUnitPrice.Size = new Size(206, 36);
            tbArticleUnitPrice.TabIndex = 1;
            tbArticleUnitPrice.TabStop = false;
            tbArticleUnitPrice.TextAlign = HorizontalAlignment.Left;
            tbArticleUnitPrice.TrailingIcon = null;
            tbArticleUnitPrice.UseSystemPasswordChar = false;
            tbArticleUnitPrice.UseTallSize = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Top;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(15, 3);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(104, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Precio Unitario";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(tbArticleQuantity);
            panel3.Controls.Add(materialLabel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(472, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15, 3, 15, 3);
            panel3.Size = new Size(236, 70);
            panel3.TabIndex = 3;
            // 
            // tbArticleQuantity
            // 
            tbArticleQuantity.AnimateReadOnly = false;
            tbArticleQuantity.AutoCompleteMode = AutoCompleteMode.None;
            tbArticleQuantity.AutoCompleteSource = AutoCompleteSource.None;
            tbArticleQuantity.BackgroundImageLayout = ImageLayout.None;
            tbArticleQuantity.CharacterCasing = CharacterCasing.Normal;
            tbArticleQuantity.Depth = 0;
            tbArticleQuantity.Dock = DockStyle.Fill;
            tbArticleQuantity.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbArticleQuantity.HideSelection = true;
            tbArticleQuantity.LeadingIcon = null;
            tbArticleQuantity.Location = new Point(15, 22);
            tbArticleQuantity.MaxLength = 32767;
            tbArticleQuantity.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbArticleQuantity.Name = "tbArticleQuantity";
            tbArticleQuantity.PasswordChar = '\0';
            tbArticleQuantity.ReadOnly = false;
            tbArticleQuantity.RightToLeft = RightToLeft.No;
            tbArticleQuantity.SelectedText = "";
            tbArticleQuantity.SelectionLength = 0;
            tbArticleQuantity.SelectionStart = 0;
            tbArticleQuantity.ShortcutsEnabled = true;
            tbArticleQuantity.Size = new Size(206, 36);
            tbArticleQuantity.TabIndex = 2;
            tbArticleQuantity.TabStop = false;
            tbArticleQuantity.TextAlign = HorizontalAlignment.Left;
            tbArticleQuantity.TrailingIcon = null;
            tbArticleQuantity.UseSystemPasswordChar = false;
            tbArticleQuantity.UseTallSize = false;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Dock = DockStyle.Top;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(15, 3);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(65, 19);
            materialLabel3.TabIndex = 0;
            materialLabel3.Text = "Cantidad";
            // 
            // tbArticleName
            // 
            tbArticleName.AnimateReadOnly = false;
            tbArticleName.AutoCompleteMode = AutoCompleteMode.None;
            tbArticleName.AutoCompleteSource = AutoCompleteSource.None;
            tbArticleName.BackgroundImageLayout = ImageLayout.None;
            tbArticleName.CharacterCasing = CharacterCasing.Normal;
            tbArticleName.Depth = 0;
            tbArticleName.Dock = DockStyle.Fill;
            tbArticleName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbArticleName.HideSelection = true;
            tbArticleName.LeadingIcon = null;
            tbArticleName.Location = new Point(15, 22);
            tbArticleName.MaxLength = 32767;
            tbArticleName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbArticleName.Name = "tbArticleName";
            tbArticleName.PasswordChar = '\0';
            tbArticleName.ReadOnly = false;
            tbArticleName.RightToLeft = RightToLeft.No;
            tbArticleName.SelectedText = "";
            tbArticleName.SelectionLength = 0;
            tbArticleName.SelectionStart = 0;
            tbArticleName.ShortcutsEnabled = true;
            tbArticleName.Size = new Size(206, 36);
            tbArticleName.TabIndex = 3;
            tbArticleName.TabStop = false;
            tbArticleName.TextAlign = HorizontalAlignment.Left;
            tbArticleName.TrailingIcon = null;
            tbArticleName.UseSystemPasswordChar = false;
            tbArticleName.UseTallSize = false;
            // 
            // SupplierArticleItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpArticle0);
            MinimumSize = new Size(0, 70);
            Name = "SupplierArticleItem";
            Size = new Size(833, 70);
            tlpArticle0.ResumeLayout(false);
            tlpArticle0.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tlpArticle0;
        private ReaLTaiizor.Controls.MaterialButton btnRemove;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbArticleName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbArticleUnitPrice;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private Panel panel3;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbArticleQuantity;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
    }
}
