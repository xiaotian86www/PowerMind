using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Product
{
    class StoneProduct
    {
        // 原石
        public Object Stone { get; set; }

        public Dictionary<String, MethodInfo> methods = new Dictionary<string,MethodInfo>();

        public void ThreadMain()
        {
            MethodInfo method = methods["threadMain"];
            method.Invoke(Stone, null);
        }
    }
}
