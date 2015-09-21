using PowerMind.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PowerMind.View
{
    public partial class MainForm : Form
    {
        private Point OriginalPoint { get; set; }

        public MainForm(String mindName)
        {
            InitializeComponent();
            this.Text = mindName;
        }
        public void Recursion_Paint(XmlElement xmle, Graphics graphics)
        {
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Point point = rectangle.Location;
            point.Offset(OriginalPoint);
            PaintMind(xmle.GetAttribute("key"), point, graphics);

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    Recursion_Paint(txmle, graphics);
                }
            }
        }

        private void PaintMind(String str, Point point, Graphics graphics)
        {
            graphics.DrawString(str, new Font("Verdana", 20), new SolidBrush(Color.Tomato), point);
        }
    }
}
