using PowerMind.Control;
//using PowerMind.Model;
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
        private PowerXml MindModel { get; set; }

        public String MindName { get; set; }

        //private Context context;

        public MainForm(PowerXml xmlMind)
        {
            InitializeComponent();
            this.MindModel = xmlMind;
            this.Text = MindModel.FileName;
            this.MindName = MindModel.FileName;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Context context = Context.GetContext();
            Graphics graphics = e.Graphics;
            XmlElement root = MindModel.RootElement;
            context.AdjustMind(MindName);
            Recursion_Paint_Right(root, graphics);
        }

        private void Recursion_Paint_Right(XmlElement xmle, Graphics graphics)
        {
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Point point = rectangle.Location;
            graphics.DrawString(xmle.GetAttribute("key"), new Font("Verdana", 20), new SolidBrush(Color.Tomato), point);

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txe in xmle.ChildNodes)
                {
                    Recursion_Paint_Right(txe, graphics);
                }
            }
        }
    }
}
