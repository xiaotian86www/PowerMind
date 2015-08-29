using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Exception.Core
{
    class AttributeNotFoundException : CoreException
    {
        public AttributeNotFoundException() { }

        public AttributeNotFoundException(String message)
            : base(message) { }

        public AttributeNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
