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
            try
            {
                // 获取配置文件
                FileInfo fi = new FileInfo(configPath);
                if (!fi.Exists)
                {
                    Console.WriteLine(configPath + "配置文件不存在，PowerStone 框架退出。");
                    return;
                }
                XmlDocument xmld = new XmlDocument();
                xmld.Load(fi.FullName);
                foreach (XmlElement xmle in xmld.DocumentElement.ChildNodes)
                {
                    String attrKey = xmle.GetAttribute("key");
                    String attrValue = xmle.InnerText;
                    Context.AddConfig(attrKey, attrValue);
                }

                // 获取Factory
                DirectoryInfo diri = new DirectoryInfo(Context.GetString("PowerStone.Core.DesignPath"));
                FileInfo[] fis = diri.GetFiles();
                foreach (FileInfo tfi in fis)
                {
                    XmlDocument txmld = new XmlDocument();
                    txmld.Load(tfi.FullName);
                    foreach (XmlElement txmle in txmld.DocumentElement.ChildNodes)
                    {
                        String id = txmle.GetAttribute("id");
                        String mode = txmle.GetAttribute("mode");
                        String type = "PowerStone.Core.Factory." + mode.Substring(0, 1).ToUpper() + mode.Substring(1, mode.Length - 1).ToLower() + "Factory";
                        Type factoryType = Type.GetType(type);
                        IFactory factory = (IFactory)Activator.CreateInstance(factoryType);
                        factory.XmlDesign = txmle;
                        ct.Add(id, factory);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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

        public static Object GetStone(String id)
        {
            IFactory fac = ct[id] as IFactory;
            if (null == fac)
                throw new StoneNotFoundException("id:" + id + " 没有找到。");
            return ((IFactory)ct[id]).Stone;
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
