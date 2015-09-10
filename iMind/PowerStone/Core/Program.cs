using PowerStone.Core.Design;
using PowerStone.Core.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerStone.Core
{
    class Program
    {
        static void Main(String[] args)
        {
            // 获取配置文件
            FileInfo fi = new FileInfo("PowerStone.xml");
            if (!fi.Exists)
            {
                Console.WriteLine("PowerStone.xml 配置文件不存在，PowerStone 框架退出。");
                return;
            }
            XmlDocument xmld = new XmlDocument();
            xmld.Load(fi.FullName);
            XmlNodeList xmlnl = xmld.ChildNodes;
            foreach (XmlNode txmln in xmlnl)
            {
                XmlElement xmle = txmln as XmlElement;
                String attrKey = xmle.GetAttribute("name");
                String attrValue = xmle.InnerText;
                Context.AddConfig(attrKey, attrValue);
            }

            // 获取Factory
            try
            {
                DirectoryInfo diri = new DirectoryInfo(Context.GetString("PowerStone.Core.DesignPath"));
                FileInfo[] fis = diri.GetFiles();
                foreach (FileInfo tfi in fis)
                {
                    XmlDocument txmld = new XmlDocument();
                    txmld.Load(tfi.FullName);
                    XmlNodeList txmlnl = txmld.ChildNodes;
                    foreach (XmlNode txmln in txmlnl)
                    {
                        StoneDesign sd = DesignReader.Reader(txmln);

                        String type = "PowerStone.Core.Factory." + sd.Mode.Substring(0, 1).ToUpper() + sd.Mode.Substring(0, sd.Mode.Length - 1).ToLower() + "Factory";
                        Type factoryType = Type.GetType(type);
                        IFactory factory = (IFactory)Activator.CreateInstance(factoryType);
                        Context.AddFactory(sd.Id, factory);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
