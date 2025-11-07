using System.Windows.Forms;
using System.Drawing;

namespace PrimeSystems
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            tbUsuario = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblUsuario = new ReaLTaiizor.Controls.MaterialLabel();
            panel2 = new Panel();
            tbContrasena = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblContrasenia = new ReaLTaiizor.Controls.MaterialLabel();
            btnLogin = new ReaLTaiizor.Controls.MaterialButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblAppName = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tbUsuario);
            panel1.Controls.Add(lblUsuario);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 156);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 0, 20, 0);
            panel1.Size = new Size(449, 90);
            panel1.TabIndex = 6;
            // 
            // tbUsuario
            // 
            tbUsuario.AnimateReadOnly = false;
            tbUsuario.AutoCompleteMode = AutoCompleteMode.None;
            tbUsuario.AutoCompleteSource = AutoCompleteSource.None;
            tbUsuario.BackgroundImageLayout = ImageLayout.None;
            tbUsuario.CharacterCasing = CharacterCasing.Normal;
            tbUsuario.Depth = 0;
            tbUsuario.Dock = DockStyle.Fill;
            tbUsuario.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUsuario.HideSelection = true;
            tbUsuario.LeadingIcon = null;
            tbUsuario.Location = new Point(20, 19);
            tbUsuario.Margin = new Padding(3, 3, 26, 3);
            tbUsuario.MaxLength = 20;
            tbUsuario.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Padding = new Padding(9, 8, 9, 8);
            tbUsuario.PasswordChar = '\0';
            tbUsuario.PrefixSuffixText = null;
            tbUsuario.ReadOnly = false;
            tbUsuario.RightToLeft = RightToLeft.No;
            tbUsuario.SelectedText = "";
            tbUsuario.SelectionLength = 0;
            tbUsuario.SelectionStart = 0;
            tbUsuario.ShortcutsEnabled = true;
            tbUsuario.Size = new Size(409, 48);
            tbUsuario.TabIndex = 1;
            tbUsuario.TabStop = false;
            tbUsuario.TextAlign = HorizontalAlignment.Left;
            tbUsuario.TrailingIcon = null;
            tbUsuario.UseSystemPasswordChar = false;
            tbUsuario.KeyPress += tbHandleEnter;
            tbUsuario.TextChanged += tbCredentials_TextChanged;
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
            lblUsuario.Size = new Size(55, 19);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // panel2
            // 
            panel2.Controls.Add(tbContrasena);
            panel2.Controls.Add(lblContrasenia);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 246);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20, 0, 20, 0);
            panel2.Size = new Size(449, 90);
            panel2.TabIndex = 7;
            // 
            // tbContrasena
            // 
            tbContrasena.AnimateReadOnly = false;
            tbContrasena.AutoCompleteMode = AutoCompleteMode.None;
            tbContrasena.AutoCompleteSource = AutoCompleteSource.None;
            tbContrasena.BackgroundImageLayout = ImageLayout.None;
            tbContrasena.CharacterCasing = CharacterCasing.Normal;
            tbContrasena.Depth = 0;
            tbContrasena.Dock = DockStyle.Top;
            tbContrasena.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbContrasena.HideSelection = true;
            tbContrasena.LeadingIcon = null;
            tbContrasena.Location = new Point(20, 19);
            tbContrasena.MaxLength = 40;
            tbContrasena.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbContrasena.Name = "tbContrasena";
            tbContrasena.PasswordChar = '•';
            tbContrasena.PrefixSuffixText = null;
            tbContrasena.ReadOnly = false;
            tbContrasena.RightToLeft = RightToLeft.No;
            tbContrasena.SelectedText = "";
            tbContrasena.SelectionLength = 0;
            tbContrasena.SelectionStart = 0;
            tbContrasena.ShortcutsEnabled = true;
            tbContrasena.Size = new Size(409, 48);
            tbContrasena.TabIndex = 2;
            tbContrasena.TabStop = false;
            tbContrasena.TextAlign = HorizontalAlignment.Left;
            tbContrasena.TrailingIcon = null;
            tbContrasena.UseSystemPasswordChar = false;
            tbContrasena.KeyPress += tbHandleEnter;
            tbContrasena.TextChanged += tbCredentials_TextChanged;
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Depth = 0;
            lblContrasenia.Dock = DockStyle.Top;
            lblContrasenia.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContrasenia.Location = new Point(20, 0);
            lblContrasenia.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(82, 19);
            lblContrasenia.TabIndex = 5;
            lblContrasenia.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.Dock = DockStyle.Top;
            btnLogin.Enabled = false;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnLogin.Location = new Point(20, 388);
            btnLogin.Margin = new Padding(20, 52, 20, 20);
            btnLogin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Padding = new Padding(18, 15, 18, 15);
            btnLogin.Size = new Size(409, 36);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 84);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(910, 496);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(20, 40);
            pictureBox1.Margin = new Padding(20, 40, 20, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(415, 416);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnLogin, 0, 3);
            tableLayoutPanel2.Controls.Add(panel2, 0, 2);
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(458, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(449, 492);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(443, 150);
            panel3.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(lblAppName, 0, 0);
            tableLayoutPanel3.Controls.Add(materialLabel1, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(443, 150);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Anchor = AnchorStyles.Bottom;
            lblAppName.AutoSize = true;
            lblAppName.Depth = 0;
            lblAppName.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblAppName.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            lblAppName.Location = new Point(60, 17);
            lblAppName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(322, 58);
            lblAppName.TabIndex = 12;
            lblAppName.Text = "Prime Systems";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Fill;
            materialLabel1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            materialLabel1.Location = new Point(3, 75);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(437, 75);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "Gestión del sistema";
            materialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 600);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "Login";
            Padding = new Padding(20, 84, 20, 20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbUsuario;
        private ReaLTaiizor.Controls.MaterialLabel lblUsuario;
        private Panel panel2;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbContrasena;
        private ReaLTaiizor.Controls.MaterialLabel lblContrasenia;
        private ReaLTaiizor.Controls.MaterialButton btnLogin;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private ReaLTaiizor.Controls.MaterialLabel lblAppName;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
    }
}
