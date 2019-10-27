using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorGraphicViewer.Library
{
    public class Rectangle : Shape
    {
        private string[] topLeftCoordinates;

        public string A { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Filled { get; set; }

        public Rectangle()
        {
            ShapeType = ShapeType.Rectangle;
        }

        public override void Show(Graphics g, float canvasWidth, float canvasHeight, int scale)
        {
            MyPen = GetPen();
            topLeftCoordinates = A.Replace(',', '.').Split(';');
            var topLeftX = canvasWidth / 2 + float.Parse(topLeftCoordinates[0]);
            var topLeftY = canvasHeight / 2 - float.Parse(topLeftCoordinates[1]);
            var rectangle = new RectangleF(topLeftX, topLeftY, Width, Height);
            
            if(scale > 1)
                ScaleDrawing(g, rectangle, canvasWidth, canvasHeight, scale);
            g.DrawRectangles(MyPen, new[] { rectangle });

            if (Filled)
            {
                using (var brush = new SolidBrush(MyPen.Color))
                {
                    g.FillRectangle(brush, rectangle);
                }
            }
        }

        public override void ScaleDrawing(Graphics g, RectangleF rectangle, float canvasWidth, float canvasHeight, int scale)
        {
            g.ResetTransform();

            float drawingX = (rectangle.Left + rectangle.Right) / 2;
            float drawingY = (rectangle.Top + rectangle.Bottom) / 2;
            g.TranslateTransform(-drawingX, -drawingY);

            g.ScaleTransform(scale, scale, MatrixOrder.Append);
            
            float graphicsX = (rectangle.Left + rectangle.Right) / 2;
            float graphicsY = (rectangle.Top + rectangle.Bottom) / 2;
            g.TranslateTransform(graphicsX, graphicsY, MatrixOrder.Append);
        }

        public override void DrawShapeForPdf(PdfGraphics g, float pdfDocumentWidth, float pdfDocumentHeight)
        {
            PdfPen pdfPen = new PdfPen(MyPen.Color);
            PdfBrush brush = null;
            
            var topLeftX = pdfDocumentWidth / 2 + float.Parse(topLeftCoordinates[0]);
            var topLeftY = pdfDocumentHeight / 2 - float.Parse(topLeftCoordinates[1]);
            var pdfRectangle = new RectangleF(topLeftX, topLeftY, Width, Height);

            if (Filled)
            {
                brush = new PdfSolidBrush(pdfPen.Color);
            }
            g.DrawRectangle(pdfPen, brush, pdfRectangle);
        }
    }
}
