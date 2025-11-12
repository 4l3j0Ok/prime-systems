using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PrimeSystems.Views.Controls
{
    partial class Card
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
            pbPicture = new ReaLTaiizor.Controls.ParrotPictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            lblDescription = new ReaLTaiizor.Controls.MaterialLabel();
            lblTitle = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnRemove = new ReaLTaiizor.Controls.MaterialButton();
            btnEdit = new ReaLTaiizor.Controls.MaterialButton();
            materialCheckBox1 = new ReaLTaiizor.Controls.MaterialCheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pbPicture, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel1.Controls.Add(materialCheckBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(991, 58);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // pbPicture
            // 
            pbPicture.ColorLeft = Color.Black;
            pbPicture.ColorRight = Color.Black;
            pbPicture.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pbPicture.Dock = DockStyle.Fill;
            pbPicture.FilterAlpha = 200;
            pbPicture.FilterEnabled = false;
            pbPicture.Image = Properties.Resources.user_placeholder;
            pbPicture.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.Low;
            pbPicture.IsElipse = true;
            pbPicture.IsParallax = false;
            pbPicture.Location = new Point(44, 8);
            pbPicture.Margin = new Padding(9, 8, 9, 8);
            pbPicture.Name = "pbPicture";
            pbPicture.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            pbPicture.Size = new Size(42, 42);
            pbPicture.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pbPicture.TabIndex = 3;
            pbPicture.Text = "parrotPictureBox1";
            pbPicture.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(98, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(890, 52);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDescription);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 4);
            panel1.Margin = new Padding(0, 4, 0, 5);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(624, 43);
            panel1.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Depth = 0;
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Font = new Font("Roboto", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            lblDescription.FontType = MaterialSkinManager.FontType.SubtleEmphasis;
            lblDescription.Location = new Point(4, 23);
            lblDescription.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(616, 14);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Descripcion";
            // 
            // lblTitle
            // 
            lblTitle.Depth = 0;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkinManager.FontType.Subtitle1;
            lblTitle.Location = new Point(4, 4);
            lblTitle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(616, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Título";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(btnRemove, 1, 0);
            tableLayoutPanel3.Controls.Add(btnEdit, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(624, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.MaximumSize = new Size(266, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(0, 3, 0, 3);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(266, 52);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // btnRemove
            // 
            btnRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemove.Depth = 0;
            btnRemove.Dock = DockStyle.Fill;
            btnRemove.HighEmphasis = true;
            btnRemove.Icon = Properties.Resources.trash;
            btnRemove.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRemove.Location = new Point(137, 9);
            btnRemove.Margin = new Padding(4, 6, 4, 6);
            btnRemove.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRemove.Name = "btnRemove";
            btnRemove.NoAccentTextColor = Color.Empty;
            btnRemove.Size = new Size(125, 34);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remover";
            btnRemove.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemove.UseAccentColor = true;
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEdit.Depth = 0;
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.HighEmphasis = true;
            btnEdit.Icon = Properties.Resources.edit;
            btnEdit.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnEdit.Location = new Point(4, 9);
            btnEdit.Margin = new Padding(4, 6, 4, 6);
            btnEdit.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnEdit.Name = "btnEdit";
            btnEdit.NoAccentTextColor = Color.Empty;
            btnEdit.Size = new Size(125, 34);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Editar";
            btnEdit.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEdit.UseAccentColor = false;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox1
            // 
            materialCheckBox1.AutoSize = true;
            materialCheckBox1.Depth = 0;
            materialCheckBox1.Dock = DockStyle.Fill;
            materialCheckBox1.Location = new Point(0, 0);
            materialCheckBox1.Margin = new Padding(0);
            materialCheckBox1.MouseLocation = new Point(-1, -1);
            materialCheckBox1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCheckBox1.Name = "materialCheckBox1";
            materialCheckBox1.ReadOnly = false;
            materialCheckBox1.Ripple = true;
            materialCheckBox1.Size = new Size(35, 58);
            materialCheckBox1.TabIndex = 0;
            materialCheckBox1.UseAccentColor = false;
            materialCheckBox1.UseVisualStyleBackColor = true;
            materialCheckBox1.Visible = false;
            // 
            // Card
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(410, 58);
            Name = "Card";
            Size = new Size(991, 58);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        public ReaLTaiizor.Controls.ParrotPictureBox pbPicture;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        public ReaLTaiizor.Controls.MaterialLabel lblDescription;
        public ReaLTaiizor.Controls.MaterialLabel lblTitle;
        private TableLayoutPanel tableLayoutPanel3;
        private ReaLTaiizor.Controls.MaterialButton btnRemove;
        private ReaLTaiizor.Controls.MaterialButton btnEdit;
        private ReaLTaiizor.Controls.MaterialCheckBox materialCheckBox1;
    }
}
