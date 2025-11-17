namespace PrimeSystems.Views.Controls
{
    partial class FinancialStateCard
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
            pTotalRevenue = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblValue = new ReaLTaiizor.Controls.MaterialLabel();
            lblTitle = new ReaLTaiizor.Controls.MaterialLabel();
            pTotalRevenue.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pTotalRevenue
            // 
            pTotalRevenue.AutoSize = true;
            pTotalRevenue.BackColor = Color.White;
            pTotalRevenue.Controls.Add(tableLayoutPanel2);
            pTotalRevenue.Dock = DockStyle.Fill;
            pTotalRevenue.Location = new Point(0, 0);
            pTotalRevenue.Name = "pTotalRevenue";
            pTotalRevenue.Size = new Size(200, 95);
            pTotalRevenue.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lblValue, 0, 1);
            tableLayoutPanel2.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(200, 95);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Depth = 0;
            lblValue.Dock = DockStyle.Fill;
            lblValue.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblValue.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            lblValue.HighEmphasis = true;
            lblValue.Location = new Point(6, 37);
            lblValue.Margin = new Padding(6);
            lblValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(188, 52);
            lblValue.TabIndex = 1;
            lblValue.Text = "$16.800,00";
            lblValue.TextAlign = ContentAlignment.MiddleLeft;
            lblValue.UseAccent = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTitle.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            lblTitle.Location = new Point(6, 6);
            lblTitle.Margin = new Padding(6);
            lblTitle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(123, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Total de Ingresos";
            lblTitle.UseAccent = true;
            // 
            // FinancialStateCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pTotalRevenue);
            MinimumSize = new Size(200, 95);
            Name = "FinancialStateCard";
            Size = new Size(200, 95);
            pTotalRevenue.ResumeLayout(false);
            pTotalRevenue.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pTotalRevenue;
        private TableLayoutPanel tableLayoutPanel2;
        public ReaLTaiizor.Controls.MaterialLabel lblValue;
        public ReaLTaiizor.Controls.MaterialLabel lblTitle;
    }
}
