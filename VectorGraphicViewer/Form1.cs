using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using VectorGraphicViewer.Library;
using VectorGraphicViewer.Library.Helper;

namespace VectorGraphicViewer
{
    public partial class Form1 : Form
    {
        Graphics g = null;
        private List<Shape> allShapes;
        private const int INITIALCANVASWIDTH = 584;
        private const int INITIALCANVASHEIGHT = 367;

        public int FormSizeScale { get; set; } = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g = canvas.CreateGraphics();
            g.Clear(DefaultBackColor);
            var widthScale = canvas.Width / INITIALCANVASWIDTH;
            var heightScale = canvas.Height / INITIALCANVASHEIGHT;
            FormSizeScale = Math.Min(widthScale, heightScale);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string allJson = File.ReadAllText("Shapes.json");
                allShapes = JsonConvert.DeserializeObject<List<Shape>>(allJson, new ShapeReader());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                foreach (var shape in allShapes)
                {
                    shape.Show(g, canvas.Width, canvas.Height, FormSizeScale);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnLoadFromXml_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Shapes.xml");
                string allJson = JsonConvert.SerializeXmlNode(doc.LastChild);
                var jObject = JObject.Parse(allJson);
                var elements = jObject["root"]["element"];
                allShapes = JsonConvert.DeserializeObject<List<Shape>>(elements.ToString(), new ShapeReader());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void exportToPdf_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();

            foreach (var shape in allShapes)
            {
                shape.DrawShapeForPdf(page.Graphics, doc.PageSettings.Width, doc.PageSettings.Height);
            }
            doc.Save("Shapes.pdf");
            doc.Close(true);
            System.Diagnostics.Process.Start("Shapes.pdf");
        }
    }
}
