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

        public override void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
            MyPen = GetPen();
            var centerCoordinates = Center.Replace(',','.').Split(';');
            var centerX = float.Parse(centerCoordinates[0]);
            var centerY = float.Parse(centerCoordinates[1]);
            g.DrawEllipse(MyPen, canvasWidth/2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
            if (Filled)
            {
                using (var brush = new SolidBrush(MyPen.Color))
                {
                    g.FillEllipse(brush, canvasWidth / 2 + centerX - Radius, canvasHeight / 2 + centerY - Radius, Radius + Radius, Radius + Radius);
                }
            }
        }
    }
}
