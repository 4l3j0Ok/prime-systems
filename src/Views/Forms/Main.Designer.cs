using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace PrimeSystems
{
    partial class Main
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            imgList = new ImageList(components);
            tpUsers = new TabPage();
            tcUsersPages = new ReaLTaiizor.Controls.MaterialTabControl();
            tpUsersList = new TabPage();
            btnAddUser = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpUsersRoles = new TabPage();
            btnAddRole = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            materialTabSelector3 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpHome = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            lblWelcome = new ReaLTaiizor.Controls.MaterialLabel();
            tcMain = new ReaLTaiizor.Controls.MaterialTabControl();
            tpPurchases = new TabPage();
            materialTabControl1 = new ReaLTaiizor.Controls.MaterialTabControl();
            tpPurchasesHistory = new TabPage();
            btnAddPurchase = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpSuppliers = new TabPage();
            btnAddSupplier = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            materialTabSelector2 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpSells = new TabPage();
            tcSellsPages = new ReaLTaiizor.Controls.MaterialTabControl();
            tpSellsList = new TabPage();
            btnAddSell = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpSellsClients = new TabPage();
            btnAddClient = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpSellsArticles = new TabPage();
            btnAddArticle = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            materialTabSelector1 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpFinancialState = new TabPage();
            tpLogout = new TabPage();
            flowLayoutPanel4 = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tpUsers.SuspendLayout();
            tcUsersPages.SuspendLayout();
            tpUsersList.SuspendLayout();
            tpUsersRoles.SuspendLayout();
            tpHome.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            tcMain.SuspendLayout();
            tpPurchases.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tpPurchasesHistory.SuspendLayout();
            tpSuppliers.SuspendLayout();
            tpSells.SuspendLayout();
            tcSellsPages.SuspendLayout();
            tpSellsList.SuspendLayout();
            tpSellsClients.SuspendLayout();
            tpSellsArticles.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "clients.png");
            imgList.Images.SetKeyName(1, "financial-state.png");
            imgList.Images.SetKeyName(2, "logout.png");
            imgList.Images.SetKeyName(3, "purchases.png");
            imgList.Images.SetKeyName(4, "sells.png");
            imgList.Images.SetKeyName(5, "supplier.png");
            imgList.Images.SetKeyName(6, "home.png");
            imgList.Images.SetKeyName(7, "user.png");
            // 
            // tpUsers
            // 
            tpUsers.AutoScroll = true;
            tpUsers.Controls.Add(tcUsersPages);
            tpUsers.Controls.Add(materialTabSelector3);
            tpUsers.ImageKey = "user.png";
            tpUsers.Location = new Point(4, 39);
            tpUsers.Margin = new Padding(0);
            tpUsers.Name = "tpUsers";
            tpUsers.Size = new Size(942, 471);
            tpUsers.TabIndex = 3;
            tpUsers.Text = "Usuarios";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // tcUsersPages
            // 
            tcUsersPages.Controls.Add(tpUsersList);
            tcUsersPages.Controls.Add(tpUsersRoles);
            tcUsersPages.Depth = 0;
            tcUsersPages.Dock = DockStyle.Fill;
            tcUsersPages.Location = new Point(0, 48);
            tcUsersPages.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tcUsersPages.Multiline = true;
            tcUsersPages.Name = "tcUsersPages";
            tcUsersPages.SelectedIndex = 0;
            tcUsersPages.Size = new Size(942, 423);
            tcUsersPages.TabIndex = 3;
            // 
            // tpUsersList
            // 
            tpUsersList.Controls.Add(btnAddUser);
            tpUsersList.Location = new Point(4, 24);
            tpUsersList.Name = "tpUsersList";
            tpUsersList.Padding = new Padding(20);
            tpUsersList.Size = new Size(934, 395);
            tpUsersList.TabIndex = 0;
            tpUsersList.Text = "Usuarios";
            tpUsersList.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            btnAddUser.Depth = 0;
            btnAddUser.Icon = Properties.Resources.add;
            btnAddUser.Location = new Point(875, 336);
            btnAddUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(56, 56);
            btnAddUser.TabIndex = 0;
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // tpUsersRoles
            // 
            tpUsersRoles.Controls.Add(btnAddRole);
            tpUsersRoles.Location = new Point(4, 24);
            tpUsersRoles.Name = "tpUsersRoles";
            tpUsersRoles.Padding = new Padding(20);
            tpUsersRoles.Size = new Size(934, 395);
            tpUsersRoles.TabIndex = 1;
            tpUsersRoles.Text = "Roles";
            tpUsersRoles.UseVisualStyleBackColor = true;
            // 
            // btnAddRole
            // 
            btnAddRole.Depth = 0;
            btnAddRole.Icon = Properties.Resources.add;
            btnAddRole.Location = new Point(875, 336);
            btnAddRole.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(56, 56);
            btnAddRole.TabIndex = 0;
            btnAddRole.UseVisualStyleBackColor = true;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // materialTabSelector3
            // 
            materialTabSelector3.BaseTabControl = tcUsersPages;
            materialTabSelector3.CharacterCasing = ReaLTaiizor.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector3.Depth = 0;
            materialTabSelector3.Dock = DockStyle.Top;
            materialTabSelector3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector3.HeadAlignment = ReaLTaiizor.Controls.MaterialTabSelector.Alignment.Left;
            materialTabSelector3.Location = new Point(0, 0);
            materialTabSelector3.Margin = new Padding(0);
            materialTabSelector3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabSelector3.Name = "materialTabSelector3";
            materialTabSelector3.Size = new Size(942, 48);
            materialTabSelector3.TabIndex = 4;
            materialTabSelector3.Text = "materialTabSelector3";
            // 
            // tpHome
            // 
            tpHome.Controls.Add(tableLayoutPanel1);
            tpHome.ImageKey = "home.png";
            tpHome.Location = new Point(4, 39);
            tpHome.Name = "tpHome";
            tpHome.Padding = new Padding(20);
            tpHome.Size = new Size(942, 471);
            tpHome.TabIndex = 0;
            tpHome.Text = "Inicio";
            tpHome.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(238, 238, 238);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblWelcome, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.4976959F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.5023041F));
            tableLayoutPanel1.Size = new Size(902, 431);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Margin = new Padding(20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 289);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Depth = 0;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblWelcome.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            lblWelcome.Location = new Point(3, 329);
            lblWelcome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(896, 41);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Bienvenido a Prime Systems";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tpHome);
            tcMain.Controls.Add(tpPurchases);
            tcMain.Controls.Add(tpSells);
            tcMain.Controls.Add(tpFinancialState);
            tcMain.Controls.Add(tpUsers);
            tcMain.Controls.Add(tpLogout);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.ImageList = imgList;
            tcMain.ItemSize = new Size(120, 35);
            tcMain.Location = new Point(0, 64);
            tcMain.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.Padding = new Point(10, 3);
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(950, 514);
            tcMain.TabIndex = 0;
            // 
            // tpPurchases
            // 
            tpPurchases.Controls.Add(materialTabControl1);
            tpPurchases.Controls.Add(materialTabSelector2);
            tpPurchases.ImageKey = "purchases.png";
            tpPurchases.Location = new Point(4, 39);
            tpPurchases.Name = "tpPurchases";
            tpPurchases.Size = new Size(942, 471);
            tpPurchases.TabIndex = 10;
            tpPurchases.Text = "Compras";
            tpPurchases.UseVisualStyleBackColor = true;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tpPurchasesHistory);
            materialTabControl1.Controls.Add(tpSuppliers);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(0, 48);
            materialTabControl1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(942, 423);
            materialTabControl1.TabIndex = 4;
            // 
            // tpPurchasesHistory
            // 
            tpPurchasesHistory.Controls.Add(btnAddPurchase);
            tpPurchasesHistory.Location = new Point(4, 24);
            tpPurchasesHistory.Name = "tpPurchasesHistory";
            tpPurchasesHistory.Padding = new Padding(20);
            tpPurchasesHistory.Size = new Size(934, 395);
            tpPurchasesHistory.TabIndex = 0;
            tpPurchasesHistory.Text = "Histórico";
            tpPurchasesHistory.UseVisualStyleBackColor = true;
            // 
            // btnAddPurchase
            // 
            btnAddPurchase.Depth = 0;
            btnAddPurchase.Icon = Properties.Resources.add;
            btnAddPurchase.Location = new Point(875, 336);
            btnAddPurchase.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddPurchase.Name = "btnAddPurchase";
            btnAddPurchase.Size = new Size(56, 56);
            btnAddPurchase.TabIndex = 1;
            btnAddPurchase.UseVisualStyleBackColor = true;
            btnAddPurchase.Click += btnAddPurchase_Click;
            // 
            // tpSuppliers
            // 
            tpSuppliers.Controls.Add(btnAddSupplier);
            tpSuppliers.Location = new Point(4, 24);
            tpSuppliers.Name = "tpSuppliers";
            tpSuppliers.Padding = new Padding(20);
            tpSuppliers.Size = new Size(934, 395);
            tpSuppliers.TabIndex = 1;
            tpSuppliers.Text = "Proveedores";
            tpSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Depth = 0;
            btnAddSupplier.Icon = Properties.Resources.add;
            btnAddSupplier.Location = new Point(875, 336);
            btnAddSupplier.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(56, 56);
            btnAddSupplier.TabIndex = 2;
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // materialTabSelector2
            // 
            materialTabSelector2.BaseTabControl = materialTabControl1;
            materialTabSelector2.CharacterCasing = ReaLTaiizor.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector2.Depth = 0;
            materialTabSelector2.Dock = DockStyle.Top;
            materialTabSelector2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector2.HeadAlignment = ReaLTaiizor.Controls.MaterialTabSelector.Alignment.Left;
            materialTabSelector2.Location = new Point(0, 0);
            materialTabSelector2.Margin = new Padding(0);
            materialTabSelector2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabSelector2.Name = "materialTabSelector2";
            materialTabSelector2.Size = new Size(942, 48);
            materialTabSelector2.TabIndex = 3;
            materialTabSelector2.Text = "materialTabSelector2";
            // 
            // tpSells
            // 
            tpSells.Controls.Add(tcSellsPages);
            tpSells.Controls.Add(materialTabSelector1);
            tpSells.ImageKey = "sells.png";
            tpSells.Location = new Point(4, 39);
            tpSells.Margin = new Padding(0);
            tpSells.Name = "tpSells";
            tpSells.Size = new Size(942, 471);
            tpSells.TabIndex = 9;
            tpSells.Text = "Ventas";
            tpSells.UseVisualStyleBackColor = true;
            // 
            // tcSellsPages
            // 
            tcSellsPages.Controls.Add(tpSellsList);
            tcSellsPages.Controls.Add(tpSellsClients);
            tcSellsPages.Controls.Add(tpSellsArticles);
            tcSellsPages.Depth = 0;
            tcSellsPages.Dock = DockStyle.Fill;
            tcSellsPages.Location = new Point(0, 48);
            tcSellsPages.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tcSellsPages.Multiline = true;
            tcSellsPages.Name = "tcSellsPages";
            tcSellsPages.SelectedIndex = 0;
            tcSellsPages.Size = new Size(942, 423);
            tcSellsPages.TabIndex = 2;
            // 
            // tpSellsList
            // 
            tpSellsList.Controls.Add(btnAddSell);
            tpSellsList.Location = new Point(4, 24);
            tpSellsList.Name = "tpSellsList";
            tpSellsList.Size = new Size(934, 395);
            tpSellsList.TabIndex = 0;
            tpSellsList.Text = "Listado";
            tpSellsList.UseVisualStyleBackColor = true;
            // 
            // btnAddSell
            // 
            btnAddSell.Depth = 0;
            btnAddSell.Icon = Properties.Resources.add;
            btnAddSell.Location = new Point(875, 336);
            btnAddSell.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddSell.Name = "btnAddSell";
            btnAddSell.Size = new Size(56, 56);
            btnAddSell.TabIndex = 0;
            btnAddSell.UseVisualStyleBackColor = true;
            btnAddSell.Click += btnAddSell_Click;
            // 
            // tpSellsClients
            // 
            tpSellsClients.Controls.Add(btnAddClient);
            tpSellsClients.Location = new Point(4, 24);
            tpSellsClients.Name = "tpSellsClients";
            tpSellsClients.Size = new Size(934, 395);
            tpSellsClients.TabIndex = 1;
            tpSellsClients.Text = "Clientes";
            tpSellsClients.UseVisualStyleBackColor = true;
            // 
            // btnAddClient
            // 
            btnAddClient.Depth = 0;
            btnAddClient.Icon = Properties.Resources.add;
            btnAddClient.Location = new Point(875, 336);
            btnAddClient.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(56, 56);
            btnAddClient.TabIndex = 1;
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // tpSellsArticles
            // 
            tpSellsArticles.Controls.Add(btnAddArticle);
            tpSellsArticles.Location = new Point(4, 24);
            tpSellsArticles.Name = "tpSellsArticles";
            tpSellsArticles.Size = new Size(934, 395);
            tpSellsArticles.TabIndex = 2;
            tpSellsArticles.Text = "Artículos";
            tpSellsArticles.UseVisualStyleBackColor = true;
            // 
            // btnAddArticle
            // 
            btnAddArticle.Depth = 0;
            btnAddArticle.Icon = Properties.Resources.add;
            btnAddArticle.Location = new Point(875, 336);
            btnAddArticle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.Size = new Size(56, 56);
            btnAddArticle.TabIndex = 1;
            btnAddArticle.UseVisualStyleBackColor = true;
            btnAddArticle.Click += btnAddArticle_Click;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = tcSellsPages;
            materialTabSelector1.CharacterCasing = ReaLTaiizor.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Dock = DockStyle.Top;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.HeadAlignment = ReaLTaiizor.Controls.MaterialTabSelector.Alignment.Left;
            materialTabSelector1.Location = new Point(0, 0);
            materialTabSelector1.Margin = new Padding(0);
            materialTabSelector1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(942, 48);
            materialTabSelector1.TabIndex = 1;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // tpFinancialState
            // 
            tpFinancialState.ImageKey = "financial-state.png";
            tpFinancialState.Location = new Point(4, 39);
            tpFinancialState.Name = "tpFinancialState";
            tpFinancialState.Size = new Size(942, 471);
            tpFinancialState.TabIndex = 12;
            tpFinancialState.Text = "Estado Contable";
            tpFinancialState.UseVisualStyleBackColor = true;
            // 
            // tpLogout
            // 
            tpLogout.ImageKey = "logout.png";
            tpLogout.Location = new Point(4, 39);
            tpLogout.Name = "tpLogout";
            tpLogout.Padding = new Padding(3);
            tpLogout.Size = new Size(942, 471);
            tpLogout.TabIndex = 8;
            tpLogout.Text = "Cerrar Sesión";
            tpLogout.UseVisualStyleBackColor = true;
            tpLogout.Enter += tabCerrarSesion_Click;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(200, 100);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(950, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(950, 600);
            Controls.Add(tcMain);
            Controls.Add(statusStrip1);
            DrawerIsOpen = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcMain;
            DrawerUseColors = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "Main";
            Padding = new Padding(0, 64, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems";
            Load += Main_Load;
            tpUsers.ResumeLayout(false);
            tcUsersPages.ResumeLayout(false);
            tpUsersList.ResumeLayout(false);
            tpUsersRoles.ResumeLayout(false);
            tpHome.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            tcMain.ResumeLayout(false);
            tpPurchases.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tpPurchasesHistory.ResumeLayout(false);
            tpSuppliers.ResumeLayout(false);
            tpSells.ResumeLayout(false);
            tcSellsPages.ResumeLayout(false);
            tpSellsList.ResumeLayout(false);
            tpSellsClients.ResumeLayout(false);
            tpSellsArticles.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList imgList;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel lblWelcome;
        private TabPage tabIndustryArea;
        public TabPage tabAnimalArea;
        private DataGridView dataGridView1;
        public ReaLTaiizor.Controls.MaterialTabControl tcMain;
        private FlowLayoutPanel flowLayoutPanel4;
        public TabPage tabBlackBoard;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector1;
        private ReaLTaiizor.Controls.MaterialTabControl materialTabControl1;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector2;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddSell;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddClient;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddArticle;
        public TabPage tpHome;
        public TabPage tpLogout;
        public TabPage tpPurchases;
        public TabPage tpSells;
        public TabPage tpFinancialState;
        public TabPage tpUsers;
        public TabPage tpUsersList;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddUser;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector3;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddRole;
        public ReaLTaiizor.Controls.MaterialTabControl tcUsersPages;
        public TabPage tpUsersRoles;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddPurchase;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddSupplier;
        public TabPage tpSuppliers;
        private ReaLTaiizor.Controls.MaterialTabControl tcSellsPages;
        public TabPage tpSellsClients;
        public TabPage tpPurchasesHistory;
        public TabPage tpSellsList;
        public TabPage tpSellsArticles;
    }
}