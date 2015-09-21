using PowerMind.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerMind.Control
{
    public class MindControl
    {
        public String MindName { get; set; }

        public PowerXml MindModel { get; set; }

        public MainForm MindForm { get; set; }

        private MindControl() { }

        public static MindControl LoadMind(String filePath)
        {
            MindControl mindControl = new MindControl();
            mindControl.MindModel = PowerXml.LoadPowerXml(filePath);
            mindControl.MindForm = new MainForm(mindControl);
            return mindControl;
        }

        public static MindControl CreateMind(String mindName)
        {
            MindControl mindControl = new MindControl();
            mindControl.MindModel = PowerXml.CreatePowerXml(mindName);
            mindControl.MindForm = new MainForm(mindControl);
            return mindControl;

        }

        public void AdjustMind()
        {
            XmlElement xmle = MindModel.RootElement;

            Point point = new Point(0, 0);
            Rectangle rectangle = Recursion_AdjustMindModel(xmle, point);
            Point dpoint = new Point(point.X - rectangle.X, point.Y - rectangle.Y);
            Recursion_MoveMindModel(xmle, dpoint);
            MindForm.Refresh();
        }

        private Rectangle Recursion_AdjustMindModel(XmlElement xmle, Point point)
        {
            // 本级区域
            Rectangle rect = new Rectangle(point, new Size(50 * xmle.GetAttribute("key").Length, 50));
            // 下一个子集的定位点
            Point nextChildPoint = new Point(rect.Right, rect.Top);

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    Rectangle childRect = Recursion_AdjustMindModel(txmle, nextChildPoint);
                    nextChildPoint.Offset(0, childRect.Top + childRect.Bottom - 2 * nextChildPoint.Y);
                }
                Rectangle firstChildRect = MindConvert.StringToRectangle(((XmlElement)xmle.FirstChild).GetAttribute("region"));
                Rectangle lastChildRect = MindConvert.StringToRectangle(((XmlElement)xmle.LastChild).GetAttribute("region"));
                rect.Offset(0, (lastChildRect.Top + firstChildRect.Top) / 2 - rect.Top);
            }

            xmle.SetAttribute("region", MindConvert.RectangleToString(rect));

            return rect;
        }

        private void Recursion_MoveMindModel(XmlElement xmle, Point dpoint)
        {
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            rectangle.Offset(dpoint);
            xmle.SetAttribute("region", MindConvert.RectangleToString(rectangle));
            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    Recursion_MoveMindModel(txmle, dpoint);
                }
            }
        }

        private void Recursion_ReverseMindModel(XmlElement xmle, int x)
        {
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Point dpoint = new Point(2 * x - rectangle.Left - rectangle.Right);
            rectangle.Offset(dpoint);
            xmle.SetAttribute("region", MindConvert.RectangleToString(rectangle));
            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    Recursion_ReverseMindModel(txmle, x);
                }
            }
        }
    }
}
