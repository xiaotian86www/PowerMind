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
        private MindControl MindControl { get; set; }

        //private Context context;

        public MainForm(MindControl mindControl)
        {
            InitializeComponent();
            this.Text = mindControl.MindName;
            this.MindControl = mindControl;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            XmlElement root = MindControl.MindModel.RootElement;
            Recursion_Paint(root, graphics, new Point(100, 100));
        }

        private void Recursion_Paint(XmlElement xmle, Graphics graphics, Point dpoint)
        {
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Point point = rectangle.Location;
            point.Offset(dpoint);
            graphics.DrawString(xmle.GetAttribute("key"), new Font("Verdana", 20), new SolidBrush(Color.Tomato), point);

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txe in xmle.ChildNodes)
                {
                    Recursion_Paint(txe, graphics, dpoint);
                }
            }
        }
    }
}
