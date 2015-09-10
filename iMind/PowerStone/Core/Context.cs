using PowerStone.Core.Design;
using PowerStone.Core.Exception;
using PowerStone.Core.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerStone.Core
{
    public static class Context
    {
        private static Hashtable cf = new Hashtable();

        private static Hashtable ct = new Hashtable();

        public static void ParseXml(String configPath)
        {
            // 获取配置文件
            FileInfo fi = new FileInfo(configPath);
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

        public static void AddConfig(String key, String value)
        {
            cf.Add(key, value);
        }

        public static int GetInteger(String key)
        {
            if (!cf.Contains(key))
                throw new ConfigNotFoundException("config:" + key + "未找到");
            return Convert.ToInt32(cf[key]);
        }

        public static String GetString(String key)
        {
            return cf[key] as String;
        }

        public static void AddFactory(String id, IFactory factory)
        {
            ct.Add(id, factory);
        }

        public static IFactory GetFactory(String id)
        {
            return ct[id] as IFactory;
        }

        public static void RemoveFactory(String id)
        {
            if (ct.Contains(id))
            {
                ct.Remove(id);
            }
        }

        public static void ClearFactory()
        {
            ct.Clear();
        }
    }
}
