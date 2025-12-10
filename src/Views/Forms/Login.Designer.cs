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
            btnLogin = new ReaLTaiizor.Controls.MaterialButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblAppName = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            tbUsername = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            tbPassword = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
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
            btnLogin.Location = new Point(20, 352);
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
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tbUsername, 0, 1);
            tableLayoutPanel2.Controls.Add(tbPassword, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(458, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
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
            panel3.Size = new Size(443, 186);
            panel3.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(lblAppName, 0, 0);
            tableLayoutPanel3.Controls.Add(materialLabel1, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(443, 186);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Depth = 0;
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblAppName.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            lblAppName.HighEmphasis = true;
            lblAppName.Location = new Point(3, 0);
            lblAppName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(437, 93);
            lblAppName.TabIndex = 12;
            lblAppName.Text = "Prime Systems";
            lblAppName.TextAlign = ContentAlignment.BottomCenter;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Fill;
            materialLabel1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            materialLabel1.Location = new Point(3, 93);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(437, 93);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "Gestiona el sistema, fácil y rápido";
            materialLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.AnimateReadOnly = false;
            tbUsername.AutoCompleteMode = AutoCompleteMode.None;
            tbUsername.AutoCompleteSource = AutoCompleteSource.None;
            tbUsername.BackgroundImageLayout = ImageLayout.None;
            tbUsername.CharacterCasing = CharacterCasing.Normal;
            tbUsername.Depth = 0;
            tbUsername.Dock = DockStyle.Fill;
            tbUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbUsername.HideSelection = true;
            tbUsername.Hint = "Nombre de usuario / Identificador";
            tbUsername.LeadingIcon = Properties.Resources.user;
            tbUsername.Location = new Point(3, 195);
            tbUsername.MaxLength = 30;
            tbUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbUsername.Name = "tbUsername";
            tbUsername.PasswordChar = '\0';
            tbUsername.PrefixSuffixText = null;
            tbUsername.ReadOnly = false;
            tbUsername.RightToLeft = RightToLeft.No;
            tbUsername.SelectedText = "";
            tbUsername.SelectionLength = 0;
            tbUsername.SelectionStart = 0;
            tbUsername.ShortcutsEnabled = true;
            tbUsername.Size = new Size(443, 48);
            tbUsername.TabIndex = 9;
            tbUsername.TabStop = false;
            tbUsername.TextAlign = HorizontalAlignment.Left;
            tbUsername.TrailingIcon = null;
            tbUsername.UseAccent = false;
            tbUsername.UseSystemPasswordChar = false;
            tbUsername.KeyPress += tbHandleEnter;
            tbUsername.TextChanged += tbCredentials_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.AnimateReadOnly = false;
            tbPassword.AutoCompleteMode = AutoCompleteMode.None;
            tbPassword.AutoCompleteSource = AutoCompleteSource.None;
            tbPassword.BackgroundImageLayout = ImageLayout.None;
            tbPassword.CharacterCasing = CharacterCasing.Normal;
            tbPassword.Depth = 0;
            tbPassword.Dock = DockStyle.Fill;
            tbPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tbPassword.HelperText = "Contraseña del usuario administrador";
            tbPassword.HideSelection = true;
            tbPassword.Hint = "Contraseña";
            tbPassword.LeadingIcon = Properties.Resources.password;
            tbPassword.Location = new Point(3, 249);
            tbPassword.MaxLength = 60;
            tbPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '•';
            tbPassword.PrefixSuffixText = null;
            tbPassword.ReadOnly = false;
            tbPassword.RightToLeft = RightToLeft.No;
            tbPassword.SelectedText = "";
            tbPassword.SelectionLength = 0;
            tbPassword.SelectionStart = 0;
            tbPassword.ShortcutsEnabled = true;
            tbPassword.Size = new Size(443, 48);
            tbPassword.TabIndex = 10;
            tbPassword.TabStop = false;
            tbPassword.TextAlign = HorizontalAlignment.Left;
            tbPassword.TrailingIcon = null;
            tbPassword.UseAccent = false;
            tbPassword.UseSystemPasswordChar = false;
            tbPassword.KeyPress += tbHandleEnter;
            tbPassword.TextChanged += tbCredentials_TextChanged;
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
        private ReaLTaiizor.Controls.MaterialButton btnLogin;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private ReaLTaiizor.Controls.MaterialLabel lblAppName;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbUsername;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit tbPassword;
    }
}
