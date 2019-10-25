using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Library
{
    public class Line : Shape
    {
        public string A { get; set; }
        public string B { get; set; }

        public Line() { ShapeType = ShapeType.Line; }
        public Line(string a, string b, string color, LineType lineType)
        {
            A = a;
            B = b;
            Color = color;
            LineType = LineType;
            ShapeType = ShapeType.Line;
        }
        public override void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
            MyPen = GetPen();
            var startCoordinates = A.Split(';');
            var endCoordinates = B.Split(';');
            var startX = float.Parse(startCoordinates[0].Replace(',', '.'));
            var startY = float.Parse(startCoordinates[1].Replace(',', '.'));
            var endX = float.Parse(endCoordinates[0].Replace(',', '.'));
            var endY = float.Parse(endCoordinates[1].Replace(',', '.'));
            PointF[] points =
            {
                new PointF(canvasWidth / 2 + startX,canvasHeight / 2 + startY),
                new PointF(canvasWidth / 2 + endX, canvasHeight / 2 - endY)
            };
            g.DrawLines(MyPen, points);
        }
    }
}
