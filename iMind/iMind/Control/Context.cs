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
    static class Context
    {
        private static Dictionary<String, MindControl> mindControls = new Dictionary<String, MindControl>();

        public static void InitContext(String[] names)
        {
            // 加载mind
            if (0 == names.Length)
            {
                mindControls.Add("newMind", MindControl.CreateMind("newMind"));
            }
            else
            {
                foreach (String name in names)
                {
                    mindControls.Add(name, MindControl.LoadMind(name));
                }
            }

            // 创建视图
            foreach (String mindName in mindControls.Keys)
            {
                Application.Run(mindControls[mindName].MindForm);
            }
        }

        public static MindControl GetMindControl(String name)
        {
            return mindControls[name];
        }
    }
}
