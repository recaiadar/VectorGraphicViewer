using System;
using System.Collections.Generic;
using System.Drawing;

namespace VectorGraphicViewer.Library
{
    public abstract class Shape
    {
        public ShapeType ShapeType { get; set; }
        public LineType LineType { get; set; }
        public string Color { get; set; }
        public Pen MyPen { get; set; }
        public List<int> ArgbColors { get; set; }

        public virtual Pen GetPen()
        {
            ArgbColors = GetColors(Color);
            MyPen = new Pen(System.Drawing.Color.Black)
            {
                Width = 2,
                Color = System.Drawing.Color.FromArgb(ArgbColors[0], ArgbColors[1], ArgbColors[2], ArgbColors[3]),
                DashStyle = GetDashStyle()
            };
            return MyPen;
        }
        
        public virtual void Show(Graphics g, float canvasWidth, float canvasHeight)
        {
        }

        public virtual System.Drawing.Drawing2D.DashStyle GetDashStyle()
        {
            switch (LineType)
            {
                case LineType.Solid:
                    return System.Drawing.Drawing2D.DashStyle.Solid;
                case LineType.Dot:
                    return System.Drawing.Drawing2D.DashStyle.Dot;
                case LineType.Dash:
                    return System.Drawing.Drawing2D.DashStyle.Dash;
                case LineType.DashDot:
                    return System.Drawing.Drawing2D.DashStyle.DashDot;
            }
            throw new Exception("Invalid line type");
        }

        public virtual List<int> GetColors(string color)
        {
            List<int> colorList = new List<int>();
            var colors = color.Split(';');
            foreach (var colorNumber in colors)
            {
                colorList.Add(int.Parse(colorNumber.ToString().TrimEnd()));
            }
            return colorList;
        }
    }
}
