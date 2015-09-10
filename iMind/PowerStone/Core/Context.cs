using PowerStone.Core.Exception;
using PowerStone.Core.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core
{
    class Context
    {
        private static Hashtable cf = new Hashtable();

        private static Hashtable ct = new Hashtable();

        private Context() { }

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
