using PowerMind.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PowerMind.Control
{
    public class MindControl
    {
        public String MindName { get; set; }

        public PowerXml MindModel { get; set; }

        public MainForm MindForm { get; set; }

        public MindControl(String filePath)
        {
            this.MindModel = PowerXml.LoadPowerXml(filePath);
            this.MindForm = new MainForm(this.MindModel.RootElement);

            //AdjustMind();
            //MindModel.Save();
        }
        
        /// <summary>
        /// 调整MindModel中各Mind的位置
        /// </summary>
        public void AdjustMind()
        {
            XmlElement xmle = MindModel.RootElement;

            Point point = new Point(0, 0);
            Recursion_AdjustMindModel(xmle, point);
            Rectangle rectangle = MindConvert.StringToRectangle(xmle.GetAttribute("region"));
            Point dpoint = new Point(point.X - rectangle.X, point.Y - rectangle.Y);
            Recursion_MoveMindModel(xmle, dpoint);
            MindForm.Refresh();
        }

        /// <summary>
        /// 递归函数，根据规则依次调整每个Mind位置
        /// </summary>
        /// <param name="xmle">当前节点</param>
        /// <param name="point">当前节点位置</param>
        /// <returns>调整后当前节点大小和位置</returns>
        private Point Recursion_AdjustMindModel(XmlElement xmle, Point point)
        {
            // 本级区域
            Rectangle rect = new Rectangle(point, new Size(20 * xmle.GetAttribute("key").Length, 20));
            // 下一个子集定位点
            Point nextChildPoint = new Point(rect.Right, rect.Top);
            // 下一个本级定位点
            Point nextPoint = new Point(rect.Left, rect.Bottom);

            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    nextChildPoint = Recursion_AdjustMindModel(txmle, nextChildPoint);
                    nextPoint.Y = nextChildPoint.Y;
                }
                Rectangle firstChildRect = MindConvert.StringToRectangle(((XmlElement)xmle.FirstChild).GetAttribute("region"));
                Rectangle lastChildRect = MindConvert.StringToRectangle(((XmlElement)xmle.LastChild).GetAttribute("region"));
                rect.Offset(0, (lastChildRect.Top + firstChildRect.Top) / 2 - rect.Top);
            }

            xmle.SetAttribute("region", MindConvert.RectangleToString(rect));

            return nextPoint;
        }

        /// <summary>
        /// 递归函数，用于移动Mind位置
        /// </summary>
        /// <param name="xmle">需要调整的节点</param>
        /// <param name="dpoint">移动的方向和长度</param>
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

        /// <summary>
        /// 递归函数，用于水平翻转Mind
        /// </summary>
        /// <param name="xmle"></param>
        /// <param name="x"></param>
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
