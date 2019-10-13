using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using VectorGraphicViewer.Library;
using VectorGraphicViewer.Library.Helper;

namespace VectorGraphicViewer
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Graphics g = null;

        private List<Shape> allShapes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g = canvas.CreateGraphics();
            g.Clear(DefaultBackColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string allJson = File.ReadAllText("Shapes.json");
            allShapes = JsonConvert.DeserializeObject<List<Shape>>(allJson, new ShapeReader());
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in allShapes)
            {
                shape.Show(g, canvas.Width, canvas.Height);
            }
        }
    }
}
