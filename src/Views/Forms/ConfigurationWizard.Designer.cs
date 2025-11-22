namespace PrimeSystems.Views.Forms
{
    partial class ConfigurationWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationWizard));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            lblAppName = new ReaLTaiizor.Controls.MaterialLabel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnFinish = new ReaLTaiizor.Controls.MaterialButton();
            btnTestDBConnection = new ReaLTaiizor.Controls.MaterialButton();
            panel3 = new Panel();
            tbConnectionString = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            panel2 = new Panel();
            tbInitialUserPassword = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            panel4 = new Panel();
            tbInitialUser = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(514, 573);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 2);
            tableLayoutPanel2.Controls.Add(lblAppName, 0, 1);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(508, 208);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Fill;
            materialLabel1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            materialLabel1.Location = new Point(3, 169);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(502, 19);
            materialLabel1.TabIndex = 14;
            materialLabel1.Text = "Asistente de configuración";
            materialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            materialLabel1.UseAccent = true;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Depth = 0;
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblAppName.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            lblAppName.Location = new Point(3, 111);
            lblAppName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(502, 58);
            lblAppName.TabIndex = 13;
            lblAppName.Text = "Prime Systems";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Margin = new Padding(10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(488, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFinish);
            panel1.Controls.Add(btnTestDBConnection);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(tbConnectionString);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tbInitialUserPassword);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(tbInitialUser);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 217);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(150, 20, 150, 20);
            panel1.Size = new Size(508, 353);
            panel1.TabIndex = 2;
            // 
            // btnFinish
            // 
            btnFinish.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFinish.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFinish.Depth = 0;
            btnFinish.Dock = DockStyle.Bottom;
            btnFinish.HighEmphasis = true;
            btnFinish.Icon = null;
            btnFinish.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnFinish.Location = new Point(150, 297);
            btnFinish.Margin = new Padding(4, 6, 4, 6);
            btnFinish.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnFinish.Name = "btnFinish";
            btnFinish.NoAccentTextColor = Color.Empty;
            btnFinish.Size = new Size(208, 36);
            btnFinish.TabIndex = 10;
            btnFinish.Text = "Finalizar";
            btnFinish.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFinish.UseAccentColor = false;
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnTestDBConnection
            // 
            btnTestDBConnection.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTestDBConnection.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTestDBConnection.Depth = 0;
            btnTestDBConnection.Dock = DockStyle.Top;
            btnTestDBConnection.HighEmphasis = true;
            btnTestDBConnection.Icon = null;
            btnTestDBConnection.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnTestDBConnection.Location = new Point(150, 194);
            btnTestDBConnection.Margin = new Padding(4, 6, 4, 6);
            btnTestDBConnection.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnTestDBConnection.Name = "btnTestDBConnection";
            btnTestDBConnection.NoAccentTextColor = Color.Empty;
            btnTestDBConnection.Size = new Size(208, 36);
            btnTestDBConnection.TabIndex = 9;
            btnTestDBConnection.Text = "Probar conexión";
            btnTestDBConnection.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTestDBConnection.UseAccentColor = false;
            btnTestDBConnection.UseVisualStyleBackColor = true;
            btnTestDBConnection.Click += btnTestDBConnection_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(150, 184);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 10);
            panel3.TabIndex = 7;
            // 
            // tbConnectionString
            // 
            tbConnectionString.AnimateReadOnly = false;
            tbConnectionString.AutoCompleteMode = AutoCompleteMode.None;
            tbConnectionString.AutoCompleteSource = AutoCompleteSource.None;
            tbConnectionString.BackgroundImageLayout = ImageLayout.None;
            tbConnectionString.CharacterCasing = CharacterCasing.Normal;
            tbConnectionString.Depth = 0;
            tbConnectionString.Dock = DockStyle.Top;
            tbConnectionString.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbConnectionString.HelperText = "Cadena de conexión con el que la aplicación se conectará al servidor de SQL Server";
            tbConnectionString.HideSelection = true;
            tbConnectionString.Hint = "Cadena de conexión SQL Server";
            tbConnectionString.LeadingIcon = Properties.Resources.sql_server;
            tbConnectionString.Location = new Point(150, 136);
            tbConnectionString.MaxLength = 32767;
            tbConnectionString.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbConnectionString.Name = "tbConnectionString";
            tbConnectionString.PasswordChar = '\0';
            tbConnectionString.PrefixSuffixText = null;
            tbConnectionString.ReadOnly = false;
            tbConnectionString.RightToLeft = RightToLeft.No;
            tbConnectionString.SelectedText = "";
            tbConnectionString.SelectionLength = 0;
            tbConnectionString.SelectionStart = 0;
            tbConnectionString.ShortcutsEnabled = true;
            tbConnectionString.Size = new Size(208, 48);
            tbConnectionString.TabIndex = 5;
            tbConnectionString.TabStop = false;
            tbConnectionString.Text = "Server=<IP o Hostname>;Database=PrimeSystems;User Id=<usuario>;Password=<contraseña>;TrustServerCertificate=True;";
            tbConnectionString.TextAlign = HorizontalAlignment.Left;
            tbConnectionString.TrailingIcon = null;
            tbConnectionString.UseAccent = false;
            tbConnectionString.UseSystemPasswordChar = false;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(150, 126);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 10);
            panel2.TabIndex = 6;
            // 
            // tbInitialUserPassword
            // 
            tbInitialUserPassword.AnimateReadOnly = false;
            tbInitialUserPassword.AutoCompleteMode = AutoCompleteMode.None;
            tbInitialUserPassword.AutoCompleteSource = AutoCompleteSource.None;
            tbInitialUserPassword.BackgroundImageLayout = ImageLayout.None;
            tbInitialUserPassword.CharacterCasing = CharacterCasing.Normal;
            tbInitialUserPassword.Depth = 0;
            tbInitialUserPassword.Dock = DockStyle.Top;
            tbInitialUserPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbInitialUserPassword.HelperText = "Contraseña del usuario administrador";
            tbInitialUserPassword.HideSelection = true;
            tbInitialUserPassword.Hint = "Contraseña";
            tbInitialUserPassword.LeadingIcon = Properties.Resources.password;
            tbInitialUserPassword.Location = new Point(150, 78);
            tbInitialUserPassword.MaxLength = 32767;
            tbInitialUserPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbInitialUserPassword.Name = "tbInitialUserPassword";
            tbInitialUserPassword.PasswordChar = '•';
            tbInitialUserPassword.PrefixSuffixText = null;
            tbInitialUserPassword.ReadOnly = false;
            tbInitialUserPassword.RightToLeft = RightToLeft.No;
            tbInitialUserPassword.SelectedText = "";
            tbInitialUserPassword.SelectionLength = 0;
            tbInitialUserPassword.SelectionStart = 0;
            tbInitialUserPassword.ShortcutsEnabled = true;
            tbInitialUserPassword.Size = new Size(208, 48);
            tbInitialUserPassword.TabIndex = 4;
            tbInitialUserPassword.TabStop = false;
            tbInitialUserPassword.TextAlign = HorizontalAlignment.Left;
            tbInitialUserPassword.TrailingIcon = null;
            tbInitialUserPassword.UseAccent = false;
            tbInitialUserPassword.UseSystemPasswordChar = false;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(150, 68);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(208, 10);
            panel4.TabIndex = 8;
            // 
            // tbInitialUser
            // 
            tbInitialUser.AnimateReadOnly = false;
            tbInitialUser.AutoCompleteMode = AutoCompleteMode.None;
            tbInitialUser.AutoCompleteSource = AutoCompleteSource.None;
            tbInitialUser.BackgroundImageLayout = ImageLayout.None;
            tbInitialUser.CharacterCasing = CharacterCasing.Normal;
            tbInitialUser.Depth = 0;
            tbInitialUser.Dock = DockStyle.Top;
            tbInitialUser.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbInitialUser.HelperText = "Usuario inicial, con el que iniciaras sesión y tendrás permisos de administrador";
            tbInitialUser.HideSelection = true;
            tbInitialUser.Hint = "Usuario inicial";
            tbInitialUser.LeadingIcon = Properties.Resources.user;
            tbInitialUser.Location = new Point(150, 20);
            tbInitialUser.MaxLength = 32767;
            tbInitialUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbInitialUser.Name = "tbInitialUser";
            tbInitialUser.PasswordChar = '\0';
            tbInitialUser.PrefixSuffixText = null;
            tbInitialUser.ReadOnly = false;
            tbInitialUser.RightToLeft = RightToLeft.No;
            tbInitialUser.SelectedText = "";
            tbInitialUser.SelectionLength = 0;
            tbInitialUser.SelectionStart = 0;
            tbInitialUser.ShortcutsEnabled = true;
            tbInitialUser.Size = new Size(208, 48);
            tbInitialUser.TabIndex = 3;
            tbInitialUser.TabStop = false;
            tbInitialUser.TextAlign = HorizontalAlignment.Left;
            tbInitialUser.TrailingIcon = null;
            tbInitialUser.UseAccent = false;
            tbInitialUser.UseSystemPasswordChar = false;
            // 
            // ConfigurationWizard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 600);
            Controls.Add(tableLayoutPanel1);
            FormStyle = ReaLTaiizor.Enum.Material.FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(520, 600);
            Name = "ConfigurationWizard";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems - Asistente de configuración";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel lblAppName;
        private PictureBox pictureBox1;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbInitialUser;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbConnectionString;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbInitialUserPassword;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private ReaLTaiizor.Controls.MaterialButton btnTestDBConnection;
        private ReaLTaiizor.Controls.MaterialButton btnFinish;
    }
}