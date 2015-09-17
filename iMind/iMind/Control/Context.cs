using PowerMind.Model;
using PowerMind.View;
using System;
using System.Collections.Generic;
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
            xmle.SetAttribute("height", Recursion_AdjustMindModel(xmle).ToString());
        }

        private int Recursion_AdjustMindModel(XmlElement xmle)
        {
            int height = 0;
            if (xmle.HasChildNodes)
            {
                foreach (XmlElement txmle in xmle.ChildNodes)
                {
                    height += Recursion_AdjustMindModel(txmle);
                }
            }
            else
                height = 50;

            xmle.SetAttribute("height", height.ToString());

            return height;
        }
    }
}
