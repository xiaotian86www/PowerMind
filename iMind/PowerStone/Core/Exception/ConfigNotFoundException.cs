using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Exception
{
    class ConfigNotFoundException : CoreException
    {
        public ConfigNotFoundException() { }

        public ConfigNotFoundException(String message)
            : base(message) { }

        public ConfigNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
