using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASID
{
    class AVLTree<T>
    {
        public BinaryNode<T> root;  // корень дерева
        public AVLTree() // создание корня => создание дерева
        {
            root = null;
        }

        public static int getSubTreeHeight(BinaryNode<T> node)
        {
            int height = 0;
            if (node != null)
            {
                int l = getSubTreeHeight(node.Left); // высота левого поддерва данного узла
                int r = getSubTreeHeight(node.Right); // высота правого поддерва данного узла
                // условие выхода из рекурсии нахождение листа (2 потомка null)
                int m = l > r ? l : r; // m принимает значение длины самого высокого поддерева
                height = m + 1; // при обнаружении листа увеличиваем высоту на 1 и возвращаемся в род. вершину
            }
            return height; // высота поддерева
        }

        public static int bfactor(BinaryNode<T> node)
        {
            return getSubTreeHeight(node.Right) - getSubTreeHeight(node.Left);
        }

        public void fix_heigt(BinaryNode<T> node)
        {
            int h_left = getSubTreeHeight(node.Left);
            int h_right = getSubTreeHeight(node.Right);

            node.Height = (h_left > h_right ? h_left : h_right) + 1;
        }

        public BinaryNode<T> LeftRotation(BinaryNode<T> node)
        {
            BinaryNode<T> NewRoot = node.Right;
            // условие для установления ссылки на потомка у родителя нового корня поддерева
            // обработка случая
            // было : Parent <-> oldRoot
            // стало : Parent <- NewRoot
            if (NewRoot.Parent != root)
            {
                // записываем родителя бывшего корня
                BinaryNode<T> pnode = node.Parent;
                // назначаем его родителем нового корня
                NewRoot.Parent = pnode;
                // проверяем, каким потомком будет новый корень поддерева (правым или левым)
                if (NewRoot.Key < pnode.Key) pnode.Left = NewRoot;
                else if (NewRoot.Key > pnode.Key) pnode.Right = NewRoot;
            }
            // у родителя нового корня дерева
            else
            {
                NewRoot.Parent = null;
            }
            node.Parent = NewRoot;

            node.Right = NewRoot.Left;
            if (NewRoot.Left != null) NewRoot.Left.Parent = node;
            NewRoot.Left = node;

            return NewRoot;
        }

        public BinaryNode<T> RightRotation(BinaryNode<T> node)
        {
            BinaryNode<T> NewRoot = node.Left;
            // условие для установления ссылки на потомка у родителя нового корня поддерева
            if (NewRoot.Parent != root)
            {
                BinaryNode<T> pnode = node.Parent;
                NewRoot.Parent = pnode;
                if (NewRoot.Key < pnode.Key) pnode.Left = NewRoot;
                else if (NewRoot.Key > pnode.Key) pnode.Right = NewRoot;
            }
            // у родителя нового корня дерева
            else
            {
                NewRoot.Parent = null;
            }
            node.Parent = NewRoot;

            node.Left = NewRoot.Right;
            if (NewRoot.Right != null) NewRoot.Right.Parent = node;
            NewRoot.Right = node;

            return NewRoot;
        }

        public BinaryNode<T> BigLeftRotation(BinaryNode<T> node) // Right and Left
        {
            RightRotation(node.Right);
            BinaryNode<T> NewRoot = LeftRotation(node);

            return NewRoot;
        }

        public BinaryNode<T> BigRightRotation(BinaryNode<T> node) // Left and Right
        {
            LeftRotation(node.Left);
            BinaryNode<T> NewRoot = RightRotation(node);

            return NewRoot;
        }

        public BinaryNode<T> balance(BinaryNode<T> node)
        {
            int balance_factor = bfactor(node);

            if (balance_factor > 1)
            {
                if (bfactor(node.Right) < 0) node = BigLeftRotation(node);
                else node = LeftRotation(node);

            }
            else if (balance_factor < -1)
            {
                if (bfactor(node.Left) > 0) node = BigRightRotation(node);
                else node = RightRotation(node);
            }
            return node;
        }

        // обычное добавление для визуализации работы поворотов
        public void AddNode(int k, T v)
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
                        //newNode.Height = tmp.Height + 1;
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
                        //newNode.Height = tmp.Height + 1;
                        return;
                    }
                }
            }
        }
        public bool Consists(int k) // поиск узла
        {
            if (root == null)
            {
                return false;
            }
            BinaryNode<T> tmp = root;
            while (tmp != null)
            {
                if (tmp.Key == k) return true;
                if (tmp.Key > k) //значит идем влево
                {
                    if (tmp.Left != null) tmp = tmp.Left;
                    else break;
                }

                if (tmp.Key < k) //значит идем вправо
                {
                    if (tmp.Right != null) tmp = tmp.Right;
                    else break;
                }
            }
            return false;
        }

        public void AddNodeInAVLtree(int k, T v)  // добавление узла в АВЛ дерево
        {
            if (Consists(k) == true) { return; }
            BinaryNode<T> newNode = new BinaryNode<T>(k, v);
            if (root == null) // передача данных корню
            {
                root = newNode;
                return;
            }
            else
            {
                root = Insert(root, newNode);
            }
        }
        public BinaryNode<T> Insert(BinaryNode<T> cur, BinaryNode<T> node)
        {
            if (cur == null)
            {
                cur = node;
                return cur;
            }
            else if (node.Key < cur.Key)
            {
                cur.Left = Insert(cur.Left, node);
                if (node.Parent == null) node.Parent = cur;
            }
            else if (node.Key > cur.Key)
            {
                cur.Right = Insert(cur.Right, node);
                if (node.Parent == null) node.Parent = cur;
            }
            return balance(cur);
        }

        public BinaryNode<T> findmin(BinaryNode<T> p) // поиск узла с минимальным ключом в дереве p 
        {
            return p.Left != null ? findmin(p.Left) : p;
        }

        public BinaryNode<T> removemin(BinaryNode<T> p) // удаление узла с минимальным ключом из дерева p
        {
            if (p.Left == null)
                return p.Right;
            p.Left = removemin(p.Left);
            return balance(p);
        }

        public void RemoveNode(int key)
        {
            root = Delete(root, key);
        }

        public BinaryNode<T> Delete(BinaryNode<T> node, int key)
        {
            if (node == null) return null;
            if (key < node.Key) node.Left = Delete(node.Left, key);
            else if (key > node.Key) node.Right = Delete(node.Right, key);
            else
            {
                BinaryNode<T> q = node.Left;
                BinaryNode<T> r = node.Right;

                if (r == null) return q;
                BinaryNode<T> min = findmin(r);
                min.Right = removemin(r);
                min.Left = q;
                return balance(min);
            }
            return balance(node);
        }

        public void View(BinaryNode<T> tmp) // вывод авл дерева в прямом порядке + balance factor
        {
            if (tmp != null)
            {
                Console.WriteLine("{0}  ///  bfactor = {1}", tmp, bfactor(tmp));
                if (tmp.Left != null) View(tmp.Left);
                if (tmp.Right != null) View(tmp.Right);
            }
        }
    }
}
