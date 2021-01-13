using System.Collections.Generic;
using System.ComponentModel;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace NonVisualComponents
{
    public partial class ComponentWordHistogram : Component
    {
        public ComponentWordHistogram()
        {
            InitializeComponent();
        }

        public ComponentWordHistogram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateDiagram(List<DiagramModel> list, string seriesname, string path)
        {
            DocX document = DocX.Create(path);
            Series series = GetSeries(list, seriesname);
            document.InsertChart(CreateBarChart(series));
            document.Save();
        }

        private static Chart CreateBarChart(Series series)
        {
            BarChart pieChart = new BarChart();
            pieChart.AddLegend(ChartLegendPosition.Left, false);
            pieChart.AddSeries(series);
            return pieChart;
        }

        public static Series GetSeries(List<DiagramModel> list, string name)
        {
            Series series = new Series(name);
            series.Bind(list, "Count", "Month");
            return series;
        }
    }

}