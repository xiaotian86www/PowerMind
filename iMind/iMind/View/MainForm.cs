using PowerMind.Control;
using PowerMind.Model;
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
        private PowerXml XmlMind { get; set; }

        //private Context context;

        public MainForm(PowerXml xmlMind)
        {
            InitializeComponent();
            this.XmlMind = xmlMind;
            this.Text = XmlMind.FileName;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //MessageBox.Show("Height:" + e.ClipRectangle.Height + " Width:" + e.ClipRectangle.Width);
            Context con = Context.GetContext();
            Graphics gra = e.Graphics;
            Recursion_Paint_Right(XmlMind.DocumentElement, gra, new Point(0, 0));
        }

        private void Recursion_Paint_Right(XmlElement xe, Graphics gra, Point point)
        {
            gra.DrawString(xe.GetAttribute("key"), new Font("Verdana", 20), new SolidBrush(Color.Tomato), point);

            if (xe.HasChildNodes)
            {
                int count = xe.ChildNodes.Count;
                int index = 0;
                foreach (XmlElement txe in xe.ChildNodes)
                {
                    Recursion_Paint_Right(txe, gra, new Point(point.X + 100, point.Y + 50 * index));
                    index++;
                }
            }
        }
    }
}
