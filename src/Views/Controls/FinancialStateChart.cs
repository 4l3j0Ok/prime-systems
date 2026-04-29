using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Defaults;
using SkiaSharp;

namespace PrimeSystems.Views.Controls
{
    public partial class FinancialStateChart : UserControl
    {
        private ISeries[] _sellSeries = Array.Empty<ISeries>();
        private ISeries[] _purchaseSeries = Array.Empty<ISeries>();

        public FinancialStateChart()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            _sellSeries = new ISeries[]
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Ventas",
                    Values = new List<DateTimePoint>(),
                    Stroke = new SolidColorPaint(SKColors.DodgerBlue) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 8,
                    GeometryStroke = new SolidColorPaint(SKColors.DodgerBlue) { StrokeThickness = 2 },
                    GeometryFill = new SolidColorPaint(SKColors.White),
                    LineSmoothness = 0
                }
            };

            _purchaseSeries = new ISeries[]
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Compras",
                    Values = new List<DateTimePoint>(),
                    Stroke = new SolidColorPaint(SKColors.OrangeRed) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 8,
                    GeometryStroke = new SolidColorPaint(SKColors.OrangeRed) { StrokeThickness = 2 },
                    GeometryFill = new SolidColorPaint(SKColors.White),
                    LineSmoothness = 0
                }
            };

            chart.Series = new ISeries[]
            {
                _sellSeries[0],
                _purchaseSeries[0]
            };

            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Fecha",
                    NamePaint = new SolidColorPaint(SKColors.DimGray),
                    LabelsPaint = new SolidColorPaint(SKColors.DimGray),
                    TextSize = 11,
                    LabelsRotation = -45,
                    AnimationsSpeed = TimeSpan.FromMilliseconds(500),
                    Labeler = value => new DateTime((long)value).ToString("dd/MM")
                }
            };

            chart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Monto",
                    NamePaint = new SolidColorPaint(SKColors.DimGray),
                    LabelsPaint = new SolidColorPaint(SKColors.DimGray),
                    TextSize = 11,
                    Labeler = value => value.ToString("C0"),
                    AnimationsSpeed = TimeSpan.FromMilliseconds(500)
                }
            };

            chart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
            chart.LegendTextPaint = new SolidColorPaint(SKColors.DimGray);
            chart.AnimationsSpeed = TimeSpan.FromMilliseconds(500);
        }

        public void UpdateData(List<FinancialDataPoint> sellData, List<FinancialDataPoint> purchaseData)
        {
            var sellPoints = sellData.Select(d => new DateTimePoint(d.Date, (double)d.Amount)).ToList();
            var purchasePoints = purchaseData.Select(d => new DateTimePoint(d.Date, (double)d.Amount)).ToList();

            ((LineSeries<DateTimePoint>)_sellSeries[0]).Values = sellPoints;
            ((LineSeries<DateTimePoint>)_purchaseSeries[0]).Values = purchasePoints;
        }
    }

    public class FinancialDataPoint
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public FinancialDataPoint(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}