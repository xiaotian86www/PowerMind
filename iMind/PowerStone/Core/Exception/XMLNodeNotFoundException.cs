using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Exception
{
    class XMLNodeNotFoundException : CoreException
    {
        public XMLNodeNotFoundException() { }

        public XMLNodeNotFoundException(String message)
            : base(message) { }

        public XMLNodeNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
