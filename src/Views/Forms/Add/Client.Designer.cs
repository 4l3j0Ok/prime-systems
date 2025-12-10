namespace PrimeSystems.Views.Forms.Add
{
    partial class Client
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
            mepClientAdd = new PrimeSystems.Views.Controls.MaterialExpansionPanelNonCollapsible();
            tableLayoutPanel3 = new TableLayoutPanel();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel4 = new Panel();
            tbClientEmail = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel3 = new Panel();
            tbClientPhone = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            tbClientEntity = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1 = new Panel();
            tbClientCuit = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel5 = new Panel();
            tbClientrName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            mepClientAdd.SuspendLayout();
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
            // mepClientAdd
            // 
            mepClientAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mepClientAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepClientAdd.CancelButtonText = "Cancelar";
            mepClientAdd.Controls.Add(tableLayoutPanel3);
            mepClientAdd.Depth = 0;
            mepClientAdd.Description = "";
            mepClientAdd.Dock = DockStyle.Fill;
            mepClientAdd.ExpandHeight = 478;
            mepClientAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepClientAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepClientAdd.Location = new Point(0, 0);
            mepClientAdd.Margin = new Padding(3, 16, 3, 16);
            mepClientAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepClientAdd.Name = "mepClientAdd";
            mepClientAdd.Padding = new Padding(24, 64, 24, 70);
            mepClientAdd.ShowCollapseExpand = false;
            mepClientAdd.Size = new Size(959, 478);
            mepClientAdd.TabIndex = 5;
            mepClientAdd.Title = "Registrar Cliente";
            mepClientAdd.ValidationButtonEnable = true;
            mepClientAdd.ValidationButtonText = "Guardar";
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
            tableLayoutPanel3.Size = new Size(911, 344);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // gbRegisterData
            // 
            gbRegisterData.Controls.Add(tableLayoutPanel4);
            gbRegisterData.Dock = DockStyle.Top;
            gbRegisterData.Location = new Point(3, 3);
            gbRegisterData.Name = "gbRegisterData";
            gbRegisterData.Padding = new Padding(10);
            gbRegisterData.Size = new Size(905, 397);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de cliente";
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
            tableLayoutPanel4.Size = new Size(885, 361);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Controls.Add(tbClientEmail);
            panel4.Controls.Add(materialLabel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(442, 240);
            panel4.Margin = new Padding(0);
            panel4.MinimumSize = new Size(0, 120);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);
            panel4.Size = new Size(443, 121);
            panel4.TabIndex = 10;
            // 
            // tbClientEmail
            // 
            tbClientEmail.AnimateReadOnly = false;
            tbClientEmail.AutoCompleteMode = AutoCompleteMode.None;
            tbClientEmail.AutoCompleteSource = AutoCompleteSource.None;
            tbClientEmail.BackgroundImageLayout = ImageLayout.None;
            tbClientEmail.CharacterCasing = CharacterCasing.Normal;
            tbClientEmail.Depth = 0;
            tbClientEmail.Dock = DockStyle.Fill;
            tbClientEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbClientEmail.HideSelection = true;
            tbClientEmail.LeadingIcon = null;
            tbClientEmail.Location = new Point(15, 34);
            tbClientEmail.MaxLength = 40;
            tbClientEmail.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbClientEmail.Name = "tbClientEmail";
            tbClientEmail.PasswordChar = '\0';
            tbClientEmail.PrefixSuffixText = null;
            tbClientEmail.ReadOnly = false;
            tbClientEmail.RightToLeft = RightToLeft.No;
            tbClientEmail.SelectedText = "";
            tbClientEmail.SelectionLength = 0;
            tbClientEmail.SelectionStart = 0;
            tbClientEmail.ShortcutsEnabled = true;
            tbClientEmail.Size = new Size(413, 48);
            tbClientEmail.TabIndex = 3;
            tbClientEmail.TabStop = false;
            tbClientEmail.TextAlign = HorizontalAlignment.Left;
            tbClientEmail.TrailingIcon = null;
            tbClientEmail.UseSystemPasswordChar = false;
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
            panel3.Controls.Add(tbClientPhone);
            panel3.Controls.Add(materialLabel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 240);
            panel3.Margin = new Padding(0);
            panel3.MinimumSize = new Size(0, 120);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(442, 121);
            panel3.TabIndex = 9;
            // 
            // tbClientPhone
            // 
            tbClientPhone.AnimateReadOnly = false;
            tbClientPhone.AutoCompleteMode = AutoCompleteMode.None;
            tbClientPhone.AutoCompleteSource = AutoCompleteSource.None;
            tbClientPhone.BackgroundImageLayout = ImageLayout.None;
            tbClientPhone.CharacterCasing = CharacterCasing.Normal;
            tbClientPhone.Depth = 0;
            tbClientPhone.Dock = DockStyle.Fill;
            tbClientPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbClientPhone.HideSelection = true;
            tbClientPhone.LeadingIcon = null;
            tbClientPhone.Location = new Point(15, 34);
            tbClientPhone.MaxLength = 15;
            tbClientPhone.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbClientPhone.Name = "tbClientPhone";
            tbClientPhone.PasswordChar = '\0';
            tbClientPhone.PrefixSuffixText = null;
            tbClientPhone.ReadOnly = false;
            tbClientPhone.RightToLeft = RightToLeft.No;
            tbClientPhone.SelectedText = "";
            tbClientPhone.SelectionLength = 0;
            tbClientPhone.SelectionStart = 0;
            tbClientPhone.ShortcutsEnabled = true;
            tbClientPhone.Size = new Size(412, 48);
            tbClientPhone.TabIndex = 3;
            tbClientPhone.TabStop = false;
            tbClientPhone.TextAlign = HorizontalAlignment.Left;
            tbClientPhone.TrailingIcon = null;
            tbClientPhone.UseSystemPasswordChar = false;
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
            panel2.Controls.Add(tbClientEntity);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(442, 120);
            panel2.Margin = new Padding(0);
            panel2.MinimumSize = new Size(0, 120);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(443, 120);
            panel2.TabIndex = 8;
            // 
            // tbClientEntity
            // 
            tbClientEntity.AnimateReadOnly = false;
            tbClientEntity.AutoCompleteMode = AutoCompleteMode.None;
            tbClientEntity.AutoCompleteSource = AutoCompleteSource.None;
            tbClientEntity.BackgroundImageLayout = ImageLayout.None;
            tbClientEntity.CharacterCasing = CharacterCasing.Normal;
            tbClientEntity.Depth = 0;
            tbClientEntity.Dock = DockStyle.Fill;
            tbClientEntity.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbClientEntity.HideSelection = true;
            tbClientEntity.LeadingIcon = null;
            tbClientEntity.Location = new Point(15, 34);
            tbClientEntity.MaxLength = 40;
            tbClientEntity.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbClientEntity.Name = "tbClientEntity";
            tbClientEntity.PasswordChar = '\0';
            tbClientEntity.PrefixSuffixText = null;
            tbClientEntity.ReadOnly = false;
            tbClientEntity.RightToLeft = RightToLeft.No;
            tbClientEntity.SelectedText = "";
            tbClientEntity.SelectionLength = 0;
            tbClientEntity.SelectionStart = 0;
            tbClientEntity.ShortcutsEnabled = true;
            tbClientEntity.Size = new Size(413, 48);
            tbClientEntity.TabIndex = 3;
            tbClientEntity.TabStop = false;
            tbClientEntity.TextAlign = HorizontalAlignment.Left;
            tbClientEntity.TrailingIcon = null;
            tbClientEntity.UseSystemPasswordChar = false;
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
            materialLabel2.Size = new Size(55, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Entidad";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tbClientCuit);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 120);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 120);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(442, 120);
            panel1.TabIndex = 7;
            // 
            // tbClientCuit
            // 
            tbClientCuit.AnimateReadOnly = false;
            tbClientCuit.AutoCompleteMode = AutoCompleteMode.None;
            tbClientCuit.AutoCompleteSource = AutoCompleteSource.None;
            tbClientCuit.BackgroundImageLayout = ImageLayout.None;
            tbClientCuit.CharacterCasing = CharacterCasing.Normal;
            tbClientCuit.Depth = 0;
            tbClientCuit.Dock = DockStyle.Fill;
            tbClientCuit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbClientCuit.HideSelection = true;
            tbClientCuit.LeadingIcon = null;
            tbClientCuit.Location = new Point(15, 34);
            tbClientCuit.MaxLength = 11;
            tbClientCuit.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbClientCuit.Name = "tbClientCuit";
            tbClientCuit.PasswordChar = '\0';
            tbClientCuit.PrefixSuffixText = null;
            tbClientCuit.ReadOnly = false;
            tbClientCuit.RightToLeft = RightToLeft.No;
            tbClientCuit.SelectedText = "";
            tbClientCuit.SelectionLength = 0;
            tbClientCuit.SelectionStart = 0;
            tbClientCuit.ShortcutsEnabled = true;
            tbClientCuit.Size = new Size(412, 48);
            tbClientCuit.TabIndex = 5;
            tbClientCuit.TabStop = false;
            tbClientCuit.TextAlign = HorizontalAlignment.Left;
            tbClientCuit.TrailingIcon = null;
            tbClientCuit.UseSystemPasswordChar = false;
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
            panel5.Controls.Add(tbClientrName);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.MinimumSize = new Size(0, 120);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(885, 120);
            panel5.TabIndex = 5;
            // 
            // tbClientrName
            // 
            tbClientrName.AnimateReadOnly = false;
            tbClientrName.AutoCompleteMode = AutoCompleteMode.None;
            tbClientrName.AutoCompleteSource = AutoCompleteSource.None;
            tbClientrName.BackgroundImageLayout = ImageLayout.None;
            tbClientrName.CharacterCasing = CharacterCasing.Normal;
            tbClientrName.Depth = 0;
            tbClientrName.Dock = DockStyle.Fill;
            tbClientrName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbClientrName.HideSelection = true;
            tbClientrName.LeadingIcon = null;
            tbClientrName.Location = new Point(15, 34);
            tbClientrName.MaxLength = 32767;
            tbClientrName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbClientrName.Name = "tbClientrName";
            tbClientrName.PasswordChar = '\0';
            tbClientrName.PrefixSuffixText = null;
            tbClientrName.ReadOnly = false;
            tbClientrName.RightToLeft = RightToLeft.No;
            tbClientrName.SelectedText = "";
            tbClientrName.SelectionLength = 0;
            tbClientrName.SelectionStart = 0;
            tbClientrName.ShortcutsEnabled = true;
            tbClientrName.Size = new Size(855, 48);
            tbClientrName.TabIndex = 3;
            tbClientrName.TabStop = false;
            tbClientrName.TextAlign = HorizontalAlignment.Left;
            tbClientrName.TrailingIcon = null;
            tbClientrName.UseSystemPasswordChar = false;
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
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepClientAdd);
            Name = "Client";
            Size = new Size(959, 478);
            mepClientAdd.ResumeLayout(false);
            mepClientAdd.PerformLayout();
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

        private Controls.MaterialExpansionPanelNonCollapsible mepClientAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbClientEmail;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private Panel panel3;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbClientPhone;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbClientEntity;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbClientCuit;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbClientrName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
    }
}
