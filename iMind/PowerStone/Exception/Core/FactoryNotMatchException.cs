using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Exception.Core
{
    class FactoryNotMatchException : CoreException
    {
        public FactoryNotMatchException() { }

        public FactoryNotMatchException(String message)
            : base(message) { }

        public FactoryNotMatchException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
