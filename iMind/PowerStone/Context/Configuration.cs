using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Context
{
    class Configuration
    {
        private static Hashtable cf = new Hashtable();

        public void Add(String key, String value)
        {
            cf.Add(key, value);
        }

        public int GetInteger(String key)
        {
            return Convert.ToInt32(cf[key]);
        }

        public String GetString(String key)
        {
            return cf[key] as String;
        }
    }
}
