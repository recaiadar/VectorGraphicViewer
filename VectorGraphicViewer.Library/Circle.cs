using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Library
{
    public class Circle : Shape
    {
        Pen myPen = new Pen(System.Drawing.Color.Black);

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
            myPen.Width = 2;
            var argbColors = GetColors(Color);
            myPen.Color = System.Drawing.Color.FromArgb(argbColors[0], argbColors[1], argbColors[2], argbColors[3]);
            myPen.DashStyle = GetDashStyle();
            var centerCoordinates = Center.Split(';');
            var centerX = float.Parse(centerCoordinates[0]);
            var centerY = float.Parse(centerCoordinates[1]);
            g.DrawEllipse(myPen, canvasWidth/2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            if (Filled)
            {
                var brush = new SolidBrush(myPen.Color);
                g.FillEllipse(brush, canvasWidth / 2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            }
        }
    }
}
