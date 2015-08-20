using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Context.Base.Interface
{
    interface ITree<T> : IEnumerable<ITree<T>>
    {
        // text读写属性
        T Content
        {
            get;
            set;
        }

        // 插入子节点
        void InsertChild(ITree<T> child);

        // 删除子节点
        void DeleteChild(ITree<T> child);

        // 获取父节点
        ITree<T> GetParent();

        // 获取子节点
        List<ITree<T>> GetChildren();
    }
}
