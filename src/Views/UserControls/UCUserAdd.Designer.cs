using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;

using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
namespace PrimeSystems.Views

{
    partial class UCUserAdd
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            mepUserAdd = new MaterialExpansionPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel8 = new System.Windows.Forms.Panel();
            tbUserPhone = new MaterialTextBoxEdit();
            materialLabel8 = new MaterialLabel();
            panel10 = new System.Windows.Forms.Panel();
            tbUserEmail = new MaterialTextBoxEdit();
            materialLabel9 = new MaterialLabel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel6 = new System.Windows.Forms.Panel();
            tbUserPersonId = new MaterialTextBoxEdit();
            materialLabel6 = new MaterialLabel();
            panel5 = new System.Windows.Forms.Panel();
            tbUserName = new MaterialTextBoxEdit();
            materialLabel5 = new MaterialLabel();
            panel9 = new System.Windows.Forms.Panel();
            tbUserSurname = new MaterialTextBoxEdit();
            materialLabel4 = new MaterialLabel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel3 = new System.Windows.Forms.Panel();
            tbUserUsername = new MaterialTextBoxEdit();
            lblUsuario = new MaterialLabel();
            panel4 = new System.Windows.Forms.Panel();
            tbUserPasswordConfirm = new MaterialTextBoxEdit();
            materialLabel3 = new MaterialLabel();
            panel7 = new System.Windows.Forms.Panel();
            cmbRole = new MaterialComboBox();
            materialLabel7 = new MaterialLabel();
            panel11 = new System.Windows.Forms.Panel();
            tbUserPassword = new MaterialTextBoxEdit();
            materialLabel2 = new MaterialLabel();
            panel12 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pbUserProfilePicture = new ParrotPictureBox();
            btnUploadProfilePicture = new MaterialButton();
            mepUserAdd.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mepUserAdd
            // 
            mepUserAdd.AutoScroll = true;
            mepUserAdd.BackColor = Color.FromArgb(255, 255, 255);
            mepUserAdd.CancelButtonText = "Cancelar";
            mepUserAdd.Controls.Add(tableLayoutPanel2);
            mepUserAdd.Depth = 0;
            mepUserAdd.Description = "Dar de alta un nuevo usuario para la plataforma";
            mepUserAdd.Dock = DockStyle.Top;
            mepUserAdd.ExpandHeight = 655;
            mepUserAdd.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mepUserAdd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mepUserAdd.Location = new Point(0, 0);
            mepUserAdd.Margin = new Padding(3, 16, 3, 16);
            mepUserAdd.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            mepUserAdd.Name = "mepUserAdd";
            mepUserAdd.Padding = new Padding(24, 64, 24, 16);
            mepUserAdd.ShowCollapseExpand = false;
            mepUserAdd.Size = new Size(1152, 655);
            mepUserAdd.TabIndex = 0;
            mepUserAdd.Title = "Agregar usuario";
            mepUserAdd.ValidationButtonEnable = true;
            mepUserAdd.ValidationButtonText = "Guardar";
            mepUserAdd.SaveClick += mepUserAdd_SaveClick;
            mepUserAdd.CancelClick += mepUserAdd_CancelClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel2, 0, 1);
            tableLayoutPanel2.Controls.Add(panel12, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(24, 64);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 218F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1104, 575);
            tableLayoutPanel2.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 221);
            panel2.Name = "panel2";
            panel2.Size = new Size(1098, 351);
            panel2.TabIndex = 11;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel3);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 200);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1098, 100);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos de contacto";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel8, 0, 0);
            tableLayoutPanel3.Controls.Add(panel10, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1092, 78);
            tableLayoutPanel3.TabIndex = 27;
            // 
            // panel8
            // 
            panel8.Controls.Add(tbUserPhone);
            panel8.Controls.Add(materialLabel8);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(20, 0, 20, 0);
            panel8.Size = new Size(546, 78);
            panel8.TabIndex = 26;
            // 
            // tbUserPhone
            // 
            tbUserPhone.AnimateReadOnly = false;
            tbUserPhone.AutoCompleteMode = AutoCompleteMode.None;
            tbUserPhone.AutoCompleteSource = AutoCompleteSource.None;
            tbUserPhone.BackgroundImageLayout = ImageLayout.None;
            tbUserPhone.CharacterCasing = CharacterCasing.Normal;
            tbUserPhone.Depth = 0;
            tbUserPhone.Dock = DockStyle.Fill;
            tbUserPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserPhone.HideSelection = true;
            tbUserPhone.LeadingIcon = null;
            tbUserPhone.Location = new Point(20, 19);
            tbUserPhone.Margin = new Padding(3, 3, 26, 3);
            tbUserPhone.MaxLength = 32767;
            tbUserPhone.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserPhone.Name = "tbUserPhone";
            tbUserPhone.Padding = new Padding(9, 8, 9, 8);
            tbUserPhone.PasswordChar = '\0';
            tbUserPhone.PrefixSuffixText = null;
            tbUserPhone.ReadOnly = false;
            tbUserPhone.RightToLeft = RightToLeft.No;
            tbUserPhone.SelectedText = "";
            tbUserPhone.SelectionLength = 0;
            tbUserPhone.SelectionStart = 0;
            tbUserPhone.ShortcutsEnabled = true;
            tbUserPhone.Size = new Size(506, 48);
            tbUserPhone.TabIndex = 0;
            tbUserPhone.TabStop = false;
            tbUserPhone.TextAlign = HorizontalAlignment.Left;
            tbUserPhone.TrailingIcon = null;
            tbUserPhone.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Dock = DockStyle.Top;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(20, 0);
            materialLabel8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(97, 19);
            materialLabel8.TabIndex = 4;
            materialLabel8.Text = "Nro. Teléfono";
            // 
            // panel10
            // 
            panel10.Controls.Add(tbUserEmail);
            panel10.Controls.Add(materialLabel9);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(546, 0);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(20, 0, 20, 0);
            panel10.Size = new Size(546, 78);
            panel10.TabIndex = 25;
            // 
            // tbUserEmail
            // 
            tbUserEmail.AnimateReadOnly = false;
            tbUserEmail.AutoCompleteMode = AutoCompleteMode.None;
            tbUserEmail.AutoCompleteSource = AutoCompleteSource.None;
            tbUserEmail.BackgroundImageLayout = ImageLayout.None;
            tbUserEmail.CharacterCasing = CharacterCasing.Normal;
            tbUserEmail.Depth = 0;
            tbUserEmail.Dock = DockStyle.Fill;
            tbUserEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserEmail.HideSelection = true;
            tbUserEmail.LeadingIcon = null;
            tbUserEmail.Location = new Point(20, 19);
            tbUserEmail.Margin = new Padding(3, 3, 26, 3);
            tbUserEmail.MaxLength = 32767;
            tbUserEmail.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserEmail.Name = "tbUserEmail";
            tbUserEmail.Padding = new Padding(9, 8, 9, 8);
            tbUserEmail.PasswordChar = '\0';
            tbUserEmail.PrefixSuffixText = null;
            tbUserEmail.ReadOnly = false;
            tbUserEmail.RightToLeft = RightToLeft.No;
            tbUserEmail.SelectedText = "";
            tbUserEmail.SelectionLength = 0;
            tbUserEmail.SelectionStart = 0;
            tbUserEmail.ShortcutsEnabled = true;
            tbUserEmail.Size = new Size(506, 48);
            tbUserEmail.TabIndex = 0;
            tbUserEmail.TabStop = false;
            tbUserEmail.TextAlign = HorizontalAlignment.Left;
            tbUserEmail.TrailingIcon = null;
            tbUserEmail.UseSystemPasswordChar = false;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Dock = DockStyle.Top;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(20, 0);
            materialLabel9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(128, 19);
            materialLabel9.TabIndex = 4;
            materialLabel9.Text = "Correo electrónico";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel4);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1098, 100);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos personales";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(panel6, 0, 0);
            tableLayoutPanel4.Controls.Add(panel5, 1, 0);
            tableLayoutPanel4.Controls.Add(panel9, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 19);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(1092, 78);
            tableLayoutPanel4.TabIndex = 30;
            // 
            // panel6
            // 
            panel6.Controls.Add(tbUserPersonId);
            panel6.Controls.Add(materialLabel6);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(20, 0, 20, 0);
            panel6.Size = new Size(364, 78);
            panel6.TabIndex = 24;
            // 
            // tbUserPersonId
            // 
            tbUserPersonId.AnimateReadOnly = false;
            tbUserPersonId.AutoCompleteMode = AutoCompleteMode.None;
            tbUserPersonId.AutoCompleteSource = AutoCompleteSource.None;
            tbUserPersonId.BackgroundImageLayout = ImageLayout.None;
            tbUserPersonId.CharacterCasing = CharacterCasing.Normal;
            tbUserPersonId.Depth = 0;
            tbUserPersonId.Dock = DockStyle.Fill;
            tbUserPersonId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserPersonId.HideSelection = true;
            tbUserPersonId.LeadingIcon = null;
            tbUserPersonId.Location = new Point(20, 19);
            tbUserPersonId.Margin = new Padding(3, 3, 26, 3);
            tbUserPersonId.MaxLength = 32767;
            tbUserPersonId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserPersonId.Name = "tbUserPersonId";
            tbUserPersonId.Padding = new Padding(9, 8, 9, 8);
            tbUserPersonId.PasswordChar = '\0';
            tbUserPersonId.PrefixSuffixText = null;
            tbUserPersonId.ReadOnly = false;
            tbUserPersonId.RightToLeft = RightToLeft.No;
            tbUserPersonId.SelectedText = "";
            tbUserPersonId.SelectionLength = 0;
            tbUserPersonId.SelectionStart = 0;
            tbUserPersonId.ShortcutsEnabled = true;
            tbUserPersonId.Size = new Size(324, 48);
            tbUserPersonId.TabIndex = 0;
            tbUserPersonId.TabStop = false;
            tbUserPersonId.TextAlign = HorizontalAlignment.Left;
            tbUserPersonId.TrailingIcon = null;
            tbUserPersonId.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Dock = DockStyle.Top;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(20, 0);
            materialLabel6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(83, 19);
            materialLabel6.TabIndex = 4;
            materialLabel6.Text = "Documento";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbUserName);
            panel5.Controls.Add(materialLabel5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(364, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20, 0, 20, 0);
            panel5.Size = new Size(364, 78);
            panel5.TabIndex = 27;
            // 
            // tbUserName
            // 
            tbUserName.AnimateReadOnly = false;
            tbUserName.AutoCompleteMode = AutoCompleteMode.None;
            tbUserName.AutoCompleteSource = AutoCompleteSource.None;
            tbUserName.BackgroundImageLayout = ImageLayout.None;
            tbUserName.CharacterCasing = CharacterCasing.Normal;
            tbUserName.Depth = 0;
            tbUserName.Dock = DockStyle.Fill;
            tbUserName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserName.HideSelection = true;
            tbUserName.LeadingIcon = null;
            tbUserName.Location = new Point(20, 19);
            tbUserName.Margin = new Padding(3, 3, 26, 3);
            tbUserName.MaxLength = 32767;
            tbUserName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserName.Name = "tbUserName";
            tbUserName.Padding = new Padding(9, 8, 9, 8);
            tbUserName.PasswordChar = '\0';
            tbUserName.PrefixSuffixText = null;
            tbUserName.ReadOnly = false;
            tbUserName.RightToLeft = RightToLeft.No;
            tbUserName.SelectedText = "";
            tbUserName.SelectionLength = 0;
            tbUserName.SelectionStart = 0;
            tbUserName.ShortcutsEnabled = true;
            tbUserName.Size = new Size(324, 48);
            tbUserName.TabIndex = 0;
            tbUserName.TabStop = false;
            tbUserName.TextAlign = HorizontalAlignment.Left;
            tbUserName.TrailingIcon = null;
            tbUserName.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Dock = DockStyle.Top;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(20, 0);
            materialLabel5.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(57, 19);
            materialLabel5.TabIndex = 4;
            materialLabel5.Text = "Nombre";
            // 
            // panel9
            // 
            panel9.Controls.Add(tbUserSurname);
            panel9.Controls.Add(materialLabel4);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(728, 0);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(20, 0, 20, 0);
            panel9.Size = new Size(364, 78);
            panel9.TabIndex = 29;
            // 
            // tbUserSurname
            // 
            tbUserSurname.AnimateReadOnly = false;
            tbUserSurname.AutoCompleteMode = AutoCompleteMode.None;
            tbUserSurname.AutoCompleteSource = AutoCompleteSource.None;
            tbUserSurname.BackgroundImageLayout = ImageLayout.None;
            tbUserSurname.CharacterCasing = CharacterCasing.Normal;
            tbUserSurname.Depth = 0;
            tbUserSurname.Dock = DockStyle.Fill;
            tbUserSurname.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserSurname.HideSelection = true;
            tbUserSurname.LeadingIcon = null;
            tbUserSurname.Location = new Point(20, 19);
            tbUserSurname.Margin = new Padding(3, 3, 26, 3);
            tbUserSurname.MaxLength = 32767;
            tbUserSurname.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserSurname.Name = "tbUserSurname";
            tbUserSurname.Padding = new Padding(9, 8, 9, 8);
            tbUserSurname.PasswordChar = '\0';
            tbUserSurname.PrefixSuffixText = null;
            tbUserSurname.ReadOnly = false;
            tbUserSurname.RightToLeft = RightToLeft.No;
            tbUserSurname.SelectedText = "";
            tbUserSurname.SelectionLength = 0;
            tbUserSurname.SelectionStart = 0;
            tbUserSurname.ShortcutsEnabled = true;
            tbUserSurname.Size = new Size(324, 48);
            tbUserSurname.TabIndex = 0;
            tbUserSurname.TabStop = false;
            tbUserSurname.TextAlign = HorizontalAlignment.Left;
            tbUserSurname.TrailingIcon = null;
            tbUserSurname.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Dock = DockStyle.Top;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(20, 0);
            materialLabel4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(58, 19);
            materialLabel4.TabIndex = 4;
            materialLabel4.Text = "Apellido";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel5);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1098, 100);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del sistema";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 4;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(panel3, 0, 0);
            tableLayoutPanel5.Controls.Add(panel4, 2, 0);
            tableLayoutPanel5.Controls.Add(panel7, 3, 0);
            tableLayoutPanel5.Controls.Add(panel11, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 19);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1092, 78);
            tableLayoutPanel5.TabIndex = 29;
            // 
            // panel3
            // 
            panel3.Controls.Add(tbUserUsername);
            panel3.Controls.Add(lblUsuario);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20, 0, 20, 0);
            panel3.Size = new Size(273, 78);
            panel3.TabIndex = 21;
            // 
            // tbUserUsername
            // 
            tbUserUsername.AnimateReadOnly = false;
            tbUserUsername.AutoCompleteMode = AutoCompleteMode.None;
            tbUserUsername.AutoCompleteSource = AutoCompleteSource.None;
            tbUserUsername.BackgroundImageLayout = ImageLayout.None;
            tbUserUsername.CharacterCasing = CharacterCasing.Normal;
            tbUserUsername.Depth = 0;
            tbUserUsername.Dock = DockStyle.Fill;
            tbUserUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserUsername.HideSelection = true;
            tbUserUsername.LeadingIcon = null;
            tbUserUsername.Location = new Point(20, 19);
            tbUserUsername.Margin = new Padding(3, 3, 26, 3);
            tbUserUsername.MaxLength = 32767;
            tbUserUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserUsername.Name = "tbUserUsername";
            tbUserUsername.Padding = new Padding(9, 8, 9, 8);
            tbUserUsername.PasswordChar = '\0';
            tbUserUsername.PrefixSuffixText = null;
            tbUserUsername.ReadOnly = false;
            tbUserUsername.RightToLeft = RightToLeft.No;
            tbUserUsername.SelectedText = "";
            tbUserUsername.SelectionLength = 0;
            tbUserUsername.SelectionStart = 0;
            tbUserUsername.ShortcutsEnabled = true;
            tbUserUsername.Size = new Size(233, 48);
            tbUserUsername.TabIndex = 0;
            tbUserUsername.TabStop = false;
            tbUserUsername.TextAlign = HorizontalAlignment.Left;
            tbUserUsername.TrailingIcon = null;
            tbUserUsername.UseSystemPasswordChar = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Depth = 0;
            lblUsuario.Dock = DockStyle.Top;
            lblUsuario.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsuario.Location = new Point(20, 0);
            lblUsuario.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(135, 19);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Nombre de usuario";
            // 
            // panel4
            // 
            panel4.Controls.Add(tbUserPasswordConfirm);
            panel4.Controls.Add(materialLabel3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(546, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(20, 0, 20, 0);
            panel4.Size = new Size(273, 78);
            panel4.TabIndex = 23;
            // 
            // tbUserPasswordConfirm
            // 
            tbUserPasswordConfirm.AnimateReadOnly = false;
            tbUserPasswordConfirm.AutoCompleteMode = AutoCompleteMode.None;
            tbUserPasswordConfirm.AutoCompleteSource = AutoCompleteSource.None;
            tbUserPasswordConfirm.BackgroundImageLayout = ImageLayout.None;
            tbUserPasswordConfirm.CharacterCasing = CharacterCasing.Normal;
            tbUserPasswordConfirm.Depth = 0;
            tbUserPasswordConfirm.Dock = DockStyle.Fill;
            tbUserPasswordConfirm.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserPasswordConfirm.HideSelection = true;
            tbUserPasswordConfirm.LeadingIcon = null;
            tbUserPasswordConfirm.Location = new Point(20, 19);
            tbUserPasswordConfirm.Margin = new Padding(3, 3, 26, 3);
            tbUserPasswordConfirm.MaxLength = 32767;
            tbUserPasswordConfirm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserPasswordConfirm.Name = "tbUserPasswordConfirm";
            tbUserPasswordConfirm.Padding = new Padding(9, 8, 9, 8);
            tbUserPasswordConfirm.PasswordChar = '●';
            tbUserPasswordConfirm.PrefixSuffixText = null;
            tbUserPasswordConfirm.ReadOnly = false;
            tbUserPasswordConfirm.RightToLeft = RightToLeft.No;
            tbUserPasswordConfirm.SelectedText = "";
            tbUserPasswordConfirm.SelectionLength = 0;
            tbUserPasswordConfirm.SelectionStart = 0;
            tbUserPasswordConfirm.ShortcutsEnabled = true;
            tbUserPasswordConfirm.Size = new Size(233, 48);
            tbUserPasswordConfirm.TabIndex = 0;
            tbUserPasswordConfirm.TabStop = false;
            tbUserPasswordConfirm.TextAlign = HorizontalAlignment.Left;
            tbUserPasswordConfirm.TrailingIcon = null;
            tbUserPasswordConfirm.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Dock = DockStyle.Top;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(20, 0);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(155, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Confirmar contraseña";
            // 
            // panel7
            // 
            panel7.Controls.Add(cmbRole);
            panel7.Controls.Add(materialLabel7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(819, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(20, 0, 20, 0);
            panel7.Size = new Size(273, 78);
            panel7.TabIndex = 28;
            // 
            // cmbRole
            // 
            cmbRole.AutoResize = false;
            cmbRole.BackColor = Color.FromArgb(255, 255, 255);
            cmbRole.Depth = 0;
            cmbRole.Dock = DockStyle.Top;
            cmbRole.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRole.DropDownHeight = 174;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.DropDownWidth = 121;
            cmbRole.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRole.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRole.FormattingEnabled = true;
            cmbRole.IntegralHeight = false;
            cmbRole.ItemHeight = 43;
            cmbRole.Location = new Point(20, 19);
            cmbRole.MaxDropDownItems = 4;
            cmbRole.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(233, 49);
            cmbRole.StartIndex = 0;
            cmbRole.TabIndex = 9;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Dock = DockStyle.Top;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(20, 0);
            materialLabel7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(24, 19);
            materialLabel7.TabIndex = 4;
            materialLabel7.Text = "Rol";
            // 
            // panel11
            // 
            panel11.Controls.Add(tbUserPassword);
            panel11.Controls.Add(materialLabel2);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(273, 0);
            panel11.Margin = new Padding(0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(20, 0, 20, 0);
            panel11.Size = new Size(273, 78);
            panel11.TabIndex = 22;
            // 
            // tbUserPassword
            // 
            tbUserPassword.AnimateReadOnly = false;
            tbUserPassword.AutoCompleteMode = AutoCompleteMode.None;
            tbUserPassword.AutoCompleteSource = AutoCompleteSource.None;
            tbUserPassword.BackgroundImageLayout = ImageLayout.None;
            tbUserPassword.CharacterCasing = CharacterCasing.Normal;
            tbUserPassword.Depth = 0;
            tbUserPassword.Dock = DockStyle.Fill;
            tbUserPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUserPassword.HideSelection = true;
            tbUserPassword.LeadingIcon = null;
            tbUserPassword.Location = new Point(20, 19);
            tbUserPassword.Margin = new Padding(3, 3, 26, 3);
            tbUserPassword.MaxLength = 32767;
            tbUserPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUserPassword.Name = "tbUserPassword";
            tbUserPassword.Padding = new Padding(9, 8, 9, 8);
            tbUserPassword.PasswordChar = '●';
            tbUserPassword.PrefixSuffixText = null;
            tbUserPassword.ReadOnly = false;
            tbUserPassword.RightToLeft = RightToLeft.No;
            tbUserPassword.SelectedText = "";
            tbUserPassword.SelectionLength = 0;
            tbUserPassword.SelectionStart = 0;
            tbUserPassword.ShortcutsEnabled = true;
            tbUserPassword.Size = new Size(233, 48);
            tbUserPassword.TabIndex = 0;
            tbUserPassword.TabStop = false;
            tbUserPassword.TextAlign = HorizontalAlignment.Left;
            tbUserPassword.TrailingIcon = null;
            tbUserPassword.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Top;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(20, 0);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(82, 19);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = "Contraseña";
            // 
            // panel12
            // 
            panel12.Controls.Add(tableLayoutPanel1);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(3, 3);
            panel12.Name = "panel12";
            panel12.Size = new Size(1098, 212);
            panel12.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pbUserProfilePicture, 0, 0);
            tableLayoutPanel1.Controls.Add(btnUploadProfilePicture, 0, 1);
            tableLayoutPanel1.Location = new Point(470, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.MaximumSize = new Size(158, 0);
            tableLayoutPanel1.MinimumSize = new Size(158, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(158, 212);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // pbUserProfilePicture
            // 
            pbUserProfilePicture.ColorLeft = Color.DodgerBlue;
            pbUserProfilePicture.ColorRight = Color.DodgerBlue;
            pbUserProfilePicture.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pbUserProfilePicture.Dock = DockStyle.Top;
            pbUserProfilePicture.FilterAlpha = 200;
            pbUserProfilePicture.FilterEnabled = false;
            pbUserProfilePicture.Image = Properties.Resources.user_placeholder;
            pbUserProfilePicture.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            pbUserProfilePicture.IsElipse = true;
            pbUserProfilePicture.IsParallax = false;
            pbUserProfilePicture.Location = new Point(3, 3);
            pbUserProfilePicture.Name = "pbUserProfilePicture";
            pbUserProfilePicture.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            pbUserProfilePicture.Size = new Size(152, 150);
            pbUserProfilePicture.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pbUserProfilePicture.TabIndex = 14;
            pbUserProfilePicture.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // btnUploadProfilePicture
            // 
            btnUploadProfilePicture.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUploadProfilePicture.Density = MaterialButton.MaterialButtonDensity.Default;
            btnUploadProfilePicture.Depth = 0;
            btnUploadProfilePicture.Dock = DockStyle.Top;
            btnUploadProfilePicture.HighEmphasis = true;
            btnUploadProfilePicture.Icon = null;
            btnUploadProfilePicture.IconType = MaterialButton.MaterialIconType.Rebase;
            btnUploadProfilePicture.Location = new Point(0, 176);
            btnUploadProfilePicture.Margin = new Padding(0, 10, 0, 0);
            btnUploadProfilePicture.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnUploadProfilePicture.Name = "btnUploadProfilePicture";
            btnUploadProfilePicture.NoAccentTextColor = Color.Empty;
            btnUploadProfilePicture.Size = new Size(158, 36);
            btnUploadProfilePicture.TabIndex = 36;
            btnUploadProfilePicture.Text = "Subir foto";
            btnUploadProfilePicture.Type = MaterialButton.MaterialButtonType.Outlined;
            btnUploadProfilePicture.UseAccentColor = false;
            btnUploadProfilePicture.UseVisualStyleBackColor = true;
            btnUploadProfilePicture.Click += btnUploadProfilePicture_Click;
            // 
            // UCUserAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(mepUserAdd);
            Margin = new Padding(0);
            Name = "UCUserAdd";
            Size = new Size(1152, 655);
            Load += UCUserAdd_Load;
            mepUserAdd.ResumeLayout(false);
            mepUserAdd.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialExpansionPanel mepUserAdd;
        private TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel8;
        private MaterialTextBoxEdit tbUserPhone;
        private MaterialLabel materialLabel8;
        private System.Windows.Forms.Panel panel10;
        private MaterialTextBoxEdit tbUserEmail;
        private MaterialLabel materialLabel9;
        private System.Windows.Forms.GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel6;
        private MaterialTextBoxEdit tbUserPersonId;
        private MaterialLabel materialLabel6;
        private System.Windows.Forms.Panel panel5;
        private MaterialTextBoxEdit tbUserName;
        private MaterialLabel materialLabel5;
        private System.Windows.Forms.Panel panel9;
        private MaterialTextBoxEdit tbUserSurname;
        private MaterialLabel materialLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel3;
        private MaterialTextBoxEdit tbUserUsername;
        private MaterialLabel lblUsuario;
        private System.Windows.Forms.Panel panel4;
        private MaterialTextBoxEdit tbUserPasswordConfirm;
        private MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel panel7;
        private MaterialComboBox cmbRole;
        private MaterialLabel materialLabel7;
        private System.Windows.Forms.Panel panel11;
        private MaterialTextBoxEdit tbUserPassword;
        private MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel12;
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialButton btnUploadProfilePicture;
        private ParrotPictureBox pbUserProfilePicture;
    }
}
