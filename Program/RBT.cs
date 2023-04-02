using ASID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASID
{
    // 1.Корень всегда черный.
    // 2.Каждый узел либо красный, либо черный.
    // 3.Каждый лист, не содержащий данные (фиктивный) — черный.
    // 4.Если узел красный, то оба его сына — черные.
    // 5.Все пути, идущие от корня к любому фиктивному листу,
    // содержат одинаковое количество черных узлов.

    class RBT<T>
    {
        public RBTnode<T> root;
        public RBTnode<T> TNULL; // обозначение фиктивного листа для узла без потомков
        public RBT() // создание корня => создание дерева
        {
            root = null;
        }

        public void LeftRotation(RBTnode<T> oldroot)
        {
            RBTnode<T> NewRoot = oldroot.Right;
            oldroot.Right = NewRoot.Left;
            if (NewRoot.Left != TNULL)
            {
                NewRoot.Left.Parent = oldroot;
            }
            NewRoot.Parent = oldroot.Parent;
            if (oldroot.Parent == null)
            {
                root = NewRoot;
            }
            else if (oldroot == oldroot.Parent.Left)
            {
                oldroot.Parent.Left = NewRoot;
            }
            else
            {
                oldroot.Parent.Right = NewRoot;
            }
            NewRoot.Left = oldroot;
            oldroot.Parent = NewRoot;
        }

        public void RightRotation(RBTnode<T> oldroot)
        {
            RBTnode<T> NewRoot = oldroot.Left;
            oldroot.Left = NewRoot.Right;
            if (NewRoot.Right != TNULL)
            {
                NewRoot.Right.Parent = oldroot;
            }
            NewRoot.Parent = oldroot.Parent;
            if (oldroot.Parent == null)
            {
                root = NewRoot;
            }
            else if (oldroot == oldroot.Parent.Right)
            {
                oldroot.Parent.Right = NewRoot;
            }
            else
            {
                oldroot.Parent.Left = NewRoot;
            }
            NewRoot.Right = oldroot;
            oldroot.Parent = NewRoot;
        }

        public void insert(int key, T value)
        {
            RBTnode<T> node = new RBTnode<T>(key, value);
            node.Left = TNULL;
            node.Right = TNULL;
            node.Color = ColorNode.Red;

            RBTnode<T> y = null;
            RBTnode<T> x = root;

            // пока не дошли до листьев (ищем место для вставки)
            while (x != TNULL)
            {
                y = x; // запоминаем родителя для добавляемого узла
                if (node.Key < x.Key)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }

            node.Parent = y; // назначаем родителя для добавляемого узла
            // если корень отсутствует
            if (y == null)
            {
                root = node;
            }
            // назначаем потомка
            else if (node.Key < y.Key)
            {
                y.Left = node;
            }
            else
            {
                y.Right = node;
            }

            // если у данного узла нет родителя => данный узел - корень
            if (node.Parent == null)
            {
                node.Color = ColorNode.Black;
                return;
            }
            // если у данного узла нет прародителя => отсутствует потомок прародителя в противоположоной стороне дерева (далее - дядя)
            // следовательно дерево не нуждается в балансировке
            if (node.Parent.Parent == null)
            {
                return;
            }

            insertFix(node);
        }
        
        // вставка с балансировкой дерева
        void insertFix(RBTnode<T> node)
        {
            RBTnode<T> uncle;
            while (node.Parent.Color == ColorNode.Red) // пока родитель нового узла красный
            {
                if (node.Parent == node.Parent.Parent.Right) // и если он является правым потомков
                {
                    uncle = node.Parent.Parent.Left; // определяем дядю для нового узла
                    if (uncle.Color == ColorNode.Red) // если дядя - красный
                    {
                        uncle.Color = ColorNode.Black; // красим дядю в черный
                        node.Parent.Color = ColorNode.Black; // красим родителя в черный
                        node.Parent.Parent.Color = ColorNode.Red; // а прародителя в красный
                        node = node.Parent.Parent; // переходим к прародителю
                    }
                    else // если дядя - черный
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RightRotation(node);
                        }
                        node.Parent.Color = ColorNode.Black;
                        node.Parent.Parent.Color = ColorNode.Red;
                        LeftRotation(node.Parent.Parent);
                    }
                }
                else // если он является левым потомков
                {
                    uncle = node.Parent.Parent.Right; // определяем дядю для нового узла

                    if (uncle.Color == ColorNode.Red) // если дядя - красный
                    {
                        uncle.Color = ColorNode.Black; // красим дядю в черный
                        node.Parent.Color = ColorNode.Black; // родителя нового узла в черный
                        node.Parent.Parent.Color = ColorNode.Red; // прародителя данного узла в красный
                        node = node.Parent.Parent; // переходим к прародителю
                    }
                    else // если дядя - черный
                    {
                        // и если узел является правым потомком
                        if (node == node.Parent.Right)
                        {
                            // выполянем сначала левый поворот для родителя текущего узла
                            node = node.Parent;
                            LeftRotation(node);
                        }
                        node.Parent.Color = ColorNode.Black; // красим родителя текущего узла в черный
                        node.Parent.Parent.Color = ColorNode.Red; // а прародителя в красный
                        RightRotation(node.Parent.Parent); // правый поворот относително прародителя
                    }
                }
                if (node == root) // если прародителем оказался корень => прерываем цикл
                {
                    break;
                }
            }
            root.Color = ColorNode.Black; // красим корень в черный (условие 1)
        }

        public void ViewOrder(RBTnode<T> tmp)
        {
            if (tmp != TNULL) // пока не дойдем до фиктивного листа
            {
                Console.WriteLine(tmp);
                if (tmp.Left != null) ViewOrder(tmp.Left);
                if (tmp.Right != null) ViewOrder(tmp.Right);
            }
        }
    }
}
