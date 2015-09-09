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

            DirectoryInfo dirii = new DirectoryInfo(Context.GetString("PowerStone.Core.StonePath"));
            if (!dirii.Exists)
            {
                Console.WriteLine("PowerStone.Core.StonePath 属性不存在。");
                return;
            }
            DirectoryInfo diri = new DirectoryInfo(Context.GetString("PowerStone.Core.DesignPath"));
            if (!diri.Exists)
            {
                Console.WriteLine("PowerStone.Core.DesignPath 属性不存在。");
                return;
            }
            FileInfo[] fis = diri.GetFiles();
            foreach (FileInfo tfi in fis)
            {
                XmlDocument txmld = new XmlDocument();
                txmld.Load(tfi.FullName);
                XmlNodeList txmlnl = txmld.ChildNodes;
                foreach (XmlNode txmln in txmlnl)
                {
                    StoneDesign sd = DesignReader.Reader(txmln);
                    String id = sd.Id;
                    String mode = sd.Mode;
                    String dll = sd.Dll;
                    Type type = sd.Type;
                }
            }
            Type stoneType = Type.GetType("PowerStone.Book");
            Type factoryType = Type.GetType("PowerStone.Core.Factory." + "Singleton" + "Factory");
            IFactory factory = (IFactory)Activator.CreateInstance(factoryType, stoneType);
            Object bk = factory.Singleton().Stone;
            PropertyInfo[] properties = stoneType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(bk, property.Name);
                Console.WriteLine(property.GetValue(bk));
            }
        }
    }
}
