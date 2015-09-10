using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Exception
{
    class StoneNotFoundException : CoreException
    {
        public StoneNotFoundException() { }

        public StoneNotFoundException(String message)
            : base(message) { }

        public StoneNotFoundException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
