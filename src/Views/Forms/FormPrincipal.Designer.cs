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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormPrincipal));
            imgList = new ImageList(components);
            tabUsers = new TabPage();
            btnAddUser = new ReaLTaiizor.Controls.MaterialFloatingActionButton();
            lblEmptyUsers = new ReaLTaiizor.Controls.MaterialLabel();
            flpUsersList = new FlowLayoutPanel();
            tabHome = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            lblWelcome = new ReaLTaiizor.Controls.MaterialLabel();
            tcPrincipal = new ReaLTaiizor.Controls.MaterialTabControl();
            tabLogout = new TabPage();
            flowLayoutPanel4 = new FlowLayoutPanel();
            tabSells = new TabPage();
            tabPurchases = new TabPage();
            tabProviders = new TabPage();
            tabFinancialState = new TabPage();
            tabUsers.SuspendLayout();
            tabHome.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            tcPrincipal.SuspendLayout();
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
            // tabUsers
            // 
            tabUsers.AutoScroll = true;
            tabUsers.Controls.Add(btnAddUser);
            tabUsers.Controls.Add(lblEmptyUsers);
            tabUsers.Controls.Add(flpUsersList);
            tabUsers.ImageKey = "user.png";
            tabUsers.Location = new Point(4, 39);
            tabUsers.Name = "tabUsers";
            tabUsers.Padding = new Padding(20);
            tabUsers.Size = new Size(936, 490);
            tabUsers.TabIndex = 3;
            tabUsers.Text = "Usuarios";
            tabUsers.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddUser.Depth = 0;
            btnAddUser.Icon = null;
            btnAddUser.Location = new Point(877, 431);
            btnAddUser.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(56, 56);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Agregar Usuario";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // lblEmptyUsers
            // 
            lblEmptyUsers.Depth = 0;
            lblEmptyUsers.Dock = DockStyle.Fill;
            lblEmptyUsers.FlatStyle = FlatStyle.Flat;
            lblEmptyUsers.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblEmptyUsers.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H5;
            lblEmptyUsers.Location = new Point(20, 20);
            lblEmptyUsers.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblEmptyUsers.Name = "lblEmptyUsers";
            lblEmptyUsers.Size = new Size(896, 450);
            lblEmptyUsers.TabIndex = 5;
            lblEmptyUsers.Text = "Aún no tienes usuarios agregados... Comienza por agregar uno.";
            lblEmptyUsers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpUsersList
            // 
            flpUsersList.Dock = DockStyle.Fill;
            flpUsersList.Location = new Point(20, 20);
            flpUsersList.Name = "flpUsersList";
            flpUsersList.Size = new Size(896, 450);
            flpUsersList.TabIndex = 1;
            // 
            // tabHome
            // 
            tabHome.Controls.Add(tableLayoutPanel1);
            tabHome.ImageKey = "home.png";
            tabHome.Location = new Point(4, 39);
            tabHome.Name = "tabHome";
            tabHome.Padding = new Padding(20);
            tabHome.Size = new Size(936, 490);
            tabHome.TabIndex = 0;
            tabHome.Text = "Inicio";
            tabHome.UseVisualStyleBackColor = true;
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
            tableLayoutPanel1.Size = new Size(896, 450);
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
            pictureBox1.Size = new Size(856, 304);
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
            lblWelcome.Location = new Point(3, 344);
            lblWelcome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(890, 41);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Bienvenido a Prime Systems";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tcPrincipal
            // 
            tcPrincipal.Controls.Add(tabHome);
            tcPrincipal.Controls.Add(tabPurchases);
            tcPrincipal.Controls.Add(tabSells);
            tcPrincipal.Controls.Add(tabProviders);
            tcPrincipal.Controls.Add(tabFinancialState);
            tcPrincipal.Controls.Add(tabUsers);
            tcPrincipal.Controls.Add(tabLogout);
            tcPrincipal.Depth = 0;
            tcPrincipal.Dock = DockStyle.Fill;
            tcPrincipal.ImageList = imgList;
            tcPrincipal.ItemSize = new Size(120, 35);
            tcPrincipal.Location = new Point(3, 64);
            tcPrincipal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tcPrincipal.Multiline = true;
            tcPrincipal.Name = "tcPrincipal";
            tcPrincipal.Padding = new Point(10, 3);
            tcPrincipal.SelectedIndex = 0;
            tcPrincipal.Size = new Size(944, 533);
            tcPrincipal.TabIndex = 0;
            // 
            // tabLogout
            // 
            tabLogout.ImageKey = "logout.png";
            tabLogout.Location = new Point(4, 39);
            tabLogout.Name = "tabLogout";
            tabLogout.Padding = new Padding(3);
            tabLogout.Size = new Size(936, 490);
            tabLogout.TabIndex = 8;
            tabLogout.Text = "Cerrar Sesión";
            tabLogout.UseVisualStyleBackColor = true;
            tabLogout.Enter += tabCerrarSesion_Click;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(200, 100);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // tabSells
            // 
            tabSells.ImageKey = "sells.png";
            tabSells.Location = new Point(4, 39);
            tabSells.Name = "tabSells";
            tabSells.Size = new Size(936, 490);
            tabSells.TabIndex = 9;
            tabSells.Text = "Ventas";
            tabSells.UseVisualStyleBackColor = true;
            // 
            // tabPurchases
            // 
            tabPurchases.ImageKey = "purchases.png";
            tabPurchases.Location = new Point(4, 39);
            tabPurchases.Name = "tabPurchases";
            tabPurchases.Size = new Size(936, 490);
            tabPurchases.TabIndex = 10;
            tabPurchases.Text = "Compras";
            tabPurchases.UseVisualStyleBackColor = true;
            // 
            // tabProviders
            // 
            tabProviders.ImageKey = "provider.png";
            tabProviders.Location = new Point(4, 39);
            tabProviders.Name = "tabProviders";
            tabProviders.Size = new Size(936, 490);
            tabProviders.TabIndex = 11;
            tabProviders.Text = "Proveedores";
            tabProviders.UseVisualStyleBackColor = true;
            // 
            // tabFinancialState
            // 
            tabFinancialState.ImageKey = "financial-state.png";
            tabFinancialState.Location = new Point(4, 39);
            tabFinancialState.Name = "tabFinancialState";
            tabFinancialState.Size = new Size(936, 490);
            tabFinancialState.TabIndex = 12;
            tabFinancialState.Text = "Estado Contable";
            tabFinancialState.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(950, 600);
            Controls.Add(tcPrincipal);
            DrawerHighlightWithAccent = false;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcPrincipal;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prime Systems";
            Load += FormPrincipal_Load;
            tabUsers.ResumeLayout(false);
            tabHome.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            tcPrincipal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ImageList imgList;
        private TabPage tabHome;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.MaterialLabel lblWelcome;
        private TabPage tabIndustryArea;
        public TabPage tabAnimalArea;
        private DataGridView dataGridView1;
        private ReaLTaiizor.Controls.MaterialFloatingActionButton btnAddUser;
        private TabPage tabLogout;
        public ReaLTaiizor.Controls.MaterialTabControl tcPrincipal;
        public TabPage tabUsers;
        private FlowLayoutPanel flowLayoutPanel4;
        private ReaLTaiizor.Controls.MaterialLabel lblEmptyUsers;
        public TabPage tabBlackBoard;
        private FlowLayoutPanel flpUsersList;
        private TabPage tabPurchases;
        private TabPage tabSells;
        private TabPage tabProviders;
        private TabPage tabFinancialState;
    }
}