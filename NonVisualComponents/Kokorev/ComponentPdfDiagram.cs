using System;
using System.ComponentModel;
using System.Reflection;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using DataLabelType = MigraDoc.DocumentObjectModel.Shapes.Charts.DataLabelType;

namespace NonVisualComponents.Kokorev
{
    public partial class ComponentPdfDiagram : Component
    {
        public ComponentPdfDiagram()
        {
            InitializeComponent();
        }

        public ComponentPdfDiagram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        /// <summary>
        /// публичный метод для создания круговой диаграммы в pdf
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="dataObject">объект с данными</param>
        /// <param name="dataLabelType">подписи к графику</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="Exception"></exception>
        public void CreatePdfDiagram<T>(string fileName, T dataObject, DataLabelType dataLabelType)
        {
            if (fileName.Length == 0)
                throw new Exception("Имя файла пустое");
            
            var document = new Document();
            var section = document.AddSection();
            var paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = Unit.FromCentimeter(1);
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            var chart = document.LastSection.AddChart(ChartType.Pie2D);
            chart.Left = 0;
            chart.Width = Unit.FromCentimeter(12);
            chart.Height = Unit.FromCentimeter(12);
            chart.DataLabel.Type = dataLabelType;

            var values = chart.SeriesCollection.AddSeries();

            var fields = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var field in fields)
            {
                double numValue;
                var parsed = double.TryParse(field.GetValue(dataObject).ToString(), out numValue);
                if (parsed)
                    values.Add(numValue);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true,PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(fileName);
        }
    }
}