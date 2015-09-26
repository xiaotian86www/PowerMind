using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PowerMind.Control;

namespace PowerMind.View
{
    public partial class MindBox : UserControl
    {
        private XmlElement mindModel;

        public MindBox(XmlElement xmle)
        {
            InitializeComponent();

            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Location = rectangle.Location;
            Size = rectangle.Size;
            mindModel = xmle;
            Text = xmle.GetAttribute("key");
        }

        private void MindBox_Paint(object sender, PaintEventArgs e)
        {
            SizeF textSize = TextRenderer.MeasureText(Text, Font);
            SolidBrush brush = new SolidBrush(ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(Text, Font, brush, Width / 2, (Height - textSize.Height) / 2, sf);
        }
    }
}
