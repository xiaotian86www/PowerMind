using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Design
{
    interface IDesign
    {
        Dictionary<String, Object> Attributes { get; set; }

        Type Type { get; set; }
    }
}
