using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class DoubleList<T> where T:IComparable
    {
        public int Count { get; set; }     // количество элементов(узлов) в списке
        DoubleNode<T> head;            // головной/первый узел
        DoubleNode<T> tail;            // последний/хвостовой узел

        // добавление в начало
        public void AddHead(int k, T v)
        {
            DoubleNode<T> new_node = new DoubleNode<T>(k, v);
            DoubleNode<T> cur = head;
            new_node.Next = cur;
            head = new_node;
            if (Count == 0) // если узлов было 0, то головной = хвостовой
                tail = head;
            else
                cur.Prev = new_node;
            Count++;
        }

        // добавление узла в конец
        public void AddEnd(int k, T v)
        {
            DoubleNode<T> new_node = new DoubleNode<T>(k, v);
            if (head == null)
            {
                AddHead(k, v);
            }
            else
            {
                DoubleNode<T> cur = tail;
                new_node.Prev = cur;
                tail = new_node;
                if (Count == 0)
                {
                    head = tail;
                }
                else
                {
                    cur.Next = new_node;
                }
                Count++;
            }
        }
        public bool IsContainsByValue(T value)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }
        // удаление первого узла из двусвязного списка
        public void RemoveHead()
        {
            if (Count > 0)
            {
                head = head.Next;
                head.Prev = null;
                Count--;
                return;
            }
        }
        // удаление последнего узла из двусвязного списка
        public void RemoveEnd()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    head = null; tail = null; Count = 0; return;
                }
                DoubleNode<T> tmp = head;
                // ищем предпоследний узел
                while (tmp.Next.Next != null)        //tmp.Next.Next - предпоследний узел
                {
                    tmp = tmp.Next;
                }
                tmp.Next.Prev = null;
                tmp.Next = null;
                tail = tmp;
                Count--;
            }
        }
        // удаление по значению
        public bool RemoveByValue(T value)
        {
            DoubleNode<T> cur = head;

            // поиск удаляемого узла
            while (cur != null)
            {
                if (cur.Value.Equals(value))
                {
                    break;
                }
                cur = cur.Next;
            }

            if (cur != null)
            {
                // если узел не последний
                if (cur.Next != null)
                {
                    cur.Next.Prev = cur.Prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = cur.Prev;
                }

                // если узел не первый
                if (cur.Prev != null)
                {
                    cur.Prev.Next = cur.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = cur.Next;
                }
                Count--;
                return true;
            }
            return false;
        }
        // удаление по ключу
        public bool RemoveByKey(int value)
        {
            DoubleNode<T> cur = head;

            // поиск удаляемого узла
            while (cur != null)
            {
                if (cur.Key.Equals(value))
                {
                    break;
                }
                cur = cur.Next;
            }

            if (cur != null)
            {
                // если узел не последний
                if (cur.Next != null)
                {
                    cur.Next.Prev = cur.Prev;
                }
                else
                {
                    tail = cur.Prev; // если последний, переустанавливаем tail
                }
                if (cur.Prev != null) // если узел не первый
                {
                    cur.Prev.Next = cur.Next;
                }
                else
                {
                    head = cur.Next; // если первый, переустанавливаем head
                }
                Count--;
                return true;
            }
            return false;
        }
        // удаление по индексу
        public bool RemoveByIndex(int index)
        {
            int i = 0;
            DoubleNode<T> cur = head;
            if (index < 0 || index >= Count) return false;
            // поиск удаляемого узла
            while (cur != null)
            {
                if (i == index)
                {
                    break;
                }
                i++;
                cur = cur.Next;
            }
            if (cur != null)
            {
                if (cur.Next != null) // если узел не последний
                {
                    cur.Next.Prev = cur.Prev; // уст у следуюшего элемента предыдущий текущего
                }
                else
                {
                    tail = cur.Prev; // если последний, переустанавливаем tail
                }
                if (cur.Prev != null) // если узел не первый
                {
                    cur.Prev.Next = cur.Next;
                }
                else // если первый, переустанавливаем head
                {
                    head = cur.Next;
                }
                Count--;
                return true;
            }
            return false;
        }
        // поиск по значению
        public DoubleNode<T> FindByValue(T value)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }
        // поиск по ключу
        public DoubleNode<T> FindByKey(int key)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Key.Equals(key))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }

        // поиск по индесу
        public DoubleNode<T> FindByIndex(int index)
        {
            int i = 0;
            DoubleNode<T> tmp = head;
            if (index < 0 || index >= Count) return null;
            while (tmp != null)
            {
                if (i == index) { return tmp; }
                tmp = tmp.Next;
                i++;
            }
            return null;
        }
        // вставка нового узла после выбранного узла
        public void InsertByAfterValue(T select, int k, T v)
        {
            DoubleNode<T> after_node = head;
            if (Count == 0) 
            { 
                head = after_node; 
            }
            while (after_node != null)
            {
                if (after_node.Value.Equals(select))
                {
                    //FindByValue(value);
                    DoubleNode<T> new_node = new DoubleNode<T>(k, v);
                    if (after_node.Next == null) { AddEnd(k, v); return; }
                    after_node.Next.Prev = new_node;
                    new_node.Next = after_node.Next;
                    after_node.Next = new_node;
                    new_node.Prev = after_node;
                    Count++;
                }
                after_node = after_node.Next;
            }
        }
        // вставка нового узла перед выбранным узлом
        public void InsertByBeforeValue(T select, int k, T v)
        {
            DoubleNode<T> before_node = head;
            if (Count == 0) { head = before_node; tail = before_node; }
            while (before_node != null)
            {
                if (before_node.Value.Equals(select))
                {
                    DoubleNode<T> new_node = new DoubleNode<T>(k, v);
                    if (before_node.Prev == null) 
                    { 
                        AddHead(k, v); return; 
                    }
                    before_node.Prev.Next = new_node;
                    new_node.Prev = before_node.Prev;
                    before_node.Prev = new_node;
                    new_node.Next = before_node;
                    Count++;
                }
                before_node = before_node.Next;
            }
        }
        public void ViewForward()
        {
            Console.WriteLine("Double l. List Forward");
            DoubleNode<T> cur = head;

            while (cur != null)
            {
                Console.Write("{0}<=>", cur);
                cur = cur.Next;
            }
            Console.Write("NULL\n");
        }
        public void ViewBack()
        {
            Console.WriteLine("Double l. List Back");
            DoubleNode<T> cur = tail;

            while (cur != null)
            {
                Console.Write("{0}<=>", cur);
                cur = cur.Prev;
            }
            Console.Write("NULL\n");
        }
    }
}