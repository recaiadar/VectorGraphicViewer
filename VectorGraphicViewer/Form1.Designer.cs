namespace VectorGraphicViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.Panel();
            this.btnLoadFromXml = new System.Windows.Forms.Button();
            this.exportToPdf = new System.Windows.Forms.Button();
            this.canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Controls.Add(this.exportToPdf);
            this.canvas.Controls.Add(this.btnLoadFromXml);
            this.canvas.Location = new System.Drawing.Point(0, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(778, 452);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // btnLoadFromXml
            // 
            this.btnLoadFromXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFromXml.Location = new System.Drawing.Point(615, 371);
            this.btnLoadFromXml.Name = "btnLoadFromXml";
            this.btnLoadFromXml.Size = new System.Drawing.Size(134, 65);
            this.btnLoadFromXml.TabIndex = 0;
            this.btnLoadFromXml.Text = "LoadFromXmlFile";
            this.btnLoadFromXml.UseVisualStyleBackColor = true;
            this.btnLoadFromXml.Click += new System.EventHandler(this.btnLoadFromXml_Click);
            // 
            // exportToPdf
            // 
            this.exportToPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportToPdf.Location = new System.Drawing.Point(13, 371);
            this.exportToPdf.Name = "exportToPdf";
            this.exportToPdf.Size = new System.Drawing.Size(141, 65);
            this.exportToPdf.TabIndex = 1;
            this.exportToPdf.Text = "Export To Pdf";
            this.exportToPdf.UseVisualStyleBackColor = true;
            this.exportToPdf.Click += new System.EventHandler(this.exportToPdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.canvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button btnLoadFromXml;
        private System.Windows.Forms.Button exportToPdf;
    }
}

