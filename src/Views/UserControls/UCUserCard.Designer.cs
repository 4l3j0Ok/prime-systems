using PrimeSystems.Data;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PrimeSystems.Views
{
    partial class UCUserCard
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pbUserProfilePicture = new ReaLTaiizor.Controls.ParrotPictureBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblUserUsername = new ReaLTaiizor.Controls.MaterialLabel();
            lblUserPhone = new ReaLTaiizor.Controls.MaterialLabel();
            lblUserArea = new ReaLTaiizor.Controls.MaterialLabel();
            lblUserName = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(pbUserProfilePicture, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(400, 70);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // pbUserProfilePicture
            // 
            pbUserProfilePicture.ColorLeft = Color.Black;
            pbUserProfilePicture.ColorRight = Color.Black;
            pbUserProfilePicture.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pbUserProfilePicture.Dock = DockStyle.Fill;
            pbUserProfilePicture.FilterAlpha = 200;
            pbUserProfilePicture.FilterEnabled = false;
            pbUserProfilePicture.Image = Properties.Resources.user_placeholder;
            pbUserProfilePicture.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.Low;
            pbUserProfilePicture.IsElipse = true;
            pbUserProfilePicture.IsParallax = false;
            pbUserProfilePicture.Location = new Point(9, 8);
            pbUserProfilePicture.Margin = new Padding(9, 8, 9, 8);
            pbUserProfilePicture.Name = "pbUserProfilePicture";
            pbUserProfilePicture.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            pbUserProfilePicture.Size = new Size(50, 54);
            pbUserProfilePicture.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pbUserProfilePicture.TabIndex = 1;
            pbUserProfilePicture.Text = "parrotPictureBox1";
            pbUserProfilePicture.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(lblUserName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(77, 8);
            panel1.Margin = new Padding(9, 8, 9, 8);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(314, 54);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(lblUserUsername, 0, 0);
            tableLayoutPanel2.Controls.Add(lblUserPhone, 2, 0);
            tableLayoutPanel2.Controls.Add(lblUserArea, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(4, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(306, 14);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // lblUserUsername
            // 
            lblUserUsername.AutoSize = true;
            lblUserUsername.Depth = 0;
            lblUserUsername.Dock = DockStyle.Fill;
            lblUserUsername.Font = new Font("Roboto", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            lblUserUsername.FontType = MaterialSkinManager.FontType.SubtleEmphasis;
            lblUserUsername.Location = new Point(3, 0);
            lblUserUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserUsername.Name = "lblUserUsername";
            lblUserUsername.Size = new Size(96, 14);
            lblUserUsername.TabIndex = 6;
            lblUserUsername.Text = "Nombre de usuario";
            // 
            // lblUserPhone
            // 
            lblUserPhone.AutoSize = true;
            lblUserPhone.Depth = 0;
            lblUserPhone.Dock = DockStyle.Fill;
            lblUserPhone.Font = new Font("Roboto", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            lblUserPhone.FontType = MaterialSkinManager.FontType.SubtleEmphasis;
            lblUserPhone.Location = new Point(207, 0);
            lblUserPhone.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserPhone.Name = "lblUserPhone";
            lblUserPhone.Size = new Size(96, 14);
            lblUserPhone.TabIndex = 4;
            lblUserPhone.Text = "Teléfono";
            lblUserPhone.TextAlign = ContentAlignment.TopRight;
            // 
            // lblUserArea
            // 
            lblUserArea.AutoSize = true;
            lblUserArea.Depth = 0;
            lblUserArea.Dock = DockStyle.Fill;
            lblUserArea.Font = new Font("Roboto", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            lblUserArea.FontType = MaterialSkinManager.FontType.SubtleEmphasis;
            lblUserArea.Location = new Point(105, 0);
            lblUserArea.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserArea.Name = "lblUserArea";
            lblUserArea.Size = new Size(96, 14);
            lblUserArea.TabIndex = 5;
            lblUserArea.Text = "Área";
            lblUserArea.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Depth = 0;
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUserName.FontType = MaterialSkinManager.FontType.Subtitle1;
            lblUserName.Location = new Point(4, 4);
            lblUserName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(118, 19);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Nombre Apellido";
            // 
            // UCUserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            Cursor = Cursors.Hand;
            MaximumSize = new Size(600, 70);
            MinimumSize = new Size(400, 70);
            Name = "UCUserCard";
            Size = new Size(400, 70);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        public ReaLTaiizor.Controls.ParrotPictureBox pbUserProfilePicture;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        public ReaLTaiizor.Controls.MaterialLabel lblUserUsername;
        public ReaLTaiizor.Controls.MaterialLabel lblUserPhone;
        public ReaLTaiizor.Controls.MaterialLabel lblUserArea;
        public ReaLTaiizor.Controls.MaterialLabel lblUserName;
    }
}
