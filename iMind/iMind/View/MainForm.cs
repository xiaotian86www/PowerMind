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
        private bool isMouseLeftDown = false;

        private Point mouseDownPoint = new Point();

        private XmlElement mindElement;

        public MainForm(XmlElement xmle)
        {
            InitializeComponent();
            mindElement = xmle;
            Text = xmle.GetAttribute("key");
            Recursion_CreateMindBox(xmle);
        }

        private void Recursion_CreateMindBox(XmlElement xmle)
        {
            this.Controls.Add(new MindBox(xmle));

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    Recursion_CreateMindBox(txmle);
                }
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                isMouseLeftDown = true;
                mouseDownPoint = e.Location;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftDown)
            {
                foreach (MindBox mindBox in Controls)
                {
                    Point point = mindBox.Location;
                    point.Offset(e.X - mouseDownPoint.X, e.Y - mouseDownPoint.Y);
                    mindBox.Location = point;
                }
                mouseDownPoint = e.Location;
                //Refresh();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                isMouseLeftDown = false;
                mouseDownPoint = new Point(0, 0);
            }
        }


    }
}
