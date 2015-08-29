using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Exception.Core
{
    class CoreException : ApplicationException
    {
        public CoreException() { }

        public CoreException(String message)
            : base(message) { }

        public CoreException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
