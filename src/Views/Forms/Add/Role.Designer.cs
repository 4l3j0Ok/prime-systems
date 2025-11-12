namespace PrimeSystems.Views.Forms.Add
{
    partial class Role
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
            gbRoleData = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            tbName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel5 = new Panel();
            materialTextBoxEdit1 = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel6 = new Panel();
            tbDateTime = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel7 = new Panel();
            tbCurrentUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel6 = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            materialLabel10 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel9 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel8 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel7 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel12 = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            materialCheckBox8 = new ReaLTaiizor.Controls.MaterialCheckBox();
            mepSellAdd.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            gbRoleData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            gbRegisterData.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
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
            mepSellAdd.ExpandHeight = 646;
            mepSellAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepSellAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepSellAdd.Location = new Point(0, 0);
            mepSellAdd.Margin = new Padding(3, 16, 3, 16);
            mepSellAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepSellAdd.Name = "mepSellAdd";
            mepSellAdd.Padding = new Padding(24, 64, 24, 70);
            mepSellAdd.ShowCollapseExpand = false;
            mepSellAdd.Size = new Size(1121, 646);
            mepSellAdd.TabIndex = 2;
            mepSellAdd.Title = "Registrar Venta";
            mepSellAdd.ValidationButtonEnable = true;
            mepSellAdd.ValidationButtonText = "Guardar";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(gbRoleData, 0, 1);
            tableLayoutPanel3.Controls.Add(gbRegisterData, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(24, 64);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1073, 512);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // gbRoleData
            // 
            gbRoleData.AutoSize = true;
            gbRoleData.Controls.Add(tableLayoutPanel2);
            gbRoleData.Dock = DockStyle.Fill;
            gbRoleData.Location = new Point(3, 149);
            gbRoleData.MinimumSize = new Size(0, 140);
            gbRoleData.Name = "gbRoleData";
            gbRoleData.Padding = new Padding(10);
            gbRoleData.Size = new Size(1067, 140);
            gbRoleData.TabIndex = 8;
            gbRoleData.TabStop = false;
            gbRoleData.Text = "Datos de facturación";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel1, 1, 0);
            tableLayoutPanel2.Controls.Add(panel5, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(10, 26);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1047, 104);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(523, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 100);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(524, 104);
            panel1.TabIndex = 7;
            // 
            // tbName
            // 
            tbName.AnimateReadOnly = false;
            tbName.AutoCompleteMode = AutoCompleteMode.None;
            tbName.AutoCompleteSource = AutoCompleteSource.None;
            tbName.BackgroundImageLayout = ImageLayout.None;
            tbName.CharacterCasing = CharacterCasing.Normal;
            tbName.Depth = 0;
            tbName.Dock = DockStyle.Fill;
            tbName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbName.HideSelection = true;
            tbName.Hint = "ej.: Administrador";
            tbName.LeadingIcon = null;
            tbName.Location = new Point(15, 34);
            tbName.MaxLength = 32767;
            tbName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbName.Name = "tbName";
            tbName.PasswordChar = '\0';
            tbName.PrefixSuffixText = null;
            tbName.ReadOnly = false;
            tbName.RightToLeft = RightToLeft.No;
            tbName.SelectedText = "";
            tbName.SelectionLength = 0;
            tbName.SelectionStart = 0;
            tbName.ShortcutsEnabled = true;
            tbName.Size = new Size(494, 48);
            tbName.TabIndex = 2;
            tbName.TabStop = false;
            tbName.TextAlign = HorizontalAlignment.Left;
            tbName.TrailingIcon = null;
            tbName.UseSystemPasswordChar = false;
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
            materialLabel1.Size = new Size(104, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Nombre del rol";
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.Controls.Add(materialTextBoxEdit1);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.MinimumSize = new Size(0, 100);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(523, 104);
            panel5.TabIndex = 6;
            // 
            // materialTextBoxEdit1
            // 
            materialTextBoxEdit1.AnimateReadOnly = false;
            materialTextBoxEdit1.AutoCompleteMode = AutoCompleteMode.None;
            materialTextBoxEdit1.AutoCompleteSource = AutoCompleteSource.None;
            materialTextBoxEdit1.BackgroundImageLayout = ImageLayout.None;
            materialTextBoxEdit1.CharacterCasing = CharacterCasing.Normal;
            materialTextBoxEdit1.Depth = 0;
            materialTextBoxEdit1.Dock = DockStyle.Fill;
            materialTextBoxEdit1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxEdit1.HideSelection = true;
            materialTextBoxEdit1.Hint = "ej: admin";
            materialTextBoxEdit1.LeadingIcon = null;
            materialTextBoxEdit1.Location = new Point(15, 34);
            materialTextBoxEdit1.MaxLength = 32767;
            materialTextBoxEdit1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            materialTextBoxEdit1.Name = "materialTextBoxEdit1";
            materialTextBoxEdit1.PasswordChar = '\0';
            materialTextBoxEdit1.PrefixSuffixText = null;
            materialTextBoxEdit1.ReadOnly = false;
            materialTextBoxEdit1.RightToLeft = RightToLeft.No;
            materialTextBoxEdit1.SelectedText = "";
            materialTextBoxEdit1.SelectionLength = 0;
            materialTextBoxEdit1.SelectionStart = 0;
            materialTextBoxEdit1.ShortcutsEnabled = true;
            materialTextBoxEdit1.Size = new Size(493, 48);
            materialTextBoxEdit1.TabIndex = 2;
            materialTextBoxEdit1.TabStop = false;
            materialTextBoxEdit1.TextAlign = HorizontalAlignment.Left;
            materialTextBoxEdit1.TrailingIcon = null;
            materialTextBoxEdit1.UseSystemPasswordChar = false;
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
            materialLabel4.Size = new Size(90, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "Identificador";
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
            gbRegisterData.Size = new Size(1067, 140);
            gbRegisterData.TabIndex = 4;
            gbRegisterData.TabStop = false;
            gbRegisterData.Text = "Datos de registro";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(panel6, 0, 0);
            tableLayoutPanel4.Controls.Add(panel7, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(10, 26);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(1047, 104);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(tbDateTime);
            panel6.Controls.Add(materialLabel5);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(15);
            panel6.Size = new Size(523, 104);
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
            tbDateTime.Size = new Size(493, 48);
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
            panel7.Location = new Point(523, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(15);
            panel7.Size = new Size(524, 104);
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
            tbCurrentUser.Size = new Size(494, 48);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(materialLabel10, 2, 0);
            tableLayoutPanel1.Controls.Add(materialLabel9, 1, 0);
            tableLayoutPanel1.Controls.Add(materialLabel2, 0, 0);
            tableLayoutPanel1.Controls.Add(materialLabel8, 0, 4);
            tableLayoutPanel1.Controls.Add(materialLabel7, 0, 3);
            tableLayoutPanel1.Controls.Add(materialLabel3, 0, 2);
            tableLayoutPanel1.Controls.Add(materialLabel12, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 292);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(1073, 220);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Dock = DockStyle.Fill;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(717, 0);
            materialLabel10.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(353, 44);
            materialLabel10.TabIndex = 6;
            materialLabel10.Text = "Escritura";
            materialLabel10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Dock = DockStyle.Fill;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(360, 0);
            materialLabel9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(351, 44);
            materialLabel9.TabIndex = 5;
            materialLabel9.Text = "Lectura";
            materialLabel9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Fill;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(3, 0);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(351, 44);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Módulo";
            materialLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Dock = DockStyle.Fill;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(3, 176);
            materialLabel8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(351, 44);
            materialLabel8.TabIndex = 4;
            materialLabel8.Text = "Usuarios";
            materialLabel8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Dock = DockStyle.Fill;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(3, 132);
            materialLabel7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(351, 44);
            materialLabel7.TabIndex = 3;
            materialLabel7.Text = "Estado Contable";
            materialLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Dock = DockStyle.Fill;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(3, 88);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(351, 44);
            materialLabel3.TabIndex = 2;
            materialLabel3.Text = "Compras";
            materialLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel12
            // 
            materialLabel12.AutoSize = true;
            materialLabel12.Depth = 0;
            materialLabel12.Dock = DockStyle.Fill;
            materialLabel12.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel12.Location = new Point(3, 44);
            materialLabel12.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel12.Name = "materialLabel12";
            materialLabel12.Size = new Size(351, 44);
            materialLabel12.TabIndex = 8;
            materialLabel12.Text = "Ventas";
            materialLabel12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(materialCheckBox8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(360, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(351, 38);
            panel2.TabIndex = 9;
            // 
            // materialCheckBox8
            // 
            materialCheckBox8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            materialCheckBox8.AutoSize = true;
            materialCheckBox8.CheckAlign = ContentAlignment.MiddleCenter;
            materialCheckBox8.Cursor = Cursors.Hand;
            materialCheckBox8.Depth = 0;
            materialCheckBox8.Location = new Point(161, 1);
            materialCheckBox8.Margin = new Padding(0);
            materialCheckBox8.MouseLocation = new Point(-1, -1);
            materialCheckBox8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCheckBox8.Name = "materialCheckBox8";
            materialCheckBox8.ReadOnly = false;
            materialCheckBox8.Ripple = true;
            materialCheckBox8.Size = new Size(35, 37);
            materialCheckBox8.TabIndex = 19;
            materialCheckBox8.TextAlign = ContentAlignment.MiddleCenter;
            materialCheckBox8.UseAccentColor = false;
            materialCheckBox8.UseVisualStyleBackColor = true;
            // 
            // Role
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mepSellAdd);
            Name = "Role";
            Size = new Size(1121, 646);
            mepSellAdd.ResumeLayout(false);
            mepSellAdd.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            gbRoleData.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            gbRegisterData.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.MaterialExpansionPanelNonCollapsible mepSellAdd;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbRegisterData;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel6;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbDateTime;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private Panel panel7;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbCurrentUser;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel6;
        private GroupBox gbRoleData;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit materialTextBoxEdit1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel10;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel9;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel8;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel7;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel12;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialCheckBox materialCheckBox8;
    }
}
