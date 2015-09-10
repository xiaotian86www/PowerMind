using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Exception
{
    class CannotCreateProductException : CoreException
    {
        public CannotCreateProductException() { }

        public CannotCreateProductException(String message)
            : base(message) { }

        public CannotCreateProductException(String message, System.Exception inner)
            : base(message, inner) { }
    }
}
