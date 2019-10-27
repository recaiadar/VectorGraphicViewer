using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace VectorGraphicViewer.Library
{
    public class Circle : Shape
    {
        private float centerX, centerY;

        public string Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }

        public Circle()
        {
            ShapeType = ShapeType.Circle;
        }

        public override void Show(Graphics g, float canvasWidth, float canvasHeight, int scale)
        {
            MyPen = GetPen();
            var centerCoordinates = Center.Replace(',', '.').Split(';');
            centerX = float.Parse(centerCoordinates[0]);
            centerY = float.Parse(centerCoordinates[1]);
            g.DrawEllipse(MyPen, canvasWidth / 2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            if (Filled)
            {
                using (var brush = new SolidBrush(MyPen.Color))
                {
                    g.FillEllipse(brush, canvasWidth / 2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
                }
            }
        }

        public override void DrawShapeForPdf(PdfGraphics g, float pdfDocumentWidth, float pdfDocumentHeight)
        {
            PdfPen pdfPen = new PdfPen(MyPen.Color);
            PdfBrush brush = null;
            if (Filled)
            {
                brush = new PdfSolidBrush(MyPen.Color);
            }
            g.DrawEllipse(pdfPen, brush, pdfDocumentWidth / 2 + centerX - Radius, pdfDocumentHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
        }
    }
}
