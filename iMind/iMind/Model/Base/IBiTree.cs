using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model.Base
{
    interface IBiTree<T> : IEnumerable<IBiTree<T>>
    {
        // text读写属性
        T Content
        {
            get;
            set;
        }

        // 插入子节点
        void InsertChild(IBiTree<T> child);

        // 删除子节点
        void DeleteChild(IBiTree<T> child);

        // 获取父节点
        IBiTree<T> GetParent();

        // 获取子节点
        List<IBiTree<T>> GetChildren();
    }
}
