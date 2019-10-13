using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Library
{
    public class Triangle: Shape
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public bool Filled { get; set; }

        public Triangle() { ShapeType = ShapeType.Triangle;  }
        public Triangle(string a, string b, string c, bool filled,LineType lineType, string color)
        {
            A = a;
            B = b;
            C = c;
            LineType = lineType;
            Color = color;
            ShapeType = ShapeType.Triangle;
            Filled = filled;
        }
        public override void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
            MyPen = GetPen();
            var aCoordinates = A.Split(';');
            var bCoordinates = B.Split(';');
            var cCoordinates = C.Split(';');
            PointF[] points = new PointF[3];
            points[0] = new PointF(canvasWidth/2 + float.Parse(aCoordinates[0]), canvasHeight/2 + float.Parse(aCoordinates[1]));
            points[1] = new PointF(canvasWidth/2 + float.Parse(bCoordinates[0]), canvasHeight/2 + float.Parse(bCoordinates[1]));
            points[2] = new PointF(canvasWidth/2 + float.Parse(cCoordinates[0]), canvasHeight/2 + float.Parse(cCoordinates[1]));
            g.DrawPolygon(MyPen, points);
            if (Filled)
            {
                var brush = new SolidBrush(MyPen.Color);
                g.FillPolygon(brush, points);
            }
        }
    }
}
