namespace PrimeSystems.Views.Controls
{
    partial class FinancialStateChart
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            chart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            SuspendLayout();
            // 
            // chart
            // 
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(0, 0);
            chart.Margin = new Padding(0);
            chart.Name = "chart";
            chart.Size = new Size(880, 200);
            chart.TabIndex = 0;
            // 
            // FinancialStateChart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(chart);
            MinimumSize = new Size(400, 200);
            Name = "FinancialStateChart";
            Size = new Size(880, 200);
            ResumeLayout(false);
        }

        public LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart;
    }
}