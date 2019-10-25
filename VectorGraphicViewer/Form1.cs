using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                    shape.Show(g, canvas.Width, canvas.Height);
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
            Document doc = new Document(PageSize.A4.Rotate());

            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            
            using (var fileStream = new FileStream("shapes.pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();
                
                string allJson = File.ReadAllText("Shapes.json");

                Paragraph paragraph = new Paragraph(new Phrase(allJson, normalFont));
                paragraph.Alignment = Element.ALIGN_LEFT;
                doc.Add(paragraph);
                doc.Close();
                System.Diagnostics.Process.Start("shapes.pdf");
            }
        }
    }
}
