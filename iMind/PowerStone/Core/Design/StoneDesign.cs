using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Design
{
    class StoneDesign
    {
        // 全局id
        String Id { get; set; }

        // 属性
        Dictionary<String, Object> Attributes { get; set; }

        // 类类型
        Type Class { get; set; }

        // 实例化类型
        String Type { get; set; }
    }
}
