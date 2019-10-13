using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Library
{
    public class Rectangle : Shape
    {
        public string A { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Filled { get; set; }

        public Rectangle() { ShapeType = ShapeType.Rectangle; }
        public Rectangle(string a, float width, float height, bool filled, LineType lineType, string color)
        {
            A = a;
            Width = width;
            Height = height;
            LineType = lineType;
            Color = color;
            ShapeType = ShapeType.Rectangle;
            Filled = filled;
        }
        public override void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
            MyPen = GetPen();
            var topLeftCoordinates = A.Split(';');
            var topLeftX = canvasWidth / 2 + float.Parse(topLeftCoordinates[0]);
            var topLeftY = canvasHeight / 2 + float.Parse(topLeftCoordinates[1]);
            var rectangle = new System.Drawing.Rectangle((int)topLeftX, (int)topLeftY, (int)Width, (int)Height);
            g.DrawRectangle(MyPen, rectangle);
            if (Filled)
            {
                var brush = new SolidBrush(MyPen.Color);
                g.FillRectangle(brush, rectangle);
            }
        }
    }
}
