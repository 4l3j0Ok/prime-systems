namespace PrimeSystems.Views.Controls
{
    partial class ActivityLogTableItem
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
            lblAction = new ReaLTaiizor.Controls.MaterialLabel();
            lblModule = new ReaLTaiizor.Controls.MaterialLabel();
            lblUserUsername = new ReaLTaiizor.Controls.MaterialLabel();
            lblDate = new ReaLTaiizor.Controls.MaterialLabel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(lblAction, 3, 0);
            tableLayoutPanel1.Controls.Add(lblModule, 2, 0);
            tableLayoutPanel1.Controls.Add(lblUserUsername, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDate, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 30);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Depth = 0;
            lblAction.Dock = DockStyle.Fill;
            lblAction.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAction.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblAction.Location = new Point(603, 3);
            lblAction.Margin = new Padding(3);
            lblAction.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(194, 24);
            lblAction.TabIndex = 3;
            lblAction.Text = "Acción";
            lblAction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Depth = 0;
            lblModule.Dock = DockStyle.Fill;
            lblModule.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblModule.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblModule.Location = new Point(403, 3);
            lblModule.Margin = new Padding(3);
            lblModule.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(194, 24);
            lblModule.TabIndex = 2;
            lblModule.Text = "Módulo";
            lblModule.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserUsername
            // 
            lblUserUsername.AutoSize = true;
            lblUserUsername.Depth = 0;
            lblUserUsername.Dock = DockStyle.Fill;
            lblUserUsername.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUserUsername.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
            lblUserUsername.Location = new Point(203, 3);
            lblUserUsername.Margin = new Padding(3);
            lblUserUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblUserUsername.Name = "lblUserUsername";
            lblUserUsername.Size = new Size(194, 24);
            lblUserUsername.TabIndex = 1;
            lblUserUsername.Text = "Usuario";
            lblUserUsername.TextAlign = ContentAlignment.MiddleCenter;
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
            lblDate.Size = new Size(194, 24);
            lblDate.TabIndex = 0;
            lblDate.Text = "Fecha";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ActivityLogTableItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(0, 30);
            MinimumSize = new Size(800, 30);
            Name = "ActivityLogTableItem";
            Size = new Size(800, 30);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialLabel lblAction;
        private ReaLTaiizor.Controls.MaterialLabel lblModule;
        private ReaLTaiizor.Controls.MaterialLabel lblDate;
        public ReaLTaiizor.Controls.MaterialLabel lblUserUsername;
    }
}
