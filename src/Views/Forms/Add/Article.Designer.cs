namespace PrimeSystems.Views.Forms.Add
{
    partial class Article
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
            mepArticleAdd = new PrimeSystems.Views.Controls.MaterialExpansionPanelNonCollapsible();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel9 = new Panel();
            tbArticleCode = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel9 = new ReaLTaiizor.Controls.MaterialLabel();
            panel8 = new Panel();
            tbSellPrice = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel8 = new ReaLTaiizor.Controls.MaterialLabel();
            panel7 = new Panel();
            tbCostProfit = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel7 = new ReaLTaiizor.Controls.MaterialLabel();
            panel6 = new Panel();
            tbStockCost = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel6 = new ReaLTaiizor.Controls.MaterialLabel();
            panel4 = new Panel();
            tbStockQuantity = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel3 = new Panel();
            cbArticleSubcategory = new ReaLTaiizor.Controls.HopeComboBox();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            cbArticleCategory = new ReaLTaiizor.Controls.HopeComboBox();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1 = new Panel();
            cbArticleDescription = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel5 = new Panel();
            cbArticleName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            mepArticleAdd.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbRegisterData.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // mepArticleAdd
            // 
            mepArticleAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mepArticleAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepArticleAdd.CancelButtonText = "Cancelar";
            mepArticleAdd.Controls.Add(tableLayoutPanel3);
            mepArticleAdd.Depth = 0;
            mepArticleAdd.Description = "";
            mepArticleAdd.Dock = DockStyle.Fill;
            mepArticleAdd.ExpandHeight = 655;
            mepArticleAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepArticleAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepArticleAdd.Location = new Point(0, 0);
            mepArticleAdd.Margin = new Padding(3, 16, 3, 16);
            mepArticleAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepArticleAdd.Name = "mepArticleAdd";
            mepArticleAdd.Padding = new Padding(24, 64, 24, 70);
            mepArticleAdd.ShowCollapseExpand = false;
            mepArticleAdd.Size = new Size(545, 655);
            mepArticleAdd.TabIndex = 5;
            mepArticleAdd.Title = "Agregar Artículo";
            mepArticleAdd.ValidationButtonEnable = true;
            mepArticleAdd.ValidationButtonText = "Guardar";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(gbRegisterData, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(24, 64);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(497, 521);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // gbRegisterData
            // 
            gbRegisterData.Controls.Add(tableLayoutPanel4);
            gbRegisterData.Dock = DockStyle.Top;
            gbRegisterData.Location = new Point(3, 3);
            gbRegisterData.Name = "gbRegisterData";
            gbRegisterData.Padding = new Padding(10);
            gbRegisterData.Size = new Size(491, 653);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de artículo";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(panel9, 1, 4);
            tableLayoutPanel4.Controls.Add(panel8, 1, 3);
            tableLayoutPanel4.Controls.Add(panel7, 0, 3);
            tableLayoutPanel4.Controls.Add(panel6, 1, 2);
            tableLayoutPanel4.Controls.Add(panel4, 0, 2);
            tableLayoutPanel4.Controls.Add(panel3, 1, 1);
            tableLayoutPanel4.Controls.Add(panel2, 0, 1);
            tableLayoutPanel4.Controls.Add(panel1, 1, 0);
            tableLayoutPanel4.Controls.Add(panel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 26);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(471, 617);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.AutoSize = true;
            panel9.Controls.Add(tbArticleCode);
            panel9.Controls.Add(materialLabel9);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(235, 480);
            panel9.Margin = new Padding(0);
            panel9.MinimumSize = new Size(0, 120);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(15);
            panel9.Size = new Size(236, 137);
            panel9.TabIndex = 15;
            // 
            // tbArticleCode
            // 
            tbArticleCode.AnimateReadOnly = false;
            tbArticleCode.AutoCompleteMode = AutoCompleteMode.None;
            tbArticleCode.AutoCompleteSource = AutoCompleteSource.None;
            tbArticleCode.BackgroundImageLayout = ImageLayout.None;
            tbArticleCode.CharacterCasing = CharacterCasing.Normal;
            tbArticleCode.Depth = 0;
            tbArticleCode.Dock = DockStyle.Fill;
            tbArticleCode.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbArticleCode.HideSelection = true;
            tbArticleCode.LeadingIcon = null;
            tbArticleCode.Location = new Point(15, 34);
            tbArticleCode.MaxLength = 32767;
            tbArticleCode.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbArticleCode.Name = "tbArticleCode";
            tbArticleCode.PasswordChar = '\0';
            tbArticleCode.PrefixSuffixText = null;
            tbArticleCode.ReadOnly = false;
            tbArticleCode.RightToLeft = RightToLeft.No;
            tbArticleCode.SelectedText = "";
            tbArticleCode.SelectionLength = 0;
            tbArticleCode.SelectionStart = 0;
            tbArticleCode.ShortcutsEnabled = true;
            tbArticleCode.Size = new Size(206, 48);
            tbArticleCode.TabIndex = 3;
            tbArticleCode.TabStop = false;
            tbArticleCode.TextAlign = HorizontalAlignment.Left;
            tbArticleCode.TrailingIcon = null;
            tbArticleCode.UseSystemPasswordChar = false;
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
            materialLabel9.Size = new Size(51, 19);
            materialLabel9.TabIndex = 0;
            materialLabel9.Text = "Código";
            // 
            // panel8
            // 
            panel8.AutoSize = true;
            panel8.Controls.Add(tbSellPrice);
            panel8.Controls.Add(materialLabel8);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(235, 360);
            panel8.Margin = new Padding(0);
            panel8.MinimumSize = new Size(0, 120);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(15);
            panel8.Size = new Size(236, 120);
            panel8.TabIndex = 14;
            // 
            // tbSellPrice
            // 
            tbSellPrice.AnimateReadOnly = false;
            tbSellPrice.AutoCompleteMode = AutoCompleteMode.None;
            tbSellPrice.AutoCompleteSource = AutoCompleteSource.None;
            tbSellPrice.BackgroundImageLayout = ImageLayout.None;
            tbSellPrice.CharacterCasing = CharacterCasing.Normal;
            tbSellPrice.Depth = 0;
            tbSellPrice.Dock = DockStyle.Fill;
            tbSellPrice.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSellPrice.HideSelection = true;
            tbSellPrice.LeadingIcon = null;
            tbSellPrice.Location = new Point(15, 34);
            tbSellPrice.MaxLength = 32767;
            tbSellPrice.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSellPrice.Name = "tbSellPrice";
            tbSellPrice.PasswordChar = '\0';
            tbSellPrice.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Prefix;
            tbSellPrice.PrefixSuffixText = "$";
            tbSellPrice.ReadOnly = false;
            tbSellPrice.RightToLeft = RightToLeft.No;
            tbSellPrice.SelectedText = "";
            tbSellPrice.SelectionLength = 0;
            tbSellPrice.SelectionStart = 0;
            tbSellPrice.ShortcutsEnabled = true;
            tbSellPrice.Size = new Size(206, 48);
            tbSellPrice.TabIndex = 3;
            tbSellPrice.TabStop = false;
            tbSellPrice.TextAlign = HorizontalAlignment.Left;
            tbSellPrice.TrailingIcon = null;
            tbSellPrice.UseSystemPasswordChar = false;
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
            materialLabel8.Size = new Size(109, 19);
            materialLabel8.TabIndex = 0;
            materialLabel8.Text = "Precio de venta";
            // 
            // panel7
            // 
            panel7.AutoSize = true;
            panel7.Controls.Add(tbCostProfit);
            panel7.Controls.Add(materialLabel7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 360);
            panel7.Margin = new Padding(0);
            panel7.MinimumSize = new Size(0, 120);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(15);
            panel7.Size = new Size(235, 120);
            panel7.TabIndex = 13;
            // 
            // tbCostProfit
            // 
            tbCostProfit.AnimateReadOnly = false;
            tbCostProfit.AutoCompleteMode = AutoCompleteMode.None;
            tbCostProfit.AutoCompleteSource = AutoCompleteSource.None;
            tbCostProfit.BackgroundImageLayout = ImageLayout.None;
            tbCostProfit.CharacterCasing = CharacterCasing.Normal;
            tbCostProfit.Depth = 0;
            tbCostProfit.Dock = DockStyle.Fill;
            tbCostProfit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbCostProfit.HideSelection = true;
            tbCostProfit.LeadingIcon = null;
            tbCostProfit.Location = new Point(15, 34);
            tbCostProfit.MaxLength = 32767;
            tbCostProfit.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbCostProfit.Name = "tbCostProfit";
            tbCostProfit.PasswordChar = '\0';
            tbCostProfit.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Suffix;
            tbCostProfit.PrefixSuffixText = "%";
            tbCostProfit.ReadOnly = false;
            tbCostProfit.RightToLeft = RightToLeft.Yes;
            tbCostProfit.SelectedText = "";
            tbCostProfit.SelectionLength = 0;
            tbCostProfit.SelectionStart = 0;
            tbCostProfit.ShortcutsEnabled = true;
            tbCostProfit.Size = new Size(205, 48);
            tbCostProfit.TabIndex = 3;
            tbCostProfit.TabStop = false;
            tbCostProfit.TextAlign = HorizontalAlignment.Left;
            tbCostProfit.TrailingIcon = null;
            tbCostProfit.UseSystemPasswordChar = false;
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
            materialLabel7.Size = new Size(69, 19);
            materialLabel7.TabIndex = 0;
            materialLabel7.Text = "Ganancia";
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.Controls.Add(tbStockCost);
            panel6.Controls.Add(materialLabel6);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(235, 240);
            panel6.Margin = new Padding(0);
            panel6.MinimumSize = new Size(0, 120);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(15);
            panel6.Size = new Size(236, 120);
            panel6.TabIndex = 11;
            // 
            // tbStockCost
            // 
            tbStockCost.AnimateReadOnly = false;
            tbStockCost.AutoCompleteMode = AutoCompleteMode.None;
            tbStockCost.AutoCompleteSource = AutoCompleteSource.None;
            tbStockCost.BackgroundImageLayout = ImageLayout.None;
            tbStockCost.CharacterCasing = CharacterCasing.Normal;
            tbStockCost.Depth = 0;
            tbStockCost.Dock = DockStyle.Fill;
            tbStockCost.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbStockCost.HideSelection = true;
            tbStockCost.LeadingIcon = null;
            tbStockCost.Location = new Point(15, 34);
            tbStockCost.MaxLength = 32767;
            tbStockCost.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbStockCost.Name = "tbStockCost";
            tbStockCost.PasswordChar = '\0';
            tbStockCost.PrefixSuffix = ReaLTaiizor.Controls.MaterialTextBoxEdit.PrefixSuffixTypes.Prefix;
            tbStockCost.PrefixSuffixText = "$";
            tbStockCost.ReadOnly = false;
            tbStockCost.RightToLeft = RightToLeft.No;
            tbStockCost.SelectedText = "";
            tbStockCost.SelectionLength = 0;
            tbStockCost.SelectionStart = 0;
            tbStockCost.ShortcutsEnabled = true;
            tbStockCost.Size = new Size(206, 48);
            tbStockCost.TabIndex = 3;
            tbStockCost.TabStop = false;
            tbStockCost.TextAlign = HorizontalAlignment.Left;
            tbStockCost.TrailingIcon = null;
            tbStockCost.UseSystemPasswordChar = false;
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
            materialLabel6.Size = new Size(42, 19);
            materialLabel6.TabIndex = 0;
            materialLabel6.Text = "Costo";
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Controls.Add(tbStockQuantity);
            panel4.Controls.Add(materialLabel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 240);
            panel4.Margin = new Padding(0);
            panel4.MinimumSize = new Size(0, 120);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);
            panel4.Size = new Size(235, 120);
            panel4.TabIndex = 10;
            // 
            // tbStockQuantity
            // 
            tbStockQuantity.AnimateReadOnly = false;
            tbStockQuantity.AutoCompleteMode = AutoCompleteMode.None;
            tbStockQuantity.AutoCompleteSource = AutoCompleteSource.None;
            tbStockQuantity.BackgroundImageLayout = ImageLayout.None;
            tbStockQuantity.CharacterCasing = CharacterCasing.Normal;
            tbStockQuantity.Depth = 0;
            tbStockQuantity.Dock = DockStyle.Fill;
            tbStockQuantity.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbStockQuantity.HideSelection = true;
            tbStockQuantity.LeadingIcon = null;
            tbStockQuantity.Location = new Point(15, 34);
            tbStockQuantity.MaxLength = 32767;
            tbStockQuantity.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbStockQuantity.Name = "tbStockQuantity";
            tbStockQuantity.PasswordChar = '\0';
            tbStockQuantity.PrefixSuffixText = null;
            tbStockQuantity.ReadOnly = false;
            tbStockQuantity.RightToLeft = RightToLeft.No;
            tbStockQuantity.SelectedText = "";
            tbStockQuantity.SelectionLength = 0;
            tbStockQuantity.SelectionStart = 0;
            tbStockQuantity.ShortcutsEnabled = true;
            tbStockQuantity.Size = new Size(205, 48);
            tbStockQuantity.TabIndex = 3;
            tbStockQuantity.TabStop = false;
            tbStockQuantity.TextAlign = HorizontalAlignment.Left;
            tbStockQuantity.TrailingIcon = null;
            tbStockQuantity.UseSystemPasswordChar = false;
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
            materialLabel5.Size = new Size(118, 19);
            materialLabel5.TabIndex = 0;
            materialLabel5.Text = "Stock disponible";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(cbArticleSubcategory);
            panel3.Controls.Add(materialLabel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(235, 120);
            panel3.Margin = new Padding(0);
            panel3.MinimumSize = new Size(0, 120);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(236, 120);
            panel3.TabIndex = 9;
            // 
            // cbArticleSubcategory
            // 
            cbArticleSubcategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbArticleSubcategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbArticleSubcategory.Dock = DockStyle.Fill;
            cbArticleSubcategory.DrawMode = DrawMode.OwnerDrawFixed;
            cbArticleSubcategory.FlatStyle = FlatStyle.Flat;
            cbArticleSubcategory.Font = new Font("Segoe UI", 12F);
            cbArticleSubcategory.FormattingEnabled = true;
            cbArticleSubcategory.ItemHeight = 40;
            cbArticleSubcategory.Location = new Point(15, 34);
            cbArticleSubcategory.Name = "cbArticleSubcategory";
            cbArticleSubcategory.Size = new Size(206, 46);
            cbArticleSubcategory.TabIndex = 3;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Dock = DockStyle.Top;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(15, 15);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(95, 19);
            materialLabel3.TabIndex = 0;
            materialLabel3.Text = "Subcategoría";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(cbArticleCategory);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 120);
            panel2.Margin = new Padding(0);
            panel2.MinimumSize = new Size(0, 120);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(235, 120);
            panel2.TabIndex = 8;
            // 
            // cbArticleCategory
            // 
            cbArticleCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbArticleCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbArticleCategory.Dock = DockStyle.Fill;
            cbArticleCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cbArticleCategory.FlatStyle = FlatStyle.Flat;
            cbArticleCategory.Font = new Font("Segoe UI", 12F);
            cbArticleCategory.FormattingEnabled = true;
            cbArticleCategory.ItemHeight = 40;
            cbArticleCategory.Location = new Point(15, 34);
            cbArticleCategory.Name = "cbArticleCategory";
            cbArticleCategory.Size = new Size(205, 46);
            cbArticleCategory.TabIndex = 3;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Top;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(15, 15);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(69, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Categoría";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(cbArticleDescription);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(235, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 120);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(236, 120);
            panel1.TabIndex = 7;
            // 
            // cbArticleDescription
            // 
            cbArticleDescription.AnimateReadOnly = false;
            cbArticleDescription.AutoCompleteMode = AutoCompleteMode.None;
            cbArticleDescription.AutoCompleteSource = AutoCompleteSource.None;
            cbArticleDescription.BackgroundImageLayout = ImageLayout.None;
            cbArticleDescription.CharacterCasing = CharacterCasing.Normal;
            cbArticleDescription.Depth = 0;
            cbArticleDescription.Dock = DockStyle.Fill;
            cbArticleDescription.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            cbArticleDescription.HideSelection = true;
            cbArticleDescription.LeadingIcon = null;
            cbArticleDescription.Location = new Point(15, 34);
            cbArticleDescription.MaxLength = 32767;
            cbArticleDescription.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cbArticleDescription.Name = "cbArticleDescription";
            cbArticleDescription.PasswordChar = '\0';
            cbArticleDescription.PrefixSuffixText = null;
            cbArticleDescription.ReadOnly = false;
            cbArticleDescription.RightToLeft = RightToLeft.No;
            cbArticleDescription.SelectedText = "";
            cbArticleDescription.SelectionLength = 0;
            cbArticleDescription.SelectionStart = 0;
            cbArticleDescription.ShortcutsEnabled = true;
            cbArticleDescription.Size = new Size(206, 48);
            cbArticleDescription.TabIndex = 5;
            cbArticleDescription.TabStop = false;
            cbArticleDescription.TextAlign = HorizontalAlignment.Left;
            cbArticleDescription.TrailingIcon = null;
            cbArticleDescription.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Top;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(15, 15);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(84, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Descripción";
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.Controls.Add(cbArticleName);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.MinimumSize = new Size(0, 120);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(235, 120);
            panel5.TabIndex = 5;
            // 
            // cbArticleName
            // 
            cbArticleName.AnimateReadOnly = false;
            cbArticleName.AutoCompleteMode = AutoCompleteMode.None;
            cbArticleName.AutoCompleteSource = AutoCompleteSource.None;
            cbArticleName.BackgroundImageLayout = ImageLayout.None;
            cbArticleName.CharacterCasing = CharacterCasing.Normal;
            cbArticleName.Depth = 0;
            cbArticleName.Dock = DockStyle.Fill;
            cbArticleName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            cbArticleName.HideSelection = true;
            cbArticleName.LeadingIcon = null;
            cbArticleName.Location = new Point(15, 34);
            cbArticleName.MaxLength = 32767;
            cbArticleName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cbArticleName.Name = "cbArticleName";
            cbArticleName.PasswordChar = '\0';
            cbArticleName.PrefixSuffixText = null;
            cbArticleName.ReadOnly = false;
            cbArticleName.RightToLeft = RightToLeft.No;
            cbArticleName.SelectedText = "";
            cbArticleName.SelectionLength = 0;
            cbArticleName.SelectionStart = 0;
            cbArticleName.ShortcutsEnabled = true;
            cbArticleName.Size = new Size(205, 48);
            cbArticleName.TabIndex = 3;
            cbArticleName.TabStop = false;
            cbArticleName.TextAlign = HorizontalAlignment.Left;
            cbArticleName.TrailingIcon = null;
            cbArticleName.UseSystemPasswordChar = false;
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
            materialLabel4.Size = new Size(57, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "Nombre";
            // 
            // Article
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepArticleAdd);
            Name = "Article";
            Size = new Size(545, 655);
            mepArticleAdd.ResumeLayout(false);
            mepArticleAdd.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            gbRegisterData.ResumeLayout(false);
            gbRegisterData.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.MaterialExpansionPanelNonCollapsible mepArticleAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel9;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbArticleCode;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel9;
        private Panel panel6;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbStockCost;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel6;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbStockQuantity;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private Panel panel3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit cbArticleDescription;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit cbArticleName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private Panel panel8;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSellPrice;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel8;
        private Panel panel7;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbCostProfit;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel7;
        private ReaLTaiizor.Controls.HopeComboBox cbArticleSubcategory;
        private ReaLTaiizor.Controls.HopeComboBox cbArticleCategory;
    }
}
