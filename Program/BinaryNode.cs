using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class BinaryNode<T>
    {
        public int Key;
        public T Value;
        public int Height;
        public BinaryNode<T> Parent;
        public BinaryNode<T> Right;
        public BinaryNode<T> Left;

        public BinaryNode(int k, T v) // констуктор для создания узла
        {
            Key = k;
            Value = v;
            Parent = null;
            Left = null;
            Right = null;
        }
        public BinaryNode() // пустой конструктор
        {
            Key = int.MaxValue;
            Value = default(T);
            Parent = null;
            Left= null;
            Right= null;
        }
        public override string ToString()
        {
            string ret = string.Format("TreeNode : (Key = {0},Value = {1})", Key, Value);
            if (Parent != null) ret = ret + string.Format(" ParentKey = {0};", Parent.Key);
            if (Left != null) ret = ret + string.Format(" LeftKey = {0};", Left.Key);
            if (Right != null) ret = ret + string.Format(" RightKey = {0}", Right.Key);
            return ret;
        }
    }
}