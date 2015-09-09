using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Exception
{
    class XMLAttributeNotFoundException : CoreException
    {
        public XMLAttributeNotFoundException() { }

        public XMLAttributeNotFoundException(String message)
            : base(message) { }

        public XMLAttributeNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
