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
            tbRoleName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel5 = new Panel();
            tbRoleId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            gbRegisterData = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel6 = new Panel();
            tbDateTime = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            panel7 = new Panel();
            tbCurrentUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialLabel6 = new ReaLTaiizor.Controls.MaterialLabel();
            gbRolesTable = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            chbUserWrite = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbUserRead = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbFinancialStateWrite = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbFinancialStateRead = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbPurchaseWrite = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbPurchaseRead = new ReaLTaiizor.Controls.MaterialCheckBox();
            chbSellWrite = new ReaLTaiizor.Controls.MaterialCheckBox();
            materialLabel10 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel9 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel8 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel7 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel12 = new ReaLTaiizor.Controls.MaterialLabel();
            chbSellRead = new ReaLTaiizor.Controls.MaterialCheckBox();
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
            gbRolesTable.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            mepSellAdd.ExpandHeight = 455;
            mepSellAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepSellAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepSellAdd.Location = new Point(0, 0);
            mepSellAdd.Margin = new Padding(3, 16, 3, 16);
            mepSellAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepSellAdd.Name = "mepSellAdd";
            mepSellAdd.Padding = new Padding(24, 64, 24, 70);
            mepSellAdd.ShowCollapseExpand = false;
            mepSellAdd.Size = new Size(711, 455);
            mepSellAdd.TabIndex = 2;
            mepSellAdd.Title = "Nuevo Rol";
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
            tableLayoutPanel3.Controls.Add(gbRoleData, 0, 1);
            tableLayoutPanel3.Controls.Add(gbRegisterData, 0, 0);
            tableLayoutPanel3.Controls.Add(gbRolesTable, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(24, 64);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(663, 321);
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
            gbRoleData.Size = new Size(640, 140);
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
            tableLayoutPanel2.Size = new Size(620, 104);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tbRoleName);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(310, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 100);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(310, 104);
            panel1.TabIndex = 7;
            // 
            // tbRoleName
            // 
            tbRoleName.AnimateReadOnly = false;
            tbRoleName.AutoCompleteMode = AutoCompleteMode.None;
            tbRoleName.AutoCompleteSource = AutoCompleteSource.None;
            tbRoleName.BackgroundImageLayout = ImageLayout.None;
            tbRoleName.CharacterCasing = CharacterCasing.Normal;
            tbRoleName.Depth = 0;
            tbRoleName.Dock = DockStyle.Fill;
            tbRoleName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbRoleName.HideSelection = true;
            tbRoleName.Hint = "ej.: Administrador";
            tbRoleName.LeadingIcon = null;
            tbRoleName.Location = new Point(15, 34);
            tbRoleName.MaxLength = 32767;
            tbRoleName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbRoleName.Name = "tbRoleName";
            tbRoleName.PasswordChar = '\0';
            tbRoleName.PrefixSuffixText = null;
            tbRoleName.ReadOnly = false;
            tbRoleName.RightToLeft = RightToLeft.No;
            tbRoleName.SelectedText = "";
            tbRoleName.SelectionLength = 0;
            tbRoleName.SelectionStart = 0;
            tbRoleName.ShortcutsEnabled = true;
            tbRoleName.Size = new Size(280, 48);
            tbRoleName.TabIndex = 2;
            tbRoleName.TabStop = false;
            tbRoleName.TextAlign = HorizontalAlignment.Left;
            tbRoleName.TrailingIcon = null;
            tbRoleName.UseSystemPasswordChar = false;
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
            panel5.Controls.Add(tbRoleId);
            panel5.Controls.Add(materialLabel4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.MinimumSize = new Size(0, 100);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(15);
            panel5.Size = new Size(310, 104);
            panel5.TabIndex = 6;
            // 
            // tbRoleId
            // 
            tbRoleId.AnimateReadOnly = false;
            tbRoleId.AutoCompleteMode = AutoCompleteMode.None;
            tbRoleId.AutoCompleteSource = AutoCompleteSource.None;
            tbRoleId.BackgroundImageLayout = ImageLayout.None;
            tbRoleId.CharacterCasing = CharacterCasing.Normal;
            tbRoleId.Depth = 0;
            tbRoleId.Dock = DockStyle.Fill;
            tbRoleId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbRoleId.HideSelection = true;
            tbRoleId.Hint = "ej: admin";
            tbRoleId.LeadingIcon = null;
            tbRoleId.Location = new Point(15, 34);
            tbRoleId.MaxLength = 32767;
            tbRoleId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbRoleId.Name = "tbRoleId";
            tbRoleId.PasswordChar = '\0';
            tbRoleId.PrefixSuffixText = null;
            tbRoleId.ReadOnly = false;
            tbRoleId.RightToLeft = RightToLeft.No;
            tbRoleId.SelectedText = "";
            tbRoleId.SelectionLength = 0;
            tbRoleId.SelectionStart = 0;
            tbRoleId.ShortcutsEnabled = true;
            tbRoleId.Size = new Size(280, 48);
            tbRoleId.TabIndex = 2;
            tbRoleId.TabStop = false;
            tbRoleId.TextAlign = HorizontalAlignment.Left;
            tbRoleId.TrailingIcon = null;
            tbRoleId.UseSystemPasswordChar = false;
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
            gbRegisterData.Size = new Size(640, 140);
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
            tableLayoutPanel4.Size = new Size(620, 104);
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
            panel6.Size = new Size(310, 104);
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
            tbDateTime.Size = new Size(280, 48);
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
            panel7.Location = new Point(310, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(15);
            panel7.Size = new Size(310, 104);
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
            tbCurrentUser.Size = new Size(280, 48);
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
            // gbRolesTable
            // 
            gbRolesTable.Controls.Add(tableLayoutPanel1);
            gbRolesTable.Dock = DockStyle.Top;
            gbRolesTable.Location = new Point(3, 295);
            gbRolesTable.Name = "gbRolesTable";
            gbRolesTable.Size = new Size(640, 313);
            gbRolesTable.TabIndex = 9;
            gbRolesTable.TabStop = false;
            gbRolesTable.Text = "Permisos";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(chbUserWrite, 2, 4);
            tableLayoutPanel1.Controls.Add(chbUserRead, 1, 4);
            tableLayoutPanel1.Controls.Add(chbFinancialStateWrite, 2, 3);
            tableLayoutPanel1.Controls.Add(chbFinancialStateRead, 1, 3);
            tableLayoutPanel1.Controls.Add(chbPurchaseWrite, 2, 2);
            tableLayoutPanel1.Controls.Add(chbPurchaseRead, 1, 2);
            tableLayoutPanel1.Controls.Add(chbSellWrite, 2, 1);
            tableLayoutPanel1.Controls.Add(materialLabel10, 2, 0);
            tableLayoutPanel1.Controls.Add(materialLabel9, 1, 0);
            tableLayoutPanel1.Controls.Add(materialLabel2, 0, 0);
            tableLayoutPanel1.Controls.Add(materialLabel8, 0, 4);
            tableLayoutPanel1.Controls.Add(materialLabel7, 0, 3);
            tableLayoutPanel1.Controls.Add(materialLabel3, 0, 2);
            tableLayoutPanel1.Controls.Add(materialLabel12, 0, 1);
            tableLayoutPanel1.Controls.Add(chbSellRead, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.MinimumSize = new Size(0, 200);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(634, 291);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // chbUserWrite
            // 
            chbUserWrite.Anchor = AnchorStyles.None;
            chbUserWrite.AutoSize = true;
            chbUserWrite.Depth = 0;
            chbUserWrite.Location = new Point(510, 243);
            chbUserWrite.Margin = new Padding(0);
            chbUserWrite.MouseLocation = new Point(-1, -1);
            chbUserWrite.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbUserWrite.Name = "chbUserWrite";
            chbUserWrite.ReadOnly = false;
            chbUserWrite.Ripple = true;
            chbUserWrite.Size = new Size(35, 37);
            chbUserWrite.TabIndex = 16;
            chbUserWrite.UseAccentColor = false;
            chbUserWrite.UseVisualStyleBackColor = true;
            chbUserWrite.CheckedChanged += chbWrite_CheckedChanged;
            // 
            // chbUserRead
            // 
            chbUserRead.Anchor = AnchorStyles.None;
            chbUserRead.AutoSize = true;
            chbUserRead.Depth = 0;
            chbUserRead.Location = new Point(299, 243);
            chbUserRead.Margin = new Padding(0);
            chbUserRead.MouseLocation = new Point(-1, -1);
            chbUserRead.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbUserRead.Name = "chbUserRead";
            chbUserRead.ReadOnly = false;
            chbUserRead.Ripple = true;
            chbUserRead.Size = new Size(35, 37);
            chbUserRead.TabIndex = 15;
            chbUserRead.UseAccentColor = false;
            chbUserRead.UseVisualStyleBackColor = true;
            // 
            // chbFinancialStateWrite
            // 
            chbFinancialStateWrite.Anchor = AnchorStyles.None;
            chbFinancialStateWrite.AutoSize = true;
            chbFinancialStateWrite.Depth = 0;
            chbFinancialStateWrite.Location = new Point(510, 184);
            chbFinancialStateWrite.Margin = new Padding(0);
            chbFinancialStateWrite.MouseLocation = new Point(-1, -1);
            chbFinancialStateWrite.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbFinancialStateWrite.Name = "chbFinancialStateWrite";
            chbFinancialStateWrite.ReadOnly = false;
            chbFinancialStateWrite.Ripple = true;
            chbFinancialStateWrite.Size = new Size(35, 37);
            chbFinancialStateWrite.TabIndex = 14;
            chbFinancialStateWrite.UseAccentColor = false;
            chbFinancialStateWrite.UseVisualStyleBackColor = true;
            chbFinancialStateWrite.CheckedChanged += chbWrite_CheckedChanged;
            // 
            // chbFinancialStateRead
            // 
            chbFinancialStateRead.Anchor = AnchorStyles.None;
            chbFinancialStateRead.AutoSize = true;
            chbFinancialStateRead.Depth = 0;
            chbFinancialStateRead.Location = new Point(299, 184);
            chbFinancialStateRead.Margin = new Padding(0);
            chbFinancialStateRead.MouseLocation = new Point(-1, -1);
            chbFinancialStateRead.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbFinancialStateRead.Name = "chbFinancialStateRead";
            chbFinancialStateRead.ReadOnly = false;
            chbFinancialStateRead.Ripple = true;
            chbFinancialStateRead.Size = new Size(35, 37);
            chbFinancialStateRead.TabIndex = 13;
            chbFinancialStateRead.UseAccentColor = false;
            chbFinancialStateRead.UseVisualStyleBackColor = true;
            // 
            // chbPurchaseWrite
            // 
            chbPurchaseWrite.Anchor = AnchorStyles.None;
            chbPurchaseWrite.AutoSize = true;
            chbPurchaseWrite.Depth = 0;
            chbPurchaseWrite.Location = new Point(510, 126);
            chbPurchaseWrite.Margin = new Padding(0);
            chbPurchaseWrite.MouseLocation = new Point(-1, -1);
            chbPurchaseWrite.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbPurchaseWrite.Name = "chbPurchaseWrite";
            chbPurchaseWrite.ReadOnly = false;
            chbPurchaseWrite.Ripple = true;
            chbPurchaseWrite.Size = new Size(35, 37);
            chbPurchaseWrite.TabIndex = 12;
            chbPurchaseWrite.UseAccentColor = false;
            chbPurchaseWrite.UseVisualStyleBackColor = true;
            chbPurchaseWrite.CheckedChanged += chbWrite_CheckedChanged;
            // 
            // chbPurchaseRead
            // 
            chbPurchaseRead.Anchor = AnchorStyles.None;
            chbPurchaseRead.AutoSize = true;
            chbPurchaseRead.Depth = 0;
            chbPurchaseRead.Location = new Point(299, 126);
            chbPurchaseRead.Margin = new Padding(0);
            chbPurchaseRead.MouseLocation = new Point(-1, -1);
            chbPurchaseRead.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbPurchaseRead.Name = "chbPurchaseRead";
            chbPurchaseRead.ReadOnly = false;
            chbPurchaseRead.Ripple = true;
            chbPurchaseRead.Size = new Size(35, 37);
            chbPurchaseRead.TabIndex = 11;
            chbPurchaseRead.UseAccentColor = false;
            chbPurchaseRead.UseVisualStyleBackColor = true;
            // 
            // chbSellWrite
            // 
            chbSellWrite.Anchor = AnchorStyles.None;
            chbSellWrite.AutoSize = true;
            chbSellWrite.Depth = 0;
            chbSellWrite.Location = new Point(510, 68);
            chbSellWrite.Margin = new Padding(0);
            chbSellWrite.MouseLocation = new Point(-1, -1);
            chbSellWrite.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbSellWrite.Name = "chbSellWrite";
            chbSellWrite.ReadOnly = false;
            chbSellWrite.Ripple = true;
            chbSellWrite.Size = new Size(35, 37);
            chbSellWrite.TabIndex = 10;
            chbSellWrite.UseAccentColor = false;
            chbSellWrite.UseVisualStyleBackColor = true;
            chbSellWrite.CheckedChanged += chbWrite_CheckedChanged;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Dock = DockStyle.Fill;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(425, 0);
            materialLabel10.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(206, 58);
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
            materialLabel9.Location = new Point(214, 0);
            materialLabel9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(205, 58);
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
            materialLabel2.Size = new Size(205, 58);
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
            materialLabel8.Location = new Point(3, 232);
            materialLabel8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(205, 59);
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
            materialLabel7.Location = new Point(3, 174);
            materialLabel7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(205, 58);
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
            materialLabel3.Location = new Point(3, 116);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(205, 58);
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
            materialLabel12.Location = new Point(3, 58);
            materialLabel12.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel12.Name = "materialLabel12";
            materialLabel12.Size = new Size(205, 58);
            materialLabel12.TabIndex = 8;
            materialLabel12.Text = "Ventas";
            materialLabel12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chbSellRead
            // 
            chbSellRead.Anchor = AnchorStyles.None;
            chbSellRead.AutoSize = true;
            chbSellRead.Depth = 0;
            chbSellRead.Location = new Point(299, 68);
            chbSellRead.Margin = new Padding(0);
            chbSellRead.MouseLocation = new Point(-1, -1);
            chbSellRead.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            chbSellRead.Name = "chbSellRead";
            chbSellRead.ReadOnly = false;
            chbSellRead.Ripple = true;
            chbSellRead.Size = new Size(35, 37);
            chbSellRead.TabIndex = 9;
            chbSellRead.UseAccentColor = false;
            chbSellRead.UseVisualStyleBackColor = true;
            // 
            // Role
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(mepSellAdd);
            Name = "Role";
            Size = new Size(711, 455);
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
            gbRolesTable.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbRoleName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private Panel panel5;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbRoleId;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private GroupBox gbRolesTable;
        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel10;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel9;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel8;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel7;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel12;
        private ReaLTaiizor.Controls.MaterialCheckBox chbUserWrite;
        private ReaLTaiizor.Controls.MaterialCheckBox chbUserRead;
        private ReaLTaiizor.Controls.MaterialCheckBox chbFinancialStateWrite;
        private ReaLTaiizor.Controls.MaterialCheckBox chbFinancialStateRead;
        private ReaLTaiizor.Controls.MaterialCheckBox chbPurchaseWrite;
        private ReaLTaiizor.Controls.MaterialCheckBox chbPurchaseRead;
        private ReaLTaiizor.Controls.MaterialCheckBox chbSellWrite;
        private ReaLTaiizor.Controls.MaterialCheckBox chbSellRead;
    }
}
