using System;
using PowerStone.Core.Product;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PowerStone.Core.Design;

namespace PowerStone.Core.Factory
{
    interface IFactory
    {
        // 获取Stone
        Object Stone { get; }

        // 新建
        StoneDesign Design { set; }
    }
}
