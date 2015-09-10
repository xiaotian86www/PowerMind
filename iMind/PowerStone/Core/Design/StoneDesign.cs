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
        public String Id { get; set; }

        // 属性
        public Dictionary<String, String> Attributes { get; set; }

        // 类类型
        public String Type { get; set; }

        // 实例化模式
        public String Mode { get; set; }

        // dll文件名
        public String Dll { get; set; }

        // 线程数量
        public int Num { get; set; }
    }
}
