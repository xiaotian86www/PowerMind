using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Exception.Core
{
    class TypeNotFoundException : CoreException
    {
        public TypeNotFoundException() { }

        public TypeNotFoundException(String message)
            : base(message) { }

        public TypeNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
