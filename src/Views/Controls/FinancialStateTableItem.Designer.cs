namespace PrimeSystems.Views.Controls
{
    partial class FinancialStateTableItem
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
            lblUserName = new ReaLTaiizor.Controls.MaterialLabel();
            lblDate = new ReaLTaiizor.Controls.MaterialLabel();
            lblAmount = new ReaLTaiizor.Controls.MaterialLabel();
            lblModule = new ReaLTaiizor.Controls.MaterialLabel();
            lblAction = new ReaLTaiizor.Controls.MaterialLabel();
            lblShowDetails = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(lblShowDetails, 5, 0);
            tableLayoutPanel1.Controls.Add(lblAction, 3, 0);
            tableLayoutPanel1.Controls.Add(lblModule, 2, 0);
            tableLayoutPanel1.Controls.Add(lblUserName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDate, 0, 0);
            tableLayoutPanel1.Controls.Add(lblAmount, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 30);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Depth = 0;
            lblUserName.Dock = DockStyle.Fill;
            lblUserName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUserName.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblUserName.Location = new Point(136, 3);
            lblUserName.Margin = new Padding(3);
            lblUserName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(127, 24);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Pedrito Pascal";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Depth = 0;
            lblDate.Dock = DockStyle.Fill;
            lblDate.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDate.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblDate.Location = new Point(3, 3);
            lblDate.Margin = new Padding(3);
            lblDate.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(127, 24);
            lblDate.TabIndex = 0;
            lblDate.Text = "17/11/2025";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Depth = 0;
            lblAmount.Dock = DockStyle.Fill;
            lblAmount.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAmount.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblAmount.Location = new Point(535, 3);
            lblAmount.Margin = new Padding(3);
            lblAmount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(127, 24);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "$5000";
            lblAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Depth = 0;
            lblModule.Dock = DockStyle.Fill;
            lblModule.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblModule.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblModule.HighEmphasis = true;
            lblModule.Location = new Point(269, 3);
            lblModule.Margin = new Padding(3);
            lblModule.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(127, 24);
            lblModule.TabIndex = 9;
            lblModule.Text = "Ventas";
            lblModule.TextAlign = ContentAlignment.MiddleCenter;
            lblModule.UseAccent = true;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Depth = 0;
            lblAction.Dock = DockStyle.Fill;
            lblAction.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAction.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblAction.Location = new Point(402, 3);
            lblAction.Margin = new Padding(3);
            lblAction.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(127, 24);
            lblAction.TabIndex = 10;
            lblAction.Text = "Creación";
            lblAction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShowDetails
            // 
            lblShowDetails.AutoSize = true;
            lblShowDetails.Cursor = Cursors.Hand;
            lblShowDetails.Depth = 0;
            lblShowDetails.Dock = DockStyle.Fill;
            lblShowDetails.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblShowDetails.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
            lblShowDetails.HighEmphasis = true;
            lblShowDetails.Location = new Point(668, 3);
            lblShowDetails.Margin = new Padding(3);
            lblShowDetails.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblShowDetails.Name = "lblShowDetails";
            lblShowDetails.Size = new Size(129, 24);
            lblShowDetails.TabIndex = 11;
            lblShowDetails.Text = "Ver";
            lblShowDetails.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FinancialStateTableItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(0, 30);
            MinimumSize = new Size(800, 30);
            Name = "FinancialStateTableItem";
            Size = new Size(800, 30);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialLabel lblUserName;
        private ReaLTaiizor.Controls.MaterialLabel lblDate;
        private ReaLTaiizor.Controls.MaterialLabel lblAction;
        private ReaLTaiizor.Controls.MaterialLabel lblModule;
        private ReaLTaiizor.Controls.MaterialLabel lblAmount;
        public ReaLTaiizor.Controls.MaterialLabel lblShowDetails;
    }
}
