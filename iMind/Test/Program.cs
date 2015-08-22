using Comm.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly asse = Assembly.Load("BiTree");
                Type type = asse.GetType("Comm.Tree.BiTree`1[[" + typeof(String).AssemblyQualifiedName + "]]");

                Type[] types = type.GetInterfaces();
                foreach (Type ttype in types)
                {
                    Console.WriteLine(ttype.FullName);
                }

                ITree<String> obj = (ITree<String>)Activator.CreateInstance(type);
                //MethodInfo[] methods = obj.GetType().GetMethods();
                //foreach (MethodInfo method in  methods)
                //{
                //    Console.WriteLine(method.Name);
                //}

                obj.Data = "123";
                Console.WriteLine(obj.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
