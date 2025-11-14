namespace PrimeSystems.Views.Forms.Add
{
    partial class Supplier
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
            mepSupplierAdd = new PrimeSystems.Views.Controls.MaterialExpansionPanelNonCollapsible();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel4 = new Panel();
            tbSupplierEmail = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel3 = new Panel();
            tbSupplierPhone = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            tbSupplierContactName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1 = new Panel();
            tbSupplierCuit = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel5 = new Panel();
            tbSupplierName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            mepSupplierAdd.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbRegisterData.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // mepSupplierAdd
            // 
            mepSupplierAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mepSupplierAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepSupplierAdd.CancelButtonText = "Cancelar";
            mepSupplierAdd.Controls.Add(tableLayoutPanel3);
            mepSupplierAdd.Depth = 0;
            mepSupplierAdd.Description = "";
            mepSupplierAdd.Dock = DockStyle.Fill;
            mepSupplierAdd.ExpandHeight = 511;
            mepSupplierAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepSupplierAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepSupplierAdd.Location = new Point(0, 0);
            mepSupplierAdd.Margin = new Padding(3, 16, 3, 16);
            mepSupplierAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepSupplierAdd.Name = "mepSupplierAdd";
            mepSupplierAdd.Padding = new Padding(24, 64, 24, 70);
            mepSupplierAdd.ShowCollapseExpand = false;
            mepSupplierAdd.Size = new Size(844, 511);
            mepSupplierAdd.TabIndex = 4;
            mepSupplierAdd.Title = "Registrar Compra";
            mepSupplierAdd.ValidationButtonEnable = true;
            mepSupplierAdd.ValidationButtonText = "Guardar";
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
            tableLayoutPanel3.Size = new Size(796, 377);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // gbRegisterData
            // 
            gbRegisterData.Controls.Add(tableLayoutPanel4);
            gbRegisterData.Dock = DockStyle.Top;
            gbRegisterData.Location = new Point(3, 3);
            gbRegisterData.Name = "gbRegisterData";
            gbRegisterData.Padding = new Padding(10);
            gbRegisterData.Size = new Size(790, 397);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de registro";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(panel4, 0, 2);
            tableLayoutPanel4.Controls.Add(panel3, 1, 1);
            tableLayoutPanel4.Controls.Add(panel2, 0, 1);
            tableLayoutPanel4.Controls.Add(panel1, 1, 0);
            tableLayoutPanel4.Controls.Add(panel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 26);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(770, 361);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Controls.Add(tbSupplierEmail);
            panel4.Controls.Add(materialLabel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(385, 240);
            panel4.Margin = new Padding(0);
            panel4.MinimumSize = new Size(0, 120);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);
            panel4.Size = new Size(385, 121);
            panel4.TabIndex = 10;
            // 
            // tbSupplierEmail
            // 
            tbSupplierEmail.AnimateReadOnly = false;
            tbSupplierEmail.AutoCompleteMode = AutoCompleteMode.None;
            tbSupplierEmail.AutoCompleteSource = AutoCompleteSource.None;
            tbSupplierEmail.BackgroundImageLayout = ImageLayout.None;
            tbSupplierEmail.CharacterCasing = CharacterCasing.Normal;
            tbSupplierEmail.Depth = 0;
            tbSupplierEmail.Dock = DockStyle.Fill;
            tbSupplierEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSupplierEmail.HideSelection = true;
            tbSupplierEmail.LeadingIcon = null;
            tbSupplierEmail.Location = new Point(15, 34);
            tbSupplierEmail.MaxLength = 32767;
            tbSupplierEmail.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSupplierEmail.Name = "tbSupplierEmail";
            tbSupplierEmail.PasswordChar = '\0';
            tbSupplierEmail.PrefixSuffixText = null;
            tbSupplierEmail.ReadOnly = false;
            tbSupplierEmail.RightToLeft = RightToLeft.No;
            tbSupplierEmail.SelectedText = "";
            tbSupplierEmail.SelectionLength = 0;
            tbSupplierEmail.SelectionStart = 0;
            tbSupplierEmail.ShortcutsEnabled = true;
            tbSupplierEmail.Size = new Size(355, 48);
            tbSupplierEmail.TabIndex = 3;
            tbSupplierEmail.TabStop = false;
            tbSupplierEmail.TextAlign = HorizontalAlignment.Left;
            tbSupplierEmail.TrailingIcon = null;
            tbSupplierEmail.UseSystemPasswordChar = false;
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
            materialLabel5.Size = new Size(41, 19);
            materialLabel5.TabIndex = 0;
            materialLabel5.Text = "Email";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(tbSupplierPhone);
            panel3.Controls.Add(materialLabel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 240);
            panel3.Margin = new Padding(0);
            panel3.MinimumSize = new Size(0, 120);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(385, 121);
            panel3.TabIndex = 9;
            // 
            // tbSupplierPhone
            // 
            tbSupplierPhone.AnimateReadOnly = false;
            tbSupplierPhone.AutoCompleteMode = AutoCompleteMode.None;
            tbSupplierPhone.AutoCompleteSource = AutoCompleteSource.None;
            tbSupplierPhone.BackgroundImageLayout = ImageLayout.None;
            tbSupplierPhone.CharacterCasing = CharacterCasing.Normal;
            tbSupplierPhone.Depth = 0;
            tbSupplierPhone.Dock = DockStyle.Fill;
            tbSupplierPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSupplierPhone.HideSelection = true;
            tbSupplierPhone.LeadingIcon = null;
            tbSupplierPhone.Location = new Point(15, 34);
            tbSupplierPhone.MaxLength = 32767;
            tbSupplierPhone.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSupplierPhone.Name = "tbSupplierPhone";
            tbSupplierPhone.PasswordChar = '\0';
            tbSupplierPhone.PrefixSuffixText = null;
            tbSupplierPhone.ReadOnly = false;
            tbSupplierPhone.RightToLeft = RightToLeft.No;
            tbSupplierPhone.SelectedText = "";
            tbSupplierPhone.SelectionLength = 0;
            tbSupplierPhone.SelectionStart = 0;
            tbSupplierPhone.ShortcutsEnabled = true;
            tbSupplierPhone.Size = new Size(355, 48);
            tbSupplierPhone.TabIndex = 3;
            tbSupplierPhone.TabStop = false;
            tbSupplierPhone.TextAlign = HorizontalAlignment.Left;
            tbSupplierPhone.TrailingIcon = null;
            tbSupplierPhone.UseSystemPasswordChar = false;
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
            materialLabel3.Size = new Size(151, 19);
            materialLabel3.TabIndex = 0;
            materialLabel3.Text = "Teléfono de contacto";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(tbSupplierContactName);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(385, 120);
            panel2.Margin = new Padding(0);
            panel2.MinimumSize = new Size(0, 120);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(385, 120);
            panel2.TabIndex = 8;
            // 
            // tbSupplierContactName
            // 
            tbSupplierContactName.AnimateReadOnly = false;
            tbSupplierContactName.AutoCompleteMode = AutoCompleteMode.None;
            tbSupplierContactName.AutoCompleteSource = AutoCompleteSource.None;
            tbSupplierContactName.BackgroundImageLayout = ImageLayout.None;
            tbSupplierContactName.CharacterCasing = CharacterCasing.Normal;
            tbSupplierContactName.Depth = 0;
            tbSupplierContactName.Dock = DockStyle.Fill;
            tbSupplierContactName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSupplierContactName.HideSelection = true;
            tbSupplierContactName.LeadingIcon = null;
            tbSupplierContactName.Location = new Point(15, 34);
            tbSupplierContactName.MaxLength = 32767;
            tbSupplierContactName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSupplierContactName.Name = "tbSupplierContactName";
            tbSupplierContactName.PasswordChar = '\0';
            tbSupplierContactName.PrefixSuffixText = null;
            tbSupplierContactName.ReadOnly = false;
            tbSupplierContactName.RightToLeft = RightToLeft.No;
            tbSupplierContactName.SelectedText = "";
            tbSupplierContactName.SelectionLength = 0;
            tbSupplierContactName.SelectionStart = 0;
            tbSupplierContactName.ShortcutsEnabled = true;
            tbSupplierContactName.Size = new Size(355, 48);
            tbSupplierContactName.TabIndex = 3;
            tbSupplierContactName.TabStop = false;
            tbSupplierContactName.TextAlign = HorizontalAlignment.Left;
            tbSupplierContactName.TrailingIcon = null;
            tbSupplierContactName.UseSystemPasswordChar = false;
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
            materialLabel2.Size = new Size(144, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Nombre de contacto";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tbSupplierCuit);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 120);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 120);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(385, 120);
            panel1.TabIndex = 7;
            // 
            // tbSupplierCuit
            // 
            tbSupplierCuit.AnimateReadOnly = false;
            tbSupplierCuit.AutoCompleteMode = AutoCompleteMode.None;
            tbSupplierCuit.AutoCompleteSource = AutoCompleteSource.None;
            tbSupplierCuit.BackgroundImageLayout = ImageLayout.None;
            tbSupplierCuit.CharacterCasing = CharacterCasing.Normal;
            tbSupplierCuit.Depth = 0;
            tbSupplierCuit.Dock = DockStyle.Fill;
            tbSupplierCuit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSupplierCuit.HideSelection = true;
            tbSupplierCuit.LeadingIcon = null;
            tbSupplierCuit.Location = new Point(15, 34);
            tbSupplierCuit.MaxLength = 32767;
            tbSupplierCuit.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSupplierCuit.Name = "tbSupplierCuit";
            tbSupplierCuit.PasswordChar = '\0';
            tbSupplierCuit.PrefixSuffixText = null;
            tbSupplierCuit.ReadOnly = false;
            tbSupplierCuit.RightToLeft = RightToLeft.No;
            tbSupplierCuit.SelectedText = "";
            tbSupplierCuit.SelectionLength = 0;
            tbSupplierCuit.SelectionStart = 0;
            tbSupplierCuit.ShortcutsEnabled = true;
            tbSupplierCuit.Size = new Size(355, 48);
            tbSupplierCuit.TabIndex = 5;
            tbSupplierCuit.TabStop = false;
            tbSupplierCuit.TextAlign = HorizontalAlignment.Left;
            tbSupplierCuit.TrailingIcon = null;
            tbSupplierCuit.UseSystemPasswordChar = false;
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
            materialLabel1.Size = new Size(35, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "CUIT";
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            tableLayoutPanel4.SetColumnSpan(panel5, 2);
            panel5.Controls.Add(tbSupplierName);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.MinimumSize = new Size(0, 120);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(770, 120);
            panel5.TabIndex = 5;
            // 
            // tbSupplierName
            // 
            tbSupplierName.AnimateReadOnly = false;
            tbSupplierName.AutoCompleteMode = AutoCompleteMode.None;
            tbSupplierName.AutoCompleteSource = AutoCompleteSource.None;
            tbSupplierName.BackgroundImageLayout = ImageLayout.None;
            tbSupplierName.CharacterCasing = CharacterCasing.Normal;
            tbSupplierName.Depth = 0;
            tbSupplierName.Dock = DockStyle.Fill;
            tbSupplierName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbSupplierName.HideSelection = true;
            tbSupplierName.LeadingIcon = null;
            tbSupplierName.Location = new Point(15, 34);
            tbSupplierName.MaxLength = 32767;
            tbSupplierName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbSupplierName.Name = "tbSupplierName";
            tbSupplierName.PasswordChar = '\0';
            tbSupplierName.PrefixSuffixText = null;
            tbSupplierName.ReadOnly = false;
            tbSupplierName.RightToLeft = RightToLeft.No;
            tbSupplierName.SelectedText = "";
            tbSupplierName.SelectionLength = 0;
            tbSupplierName.SelectionStart = 0;
            tbSupplierName.ShortcutsEnabled = true;
            tbSupplierName.Size = new Size(740, 48);
            tbSupplierName.TabIndex = 3;
            tbSupplierName.TabStop = false;
            tbSupplierName.TextAlign = HorizontalAlignment.Left;
            tbSupplierName.TrailingIcon = null;
            tbSupplierName.UseSystemPasswordChar = false;
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
            // Supplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepSupplierAdd);
            Name = "Supplier";
            Size = new Size(844, 511);
            mepSupplierAdd.ResumeLayout(false);
            mepSupplierAdd.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            gbRegisterData.ResumeLayout(false);
            gbRegisterData.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
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

        private Controls.MaterialExpansionPanelNonCollapsible mepSupplierAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSupplierEmail;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private Panel panel3;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSupplierPhone;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSupplierContactName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSupplierCuit;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbSupplierName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
    }
}
