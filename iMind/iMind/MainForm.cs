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

namespace PowerMind
{
    public partial class MainForm : Form
    {
        private String xmlMindName;

        private XmlDocument xmlMind;

        private Context context;

        public MainForm(String xmlMindName)
        {
            this.xmlMindName = xmlMindName;
            context = Context.GetContext();
            xmlMind = context.GetXmlMind(xmlMindName);
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Context con = Context.GetContext();
            Recursion_Paint(xmlMind.DocumentElement, e);
        }

        private void Recursion_Paint(XmlElement xe, PaintEventArgs e)
        {
            MessageBox.Show("name:" + xe.Name + " key:" + xe.GetAttribute("key"));

            if (xe.HasChildNodes)
                foreach (XmlElement txe in xe.ChildNodes)
                {
                    Recursion_Paint(txe, e);
                }
        }
    }
}
