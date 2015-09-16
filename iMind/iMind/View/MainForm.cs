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
            Context con = Context.GetContext();
            Recursion_Paint(XmlMind.DocumentElement, e);
        }

        private void Recursion_Paint(XmlElement xe, PaintEventArgs e)
        {
            if (xe.HasChildNodes)
                foreach (XmlElement txe in xe.ChildNodes)
                {
                    Recursion_Paint(txe, e);
                }
        }
    }
}
