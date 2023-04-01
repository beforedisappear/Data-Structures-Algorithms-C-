using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class AVLnode<T>
    {
        public int Key;
        public T Value;
        public AVLnode<T> Right;
        public AVLnode<T> Left;

        public AVLnode(int k, T v) // констуктор для создания узла
        {
            Key = k;
            Value = v;
            Left = null;
            Right = null;
        }
        public AVLnode() // пустой конструктор
        {
            Key = int.MaxValue;
            Value = default(T);
            Left = null;
            Right = null;
        }
        public override string ToString()
        {
            string ret = string.Format("TreeNode : (Key = {0},Value = {1})", Key, Value);
            if (Left != null) ret = ret + string.Format(" LeftKey = {0};", Left.Key);
            if (Right != null) ret = ret + string.Format(" RightKey = {0}", Right.Key);
            return ret;
        }
    }
}
