using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Library
{
    public class Circle : Shape
    {
        public string Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }

        public Circle()
        {
            ShapeType = ShapeType.Circle;
        }
        public Circle(LineType lineType, string color, string center, float radius, bool filled)
        {
            LineType = lineType;
            Color = color;
            ShapeType = ShapeType.Circle;
            Center = center;
            Radius = radius;
            Filled = filled;
        }
        public override void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
            MyPen = GetPen();
            var centerCoordinates = Center.Split(';');
            var centerX = float.Parse(centerCoordinates[0].Replace(',', '.'));
            var centerY = float.Parse(centerCoordinates[1].Replace(',', '.'));
            g.DrawEllipse(MyPen, canvasWidth/2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            if (Filled)
            {
                var brush = new SolidBrush(MyPen.Color);
                g.FillEllipse(brush, canvasWidth / 2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            }
        }
    }
}
