using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace VectorGraphicViewer.Library
{
    public class Triangle : Shape
    {
        private string[] aCoordinates;
        private string[] bCoordinates;
        private string[] cCoordinates;

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public bool Filled { get; set; }

        public Triangle()
        {
            ShapeType = ShapeType.Triangle;
        }

        public override void Show(Graphics g, float canvasWidth, float canvasHeight, int scale)
        {
            MyPen = GetPen();
            aCoordinates = A.Replace(',', '.').Split(';');
            bCoordinates = B.Replace(',', '.').Split(';');
            cCoordinates = C.Replace(',', '.').Split(';');
            PointF[] points = new PointF[3];
            points[0] = new PointF(canvasWidth / 2 + float.Parse(aCoordinates[0]), canvasHeight / 2 - float.Parse(aCoordinates[1]));
            points[1] = new PointF(canvasWidth / 2 + float.Parse(bCoordinates[0]), canvasHeight / 2 - float.Parse(bCoordinates[1]));
            points[2] = new PointF(canvasWidth / 2 + float.Parse(cCoordinates[0]), canvasHeight / 2 - float.Parse(cCoordinates[1]));
            g.DrawPolygon(MyPen, points);
            if (Filled)
            {
                using (var brush = new SolidBrush(MyPen.Color))
                {
                    g.FillPolygon(brush, points);
                }
            }
        }

        public override void DrawShapeForPdf(PdfGraphics g, float pdfDocumentWidth, float pdfDocumentHeight)
        {
            PdfPen pdfPen = new PdfPen(MyPen.Color);
            PdfBrush brush = null;

            PointF[] points = new PointF[3];
            points[0] = new PointF(pdfDocumentWidth / 2 + float.Parse(aCoordinates[0]), pdfDocumentHeight / 2 - float.Parse(aCoordinates[1]));
            points[1] = new PointF(pdfDocumentWidth / 2 + float.Parse(bCoordinates[0]), pdfDocumentHeight / 2 - float.Parse(bCoordinates[1]));
            points[2] = new PointF(pdfDocumentWidth / 2 + float.Parse(cCoordinates[0]), pdfDocumentHeight / 2 - float.Parse(cCoordinates[1]));
            
            if (Filled)
            {
                brush = new PdfSolidBrush(MyPen.Color);
            }
            g.DrawPolygon(pdfPen, brush, points);
        }
    }
}
