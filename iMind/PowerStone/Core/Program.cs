using PowerStone.Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core
{
    class Program
    {
        static void Main(String[] args)
        {
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
