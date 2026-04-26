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
            tpPurchasesList = new TabPage();
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
            tpCurrentAccounts = new TabPage();
            btnAddCurrentAccount = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            materialTabSelector1 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpArticles = new TabPage();
            btnAddArticle = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpFinancialState = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            fscTotalPurchases = new PrimeSystems.Views.Controls.FinancialStateCard();
            fscTotalSells = new PrimeSystems.Views.Controls.FinancialStateCard();
            fscTotalExpenses = new PrimeSystems.Views.Controls.FinancialStateCard();
            fscTotalRevenue = new PrimeSystems.Views.Controls.FinancialStateCard();
            financialStateChart1 = new PrimeSystems.Views.Controls.FinancialStateChart();
            pFinancialStateTableItems = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel2 = new Panel();
            dtpDateTo = new ReaLTaiizor.Controls.PoisonDateTime();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1 = new Panel();
            dtpDateFrom = new ReaLTaiizor.Controls.PoisonDateTime();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            tpActivityLog = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            pActivityLogTableItems = new Panel();
            tpLogout = new TabPage();
            financialStateTableHeader1 = new PrimeSystems.Views.Controls.FinancialStateTableHeader();
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
            tpPurchasesList.SuspendLayout();
            tpSuppliers.SuspendLayout();
            tpSells.SuspendLayout();
            tcSellsPages.SuspendLayout();
            tpSellsList.SuspendLayout();
            tpSellsClients.SuspendLayout();
            tpCurrentAccounts.SuspendLayout();
            tpArticles.SuspendLayout();
            tpFinancialState.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tpActivityLog.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
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
            imgList.Images.SetKeyName(8, "activity-log.png");
            imgList.Images.SetKeyName(9, "article.png");
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
            tableLayoutPanel1.BackColor = Color.Transparent;
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
            tcMain.Controls.Add(tpArticles);
            tcMain.Controls.Add(tpFinancialState);
            tcMain.Controls.Add(tpActivityLog);
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
            tcMain.Size = new Size(983, 688);
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
            materialTabControl1.Controls.Add(tpPurchasesList);
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
            // tpPurchasesList
            // 
            tpPurchasesList.BackColor = Color.Transparent;
            tpPurchasesList.Controls.Add(btnAddPurchase);
            tpPurchasesList.Location = new Point(4, 24);
            tpPurchasesList.Name = "tpPurchasesList";
            tpPurchasesList.Padding = new Padding(20);
            tpPurchasesList.Size = new Size(934, 395);
            tpPurchasesList.TabIndex = 0;
            tpPurchasesList.Text = "Listado";
            // 
            // btnAddPurchase
            // 
            btnAddPurchase.Depth = 0;
            btnAddPurchase.Icon = Properties.Resources.add;
            btnAddPurchase.Location = new Point(875, 301);
            btnAddPurchase.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddPurchase.Name = "btnAddPurchase";
            btnAddPurchase.Size = new Size(56, 56);
            btnAddPurchase.TabIndex = 1;
            btnAddPurchase.UseVisualStyleBackColor = true;
            btnAddPurchase.Click += btnAddPurchase_Click;
            // 
            // tpSuppliers
            // 
            tpSuppliers.BackColor = Color.Transparent;
            tpSuppliers.Controls.Add(btnAddSupplier);
            tpSuppliers.Location = new Point(4, 24);
            tpSuppliers.Name = "tpSuppliers";
            tpSuppliers.Padding = new Padding(20);
            tpSuppliers.Size = new Size(934, 360);
            tpSuppliers.TabIndex = 1;
            tpSuppliers.Text = "Proveedores";
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
            tcSellsPages.Controls.Add(tpCurrentAccounts);
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
            tpSellsList.BackColor = Color.Transparent;
            tpSellsList.Controls.Add(btnAddSell);
            tpSellsList.Location = new Point(4, 24);
            tpSellsList.Name = "tpSellsList";
            tpSellsList.Padding = new Padding(20);
            tpSellsList.Size = new Size(934, 395);
            tpSellsList.TabIndex = 0;
            tpSellsList.Text = "Listado";
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
            tpSellsClients.BackColor = Color.Transparent;
            tpSellsClients.Controls.Add(btnAddClient);
            tpSellsClients.Location = new Point(4, 24);
            tpSellsClients.Name = "tpSellsClients";
            tpSellsClients.Padding = new Padding(20);
            tpSellsClients.Size = new Size(934, 395);
            tpSellsClients.TabIndex = 1;
            tpSellsClients.Text = "Clientes";
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
            // tpCurrentAccounts
            // 
            tpCurrentAccounts.Controls.Add(btnAddCurrentAccount);
            tpCurrentAccounts.Location = new Point(4, 24);
            tpCurrentAccounts.Name = "tpCurrentAccounts";
            tpCurrentAccounts.Padding = new Padding(20);
            tpCurrentAccounts.Size = new Size(934, 395);
            tpCurrentAccounts.TabIndex = 2;
            tpCurrentAccounts.Text = "Cuentas Corrientes";
            tpCurrentAccounts.UseVisualStyleBackColor = true;
            // 
            // btnAddCurrentAccount
            // 
            btnAddCurrentAccount.Depth = 0;
            btnAddCurrentAccount.Icon = Properties.Resources.add;
            btnAddCurrentAccount.Location = new Point(875, 301);
            btnAddCurrentAccount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddCurrentAccount.Name = "btnAddCurrentAccount";
            btnAddCurrentAccount.Size = new Size(56, 56);
            btnAddCurrentAccount.TabIndex = 0;
            btnAddCurrentAccount.UseVisualStyleBackColor = true;
            btnAddCurrentAccount.Click += btnAddCurrentAccount_Click;
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
            materialTabSelector1.Click += materialTabSelector1_Click;
            // 
            // tpArticles
            // 
            tpArticles.AutoScroll = true;
            tpArticles.Controls.Add(btnAddArticle);
            tpArticles.ImageKey = "article.png";
            tpArticles.Location = new Point(4, 39);
            tpArticles.Name = "tpArticles";
            tpArticles.Padding = new Padding(20);
            tpArticles.Size = new Size(942, 471);
            tpArticles.TabIndex = 14;
            tpArticles.Text = "Artículos";
            tpArticles.UseVisualStyleBackColor = true;
            // 
            // btnAddArticle
            // 
            btnAddArticle.Depth = 0;
            btnAddArticle.Icon = Properties.Resources.add;
            btnAddArticle.Location = new Point(883, 412);
            btnAddArticle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.Size = new Size(56, 56);
            btnAddArticle.TabIndex = 1;
            btnAddArticle.UseVisualStyleBackColor = true;
            btnAddArticle.Click += btnAddArticle_Click;
            // 
            // tpFinancialState
            // 
            tpFinancialState.BackColor = Color.Transparent;
            tpFinancialState.Controls.Add(tableLayoutPanel2);
            tpFinancialState.ImageKey = "financial-state.png";
            tpFinancialState.Location = new Point(4, 39);
            tpFinancialState.Name = "tpFinancialState";
            tpFinancialState.Padding = new Padding(20);
            tpFinancialState.Size = new Size(975, 645);
            tpFinancialState.TabIndex = 12;
            tpFinancialState.Text = "Estado Contable";
            tpFinancialState.UseVisualStyleBackColor = true;
            tpFinancialState.Paint += tpFinancialState_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(financialStateChart1, 0, 2);
            tableLayoutPanel2.Controls.Add(pFinancialStateTableItems, 0, 4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(20, 20);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(935, 605);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Transparent;
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Controls.Add(fscTotalPurchases, 3, 0);
            tableLayoutPanel4.Controls.Add(fscTotalSells, 2, 0);
            tableLayoutPanel4.Controls.Add(fscTotalExpenses, 1, 0);
            tableLayoutPanel4.Controls.Add(fscTotalRevenue, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 80);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(935, 120);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // fscTotalPurchases
            // 
            fscTotalPurchases.BackColor = Color.White;
            fscTotalPurchases.Dock = DockStyle.Fill;
            fscTotalPurchases.Location = new Point(702, 3);
            fscTotalPurchases.MinimumSize = new Size(200, 95);
            fscTotalPurchases.Name = "fscTotalPurchases";
            fscTotalPurchases.Size = new Size(230, 114);
            fscTotalPurchases.TabIndex = 0;
            fscTotalPurchases.Title = "Total de Ingresos";
            fscTotalPurchases.Value = "$16.800,00";
            // 
            // fscTotalSells
            // 
            fscTotalSells.BackColor = Color.White;
            fscTotalSells.Dock = DockStyle.Fill;
            fscTotalSells.Location = new Point(469, 3);
            fscTotalSells.MinimumSize = new Size(200, 95);
            fscTotalSells.Name = "fscTotalSells";
            fscTotalSells.Size = new Size(227, 114);
            fscTotalSells.TabIndex = 1;
            fscTotalSells.Title = "Total de Ingresos";
            fscTotalSells.Value = "$16.800,00";
            // 
            // fscTotalExpenses
            // 
            fscTotalExpenses.BackColor = Color.White;
            fscTotalExpenses.Dock = DockStyle.Fill;
            fscTotalExpenses.Location = new Point(236, 3);
            fscTotalExpenses.MinimumSize = new Size(200, 95);
            fscTotalExpenses.Name = "fscTotalExpenses";
            fscTotalExpenses.Size = new Size(227, 114);
            fscTotalExpenses.TabIndex = 2;
            fscTotalExpenses.Title = "Total de Ingresos";
            fscTotalExpenses.Value = "$16.800,00";
            // 
            // fscTotalRevenue
            // 
            fscTotalRevenue.BackColor = Color.White;
            fscTotalRevenue.Dock = DockStyle.Fill;
            fscTotalRevenue.Location = new Point(3, 3);
            fscTotalRevenue.MinimumSize = new Size(200, 95);
            fscTotalRevenue.Name = "fscTotalRevenue";
            fscTotalRevenue.Size = new Size(227, 114);
            fscTotalRevenue.TabIndex = 3;
            fscTotalRevenue.Title = "Total de Ingresos";
            fscTotalRevenue.Value = "$16.800,00";
            // 
            // financialStateChart1
            // 
            financialStateChart1.BackColor = Color.White;
            financialStateChart1.Dock = DockStyle.Fill;
            financialStateChart1.Location = new Point(3, 203);
            financialStateChart1.MinimumSize = new Size(400, 200);
            financialStateChart1.Name = "financialStateChart1";
            financialStateChart1.Size = new Size(929, 200);
            financialStateChart1.TabIndex = 9;
            // 
            // pFinancialStateTableItems
            // 
            pFinancialStateTableItems.AutoScroll = true;
            pFinancialStateTableItems.AutoSize = true;
            pFinancialStateTableItems.Dock = DockStyle.Fill;
            pFinancialStateTableItems.Location = new Point(3, 433);
            pFinancialStateTableItems.Name = "pFinancialStateTableItems";
            pFinancialStateTableItems.Size = new Size(929, 169);
            pFinancialStateTableItems.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel2, 1, 0);
            tableLayoutPanel3.Controls.Add(panel1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(929, 74);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpDateTo);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(464, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(465, 74);
            panel2.TabIndex = 1;
            // 
            // dtpDateTo
            // 
            dtpDateTo.Dock = DockStyle.Top;
            dtpDateTo.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            dtpDateTo.Location = new Point(10, 29);
            dtpDateTo.MinimumSize = new Size(0, 29);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(445, 29);
            dtpDateTo.TabIndex = 1;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Top;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(10, 10);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(88, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Fecha hasta";
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpDateFrom);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(464, 74);
            panel1.TabIndex = 0;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Dock = DockStyle.Top;
            dtpDateFrom.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            dtpDateFrom.Location = new Point(10, 29);
            dtpDateFrom.MinimumSize = new Size(0, 29);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(444, 29);
            dtpDateFrom.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Top;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(10, 10);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(90, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Fecha desde";
            // 
            // tpActivityLog
            // 
            tpActivityLog.Controls.Add(tableLayoutPanel5);
            tpActivityLog.ImageKey = "activity-log.png";
            tpActivityLog.Location = new Point(4, 39);
            tpActivityLog.Name = "tpActivityLog";
            tpActivityLog.Padding = new Padding(20);
            tpActivityLog.Size = new Size(942, 471);
            tpActivityLog.TabIndex = 13;
            tpActivityLog.Text = "Registro de actividad";
            tpActivityLog.UseVisualStyleBackColor = true;
            tpActivityLog.Paint += tpActivityLog_Paint;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(pActivityLogTableItems, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(20, 20);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(902, 431);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // pActivityLogTableItems
            // 
            pActivityLogTableItems.AutoScroll = true;
            pActivityLogTableItems.Dock = DockStyle.Fill;
            pActivityLogTableItems.Location = new Point(0, 0);
            pActivityLogTableItems.Margin = new Padding(0);
            pActivityLogTableItems.Name = "pActivityLogTableItems";
            pActivityLogTableItems.Size = new Size(902, 431);
            pActivityLogTableItems.TabIndex = 1;
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
            // financialStateTableHeader1
            // 
            financialStateTableHeader1.BackColor = Color.White;
            financialStateTableHeader1.Location = new Point(0, 0);
            financialStateTableHeader1.MaximumSize = new Size(0, 30);
            financialStateTableHeader1.MinimumSize = new Size(800, 30);
            financialStateTableHeader1.Name = "financialStateTableHeader1";
            financialStateTableHeader1.Size = new Size(800, 30);
            financialStateTableHeader1.TabIndex = 0;
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
            statusStrip1.Location = new Point(0, 752);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(983, 22);
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
            BackColor = Color.White;
            ClientSize = new Size(983, 774);
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
            tpPurchasesList.ResumeLayout(false);
            tpSuppliers.ResumeLayout(false);
            tpSells.ResumeLayout(false);
            tcSellsPages.ResumeLayout(false);
            tpSellsList.ResumeLayout(false);
            tpSellsClients.ResumeLayout(false);
            tpCurrentAccounts.ResumeLayout(false);
            tpArticles.ResumeLayout(false);
            tpFinancialState.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tpActivityLog.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
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
        public TabPage tpPurchasesList;
        public TabPage tpSellsList;
        private TabPage tpActivityLog;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private Views.Controls.FinancialStateCard fscTotalPurchases;
        private Views.Controls.FinancialStateCard fscTotalSells;
        private Views.Controls.FinancialStateCard fscTotalExpenses;
        private Views.Controls.FinancialStateCard fscTotalRevenue;
        private Panel pFinancialStateTableItems;
        private Views.Controls.FinancialStateChart financialStateChart1;
        private TableLayoutPanel tableLayoutPanel3;
        private Views.Controls.FinancialStateTableHeader financialStateTableHeader1;
        private Panel panel2;
        private ReaLTaiizor.Controls.PoisonDateTime dtpDateTo;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private Panel panel1;
        private ReaLTaiizor.Controls.PoisonDateTime dtpDateFrom;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        public TabPage tpArticles;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddArticle;
        private TableLayoutPanel tableLayoutPanel5;
        private Views.Controls.ActivityLogTableHeader activityLogTableHeader1;
        private Panel pActivityLogTableItems;
        public TabPage tpCurrentAccounts;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddCurrentAccount;
    }
}