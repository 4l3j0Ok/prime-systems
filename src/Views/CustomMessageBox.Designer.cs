using System.Windows.Forms;
using System.Drawing;

namespace PrimeSystems
{
    partial class CustomMessageBox
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
            btnLeft = new ReaLTaiizor.Controls.MaterialButton();
            btnRight = new ReaLTaiizor.Controls.MaterialButton();
            lblMessage = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLeft
            // 
            btnLeft.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLeft.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLeft.Depth = 0;
            btnLeft.Dock = DockStyle.Top;
            btnLeft.HighEmphasis = true;
            btnLeft.Icon = null;
            btnLeft.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnLeft.Location = new Point(4, 6);
            btnLeft.Margin = new Padding(4, 6, 4, 6);
            btnLeft.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnLeft.Name = "btnLeft";
            btnLeft.NoAccentTextColor = Color.Empty;
            btnLeft.Size = new Size(256, 36);
            btnLeft.TabIndex = 0;
            btnLeft.Text = "Aceptar";
            btnLeft.TextAlign = ContentAlignment.MiddleLeft;
            btnLeft.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLeft.UseAccentColor = false;
            btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            btnRight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRight.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRight.Depth = 0;
            btnRight.Dock = DockStyle.Top;
            btnRight.HighEmphasis = true;
            btnRight.Icon = null;
            btnRight.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRight.Location = new Point(268, 6);
            btnRight.Margin = new Padding(4, 6, 4, 6);
            btnRight.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRight.Name = "btnRight";
            btnRight.NoAccentTextColor = Color.Empty;
            btnRight.Size = new Size(256, 36);
            btnRight.TabIndex = 1;
            btnRight.Text = "Cancelar";
            btnRight.TextAlign = ContentAlignment.MiddleLeft;
            btnRight.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRight.UseAccentColor = false;
            btnRight.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            lblMessage.Depth = 0;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMessage.Location = new Point(23, 20);
            lblMessage.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(528, 192);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Texto de ejemplo";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnRight, 1, 0);
            tableLayoutPanel1.Controls.Add(btnLeft, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(23, 215);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(528, 49);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(lblMessage, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 24);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(20);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel2.Size = new Size(574, 287);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(580, 314);
            Controls.Add(tableLayoutPanel2);
            FormStyle = ReaLTaiizor.Enum.Material.FormStyles.ActionBar_None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(580, 314);
            Name = "CustomMessageBox";
            Padding = new Padding(3, 24, 3, 3);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Título";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        public ReaLTaiizor.Controls.MaterialButton btnLeft;
        public ReaLTaiizor.Controls.MaterialButton btnRight;
        public ReaLTaiizor.Controls.MaterialLabel lblMessage;
    }
}