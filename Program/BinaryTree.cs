using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class BinaryTree<T>
    {
        public BinaryNode<T> root;  // корень дерева
        public BinaryTree() // создание корня => создание дерева
        {
            root = null;
        }
        public void AddNodeInThree(int k, T v)  // добавление узла
        {
            if (root == null) // передача данных корню
            {
                root = new BinaryNode<T>(k, v);
                return;
            }
            BinaryNode<T> tmp = root;
            while (tmp != null)
            {
                if (tmp.Key == k) return; // обработка исключения при совпадении с ключем корня
                if (tmp.Key > k) // ключ корня больше => тогда идем влево
                {
                    if (tmp.Left != null) tmp = tmp.Left;
                    else
                    {
                        BinaryNode<T> newNode = new BinaryNode<T>(k, v);
                        newNode.Parent = tmp; // объявление родителя для узла
                        tmp.Left = newNode; // объявление потомка для родителя
                        return;
                    }
                }
                if (tmp.Key < k) // ключ корня меньше => тогда идем вправо
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                    }
                    else
                    {
                        BinaryNode<T> newNode = new BinaryNode<T>(k, v);
                        newNode.Parent = tmp; // объявление родителя для узла
                        tmp.Right = newNode; // объявление потомка для родителя
                        return;
                    }
                }
            }
        }
        public BinaryNode<T> Search(int k) // поиск узла
        {
            if (root == null)
            {
                return null;
            }
            BinaryNode<T> tmp = root;
            while (tmp != null)
            {
                if (tmp.Key == k) return tmp;
                if (tmp.Key > k) //значит идем влево
                {
                    if (tmp.Left != null) tmp = tmp.Left;
                }

                if (tmp.Key < k) //значит идем вправо
                {
                    if (tmp.Right != null) tmp = tmp.Right;
                }
            }
            return null;
        }
        public bool DeleteNode(int key) // удаление узла
        {
            BinaryNode<T> findnode = Search(key);
            if (findnode == null) { return false; }

            // если у узла нет потомков, можно его удалить
            if (findnode.Left == null && findnode.Right == null)
            {
                if (findnode == root) { root = null; return true; }
                if (findnode.Parent.Right == findnode) { findnode.Parent.Right = null; return true; }
                if (findnode.Parent.Left == findnode) { findnode.Parent.Left = null; return true; }

            }

            // если у удаляемого узла один потомок - либо справа, либо слева
            if (findnode.Left == null || findnode.Right == null)
            {
                if (findnode == root)   // проверка на корень
                {
                    if (root.Left != null) { root = root.Left; }
                    if (root.Right != null) { root = root.Right; }
                    return true;
                }
                BinaryNode<T> p = findnode.Parent;
                if (findnode.Left == null) // если потомок справа
                {
                    if (p.Left == findnode) { p.Left = findnode.Right; return true; }
                    else { p.Right = findnode.Right; }

                    findnode.Right.Parent = p;
                }
                else // если потомок слева
                {
                    if (p.Left == findnode) { p.Left = findnode.Left; return true; }
                    else { p.Right = findnode.Left; }

                    findnode.Left.Parent = p;
                }
            }
            // если у удаляемого узла два потомка
            if (findnode.Left != null && findnode.Right != null)
            {
                BinaryNode<T> child = MinNode(findnode.Right); // минимальный потомок у Right, узел на который будем менять

                findnode.Key = child.Key; // меняем ключи, т.е. ключ удаляемого узла становися ключом потомка
                findnode.Value = child.Value; // меняем значения, т.е. значения удаляемого узла становися ключом потомка
                if (child.Parent.Left == child) // удаление заменяющего узла на его исходном месте ( для правой части дерева )
                {
                    child.Parent.Left = child.Right;
                    if (child.Right != null) { child.Right.Parent = child.Parent; return true; } // если у удаляемого узла есть потомок справа
                    return true;
                }
                else child.Parent.Right = child.Right; // ( для левой части дерева )

                if (child.Right != null) { child.Right.Parent = child.Parent; return true; } // если у удаляемого узла есть потомок справа
            }
            return false;
        }
        public BinaryNode<T> MinNode(BinaryNode<T> tmp) // min узел от указанной выршины (находится в левой части дерева)
        {
            while (tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }
        public BinaryNode<T> MaxNode(BinaryNode<T> tmp) // max узел от указанной выршины (находится в правой части дерева)
        {
            while (tmp.Right != null)
            {
                tmp = tmp.Right;
            }
            return tmp;
        }
        public void ViewAscending(BinaryNode<T> tmp) // вывод бинарного дерева по возрастанию 
        {
            if (tmp != null)
            {
                if (tmp.Left != null) ViewAscending(tmp.Left); // пока не дойдем до листьев, просматриваем левые узлы
                Console.WriteLine(tmp);
                if (tmp.Right != null) ViewAscending(tmp.Right); // пока не дойдем до листьев, просматриваем правые узлы
            }
        }
        public void ViewDescending(BinaryNode<T> tmp) // вывод бинарного дерева по убыванию 
        {
            if (tmp != null)
            {
                if (tmp.Right != null) ViewDescending(tmp.Right); // пока не дойдем до листьев, просматриваем правые узлы
                Console.WriteLine(tmp);
                if (tmp.Left != null) ViewDescending(tmp.Left); // пока не дойдем до листьев, просматриваем левые узлы
            }
        }
        public void ViewOrder(BinaryNode<T> tmp) // вывод бинарного дерева (обход в прямом порядке)
        {
            if (tmp != null)
            {
                Console.WriteLine(tmp);
                if (tmp.Left != null) ViewOrder(tmp.Left);
                if (tmp.Right != null) ViewOrder(tmp.Right);
            }
        }
    }
}