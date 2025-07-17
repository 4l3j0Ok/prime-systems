namespace PrimeSystems
{
    partial class FormPrincipal
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            imgList = new ImageList(components);
            contable = new TabPage();
            rrhh = new TabPage();
            tabControl1 = new TabControl();
            users = new TabPage();
            dgvRRHHUsers = new DataGridView();
            clients = new TabPage();
            suppliers = new TabPage();
            sells = new TabPage();
            shopping = new TabPage();
            home = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            tbPrincipal = new ReaLTaiizor.Controls.MaterialTabControl();
            rrhh.SuspendLayout();
            tabControl1.SuspendLayout();
            users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRRHHUsers).BeginInit();
            home.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tbPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "cart.png");
            imgList.Images.SetKeyName(1, "graph.png");
            imgList.Images.SetKeyName(2, "home.png");
            imgList.Images.SetKeyName(3, "rrhh.png");
            imgList.Images.SetKeyName(4, "solar--dollar-bold.png");
            imgList.Images.SetKeyName(5, "user.png");
            // 
            // contable
            // 
            contable.ImageKey = "graph.png";
            contable.Location = new Point(4, 24);
            contable.Name = "contable";
            contable.Size = new Size(979, 486);
            contable.TabIndex = 5;
            contable.Text = "Estado Contable";
            contable.UseVisualStyleBackColor = true;
            // 
            // rrhh
            // 
            rrhh.Controls.Add(tabControl1);
            rrhh.ImageKey = "rrhh.png";
            rrhh.Location = new Point(4, 24);
            rrhh.Name = "rrhh";
            rrhh.Size = new Size(979, 486);
            rrhh.TabIndex = 4;
            rrhh.Text = "Recursos Humanos";
            rrhh.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(users);
            tabControl1.Controls.Add(clients);
            tabControl1.Controls.Add(suppliers);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(979, 486);
            tabControl1.TabIndex = 0;
            // 
            // users
            // 
            users.Controls.Add(dgvRRHHUsers);
            users.Location = new Point(4, 24);
            users.Name = "users";
            users.Padding = new Padding(3);
            users.Size = new Size(971, 458);
            users.TabIndex = 0;
            users.Text = "Usuarios";
            users.UseVisualStyleBackColor = true;
            // 
            // dgvRRHHUsers
            // 
            dgvRRHHUsers.AllowUserToAddRows = false;
            dgvRRHHUsers.AllowUserToDeleteRows = false;
            dgvRRHHUsers.AllowUserToOrderColumns = true;
            dgvRRHHUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRRHHUsers.Dock = DockStyle.Fill;
            dgvRRHHUsers.Location = new Point(3, 3);
            dgvRRHHUsers.Name = "dgvRRHHUsers";
            dgvRRHHUsers.ReadOnly = true;
            dgvRRHHUsers.Size = new Size(965, 452);
            dgvRRHHUsers.TabIndex = 2;
            // 
            // clients
            // 
            clients.Location = new Point(4, 24);
            clients.Name = "clients";
            clients.Padding = new Padding(3);
            clients.Size = new Size(971, 458);
            clients.TabIndex = 1;
            clients.Text = "Clientes";
            clients.UseVisualStyleBackColor = true;
            // 
            // suppliers
            // 
            suppliers.Location = new Point(4, 24);
            suppliers.Name = "suppliers";
            suppliers.Size = new Size(971, 458);
            suppliers.TabIndex = 2;
            suppliers.Text = "Proveedores";
            suppliers.UseVisualStyleBackColor = true;
            // 
            // sells
            // 
            sells.ImageKey = "solar--dollar-bold.png";
            sells.Location = new Point(4, 24);
            sells.Name = "sells";
            sells.Size = new Size(979, 486);
            sells.TabIndex = 3;
            sells.Text = "Ventas";
            sells.UseVisualStyleBackColor = true;
            // 
            // shopping
            // 
            shopping.ImageKey = "cart.png";
            shopping.Location = new Point(4, 24);
            shopping.Name = "shopping";
            shopping.Size = new Size(979, 486);
            shopping.TabIndex = 2;
            shopping.Text = "Compras";
            shopping.UseVisualStyleBackColor = true;
            // 
            // home
            // 
            home.Controls.Add(tableLayoutPanel1);
            home.ImageKey = "home.png";
            home.Location = new Point(4, 24);
            home.Name = "home";
            home.Padding = new Padding(3);
            home.Size = new Size(979, 486);
            home.TabIndex = 0;
            home.Text = "Inicio";
            home.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(materialLabel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.4976959F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.5023041F));
            tableLayoutPanel1.Size = new Size(973, 480);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Margin = new Padding(20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(933, 327);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Fill;
            materialLabel1.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            materialLabel1.Location = new Point(3, 367);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(967, 113);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Bienvenido a Prime Systems";
            materialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbPrincipal
            // 
            tbPrincipal.Controls.Add(home);
            tbPrincipal.Controls.Add(shopping);
            tbPrincipal.Controls.Add(sells);
            tbPrincipal.Controls.Add(rrhh);
            tbPrincipal.Controls.Add(contable);
            tbPrincipal.Depth = 0;
            tbPrincipal.Dock = DockStyle.Fill;
            tbPrincipal.ImageList = imgList;
            tbPrincipal.Location = new Point(3, 64);
            tbPrincipal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tbPrincipal.Multiline = true;
            tbPrincipal.Name = "tbPrincipal";
            tbPrincipal.SelectedIndex = 0;
            tbPrincipal.Size = new Size(987, 514);
            tbPrincipal.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 581);
            Controls.Add(tbPrincipal);
            DrawerTabControl = tbPrincipal;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems";
            Load += FormPrincipal_Load;
            rrhh.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRRHHUsers).EndInit();
            home.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tbPrincipal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ImageList imgList;
        private TabPage contable;
        private TabPage rrhh;
        private TabPage sells;
        private TabPage shopping;
        private TabPage home;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialTabControl tbPrincipal;
        private TabControl tabControl1;
        private TabPage users;
        private TabPage clients;
        private TabPage suppliers;
        private DataGridView dgvRRHHUsers;
    }
}