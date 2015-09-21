using PowerMind.Control;
using PowerMind.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace PowerMind.Control
{
    class Context
    {
        private static Context context = new Context();

        private Dictionary<String, PowerXml> mindModels = new Dictionary<string, PowerXml>();

        private Dictionary<String, MainForm> mindForms = new Dictionary<string, MainForm>();

        private Context() { }

        public void InitContext(String[] names)
        {
            // 加载mind
            if (0 == names.Length)
            {
                context.AddMind("newMind");
            }
            else
            {
                foreach (String name in names)
                {
                    context.LoadMind(name);
                }
            }

            // 创建视图
            foreach (String mindName in mindForms.Keys)
            {
                Application.Run(mindForms[mindName]);
            }
        }

        public static Context GetContext()
        {
            return context;
        }

        public PowerXml GetMindModel(String name)
        {
            return mindModels[name];
        }

        public void LoadMind(String filePath)
        {
            PowerXml mindModel = PowerXml.LoadPowerXml(filePath);
            mindModels.Add(mindModel.FileName, mindModel);
            mindForms.Add(mindModel.FileName, new MainForm(mindModel));
        }

        public void AddMind(String mindName)
        {
            PowerXml mindModel = PowerXml.CreatePowerXml(mindName);
            mindModels.Add(mindName, mindModel);
            mindForms.Add(mindName, new MainForm(mindModel));
        }

        public void AdjustMind(String mindName)
        {
            PowerXml mindModel = mindModels[mindName];
            XmlElement xmle = mindModel.RootElement;

            Point point = new Point(0, 0);
            Recursion_AdjustMindModel(xmle, point);
            mindModel.Save();
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
    }
}
