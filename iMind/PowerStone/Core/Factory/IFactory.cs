using System;
using PowerStone.Core.Product;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerStone.Core.Factory
{
    interface IFactory
    {
        // 获取Stone
        Object Stone { get; }

        // 新建
        XmlElement XmlDesign { set; }
    }
}
