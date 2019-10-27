using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace VectorGraphicViewer.Library
{
    public class Line : Shape
    {
        private float startX, startY, endX, endY;

        public string A { get; set; }
        public string B { get; set; }

        public Line()
        {
            ShapeType = ShapeType.Line;
        }

        public override void Show(Graphics g, float canvasWidth, float canvasHeight, int scale)
        {
            MyPen = GetPen();
            var startCoordinates = A.Replace(',', '.').Split(';');
            var endCoordinates = B.Replace(',', '.').Split(';');
            startX = float.Parse(startCoordinates[0]);
            startY = float.Parse(startCoordinates[1]);
            endX = float.Parse(endCoordinates[0]);
            endY = float.Parse(endCoordinates[1]);
            PointF[] points =
            {
                new PointF(canvasWidth / 2 + startX,canvasHeight / 2 + startY),
                new PointF(canvasWidth / 2 + endX, canvasHeight / 2 - endY)
            };
            g.DrawLines(MyPen, points);
        }

        public override void DrawShapeForPdf(PdfGraphics g, float pdfDocumentWidth, float pdfDocumentHeight)
        {
            PdfPen pdfPen = new PdfPen(MyPen.Color);
            PointF[] points =
            {
                new PointF(pdfDocumentWidth / 2 + startX,pdfDocumentHeight / 2 + startY),
                new PointF(pdfDocumentWidth / 2 + endX, pdfDocumentHeight / 2 - endY)
            };
            g.DrawLine(pdfPen, points[0], points[1]);
        }
    }
}
