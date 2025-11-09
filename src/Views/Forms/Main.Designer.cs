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
            btnAddUser = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            panel1 = new Panel();
            tpHome = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            lblWelcome = new ReaLTaiizor.Controls.MaterialLabel();
            tcPrincipal = new ReaLTaiizor.Controls.MaterialTabControl();
            tpPurchases = new TabPage();
            materialTabControl1 = new ReaLTaiizor.Controls.MaterialTabControl();
            tpPurchasesHistory = new TabPage();
            tpPurchasesProviders = new TabPage();
            materialTabSelector2 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpSells = new TabPage();
            tcSellsPages = new ReaLTaiizor.Controls.MaterialTabControl();
            tpSellsHistory = new TabPage();
            btnAddSell = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpSellsClients = new TabPage();
            btnAddClients = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            tpSellsArticles = new TabPage();
            btnAddArticles = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            materialTabSelector1 = new ReaLTaiizor.Controls.MaterialTabSelector();
            tpFinancialState = new TabPage();
            tpLogout = new TabPage();
            flowLayoutPanel4 = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tpUsers.SuspendLayout();
            tpHome.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            tcPrincipal.SuspendLayout();
            tpPurchases.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tpSells.SuspendLayout();
            tcSellsPages.SuspendLayout();
            tpSellsHistory.SuspendLayout();
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
            imgList.Images.SetKeyName(5, "provider.png");
            imgList.Images.SetKeyName(6, "home.png");
            imgList.Images.SetKeyName(7, "user.png");
            // 
            // tpUsers
            // 
            tpUsers.AutoScroll = true;
            tpUsers.Controls.Add(btnAddUser);
            tpUsers.Controls.Add(panel1);
            tpUsers.ImageKey = "user.png";
            tpUsers.Location = new Point(4, 39);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(20);
            tpUsers.Size = new Size(942, 471);
            tpUsers.TabIndex = 3;
            tpUsers.Text = "Usuarios";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddUser.Depth = 0;
            btnAddUser.Icon = Properties.Resources.add_user;
            btnAddUser.Location = new Point(877, 409);
            btnAddUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(56, 56);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Agregar Usuario";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(902, 431);
            panel1.TabIndex = 1;
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
            // tcPrincipal
            // 
            tcPrincipal.Controls.Add(tpHome);
            tcPrincipal.Controls.Add(tpPurchases);
            tcPrincipal.Controls.Add(tpSells);
            tcPrincipal.Controls.Add(tpFinancialState);
            tcPrincipal.Controls.Add(tpUsers);
            tcPrincipal.Controls.Add(tpLogout);
            tcPrincipal.Depth = 0;
            tcPrincipal.Dock = DockStyle.Fill;
            tcPrincipal.ImageList = imgList;
            tcPrincipal.ItemSize = new Size(120, 35);
            tcPrincipal.Location = new Point(0, 64);
            tcPrincipal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tcPrincipal.Multiline = true;
            tcPrincipal.Name = "tcPrincipal";
            tcPrincipal.Padding = new Point(10, 3);
            tcPrincipal.SelectedIndex = 0;
            tcPrincipal.Size = new Size(950, 514);
            tcPrincipal.TabIndex = 0;
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
            materialTabControl1.Controls.Add(tpPurchasesProviders);
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
            tpPurchasesHistory.Location = new Point(4, 24);
            tpPurchasesHistory.Name = "tpPurchasesHistory";
            tpPurchasesHistory.Size = new Size(934, 395);
            tpPurchasesHistory.TabIndex = 0;
            tpPurchasesHistory.Text = "Histórico";
            tpPurchasesHistory.UseVisualStyleBackColor = true;
            // 
            // tpPurchasesProviders
            // 
            tpPurchasesProviders.Location = new Point(4, 24);
            tpPurchasesProviders.Name = "tpPurchasesProviders";
            tpPurchasesProviders.Size = new Size(934, 395);
            tpPurchasesProviders.TabIndex = 1;
            tpPurchasesProviders.Text = "Proveedores";
            tpPurchasesProviders.UseVisualStyleBackColor = true;
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
            tcSellsPages.Controls.Add(tpSellsHistory);
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
            // tpSellsHistory
            // 
            tpSellsHistory.Controls.Add(btnAddSell);
            tpSellsHistory.Location = new Point(4, 24);
            tpSellsHistory.Name = "tpSellsHistory";
            tpSellsHistory.Size = new Size(934, 395);
            tpSellsHistory.TabIndex = 0;
            tpSellsHistory.Text = "Histórico";
            tpSellsHistory.UseVisualStyleBackColor = true;
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
            // 
            // tpSellsClients
            // 
            tpSellsClients.Controls.Add(btnAddClients);
            tpSellsClients.Location = new Point(4, 24);
            tpSellsClients.Name = "tpSellsClients";
            tpSellsClients.Size = new Size(934, 395);
            tpSellsClients.TabIndex = 1;
            tpSellsClients.Text = "Clientes";
            tpSellsClients.UseVisualStyleBackColor = true;
            // 
            // btnAddClients
            // 
            btnAddClients.Depth = 0;
            btnAddClients.Icon = Properties.Resources.add;
            btnAddClients.Location = new Point(875, 336);
            btnAddClients.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddClients.Name = "btnAddClients";
            btnAddClients.Size = new Size(56, 56);
            btnAddClients.TabIndex = 1;
            btnAddClients.UseVisualStyleBackColor = true;
            // 
            // tpSellsArticles
            // 
            tpSellsArticles.Controls.Add(btnAddArticles);
            tpSellsArticles.Location = new Point(4, 24);
            tpSellsArticles.Name = "tpSellsArticles";
            tpSellsArticles.Size = new Size(934, 395);
            tpSellsArticles.TabIndex = 2;
            tpSellsArticles.Text = "Artículos";
            tpSellsArticles.UseVisualStyleBackColor = true;
            // 
            // btnAddArticles
            // 
            btnAddArticles.Depth = 0;
            btnAddArticles.Icon = Properties.Resources.add;
            btnAddArticles.Location = new Point(875, 336);
            btnAddArticles.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddArticles.Name = "btnAddArticles";
            btnAddArticles.Size = new Size(56, 56);
            btnAddArticles.TabIndex = 1;
            btnAddArticles.UseVisualStyleBackColor = true;
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
            Controls.Add(tcPrincipal);
            Controls.Add(statusStrip1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcPrincipal;
            DrawerUseColors = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "Main";
            Padding = new Padding(0, 64, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems";
            Load += Main_Load;
            tpUsers.ResumeLayout(false);
            tpHome.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            tcPrincipal.ResumeLayout(false);
            tpPurchases.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tpSells.ResumeLayout(false);
            tcSellsPages.ResumeLayout(false);
            tpSellsHistory.ResumeLayout(false);
            tpSellsClients.ResumeLayout(false);
            tpSellsArticles.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList imgList;
        private TabPage tpHome;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel lblWelcome;
        private TabPage tabIndustryArea;
        public TabPage tabAnimalArea;
        private DataGridView dataGridView1;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddUser;
        private TabPage tpLogout;
        public ReaLTaiizor.Controls.MaterialTabControl tcPrincipal;
        public TabPage tpUsers;
        private FlowLayoutPanel flowLayoutPanel4;
        public TabPage tabBlackBoard;
        private TabPage tpPurchases;
        private TabPage tpSells;
        private TabPage tpFinancialState;
        private ReaLTaiizor.Controls.MaterialTabControl tcSellsPages;
        private TabPage tpSellsHistory;
        private TabPage tpSellsClients;
        private TabPage tpSellsArticles;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector1;
        private ReaLTaiizor.Controls.MaterialTabControl materialTabControl1;
        private TabPage tpPurchasesHistory;
        private TabPage tpPurchasesProviders;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector2;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddSell;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddClients;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddArticles;
        private Panel panel1;
    }
}