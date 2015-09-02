using PowerStone.Core.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Context
{
    class FactoryContainer
    {
        private static Hashtable ct = new Hashtable();

        public void Add(String id, IFactory factory)
        {
            ct.Add(id, factory);
        }

        public IFactory Get(String id)
        {
            return ct[id] as IFactory;
        }

        public void  Remove(String id)
        {
            if (ct.Contains(id))
            {
                ct.Remove(id);
            }
        }

        public void Clear()
        {
            ct.Clear();
        }
    }
}
