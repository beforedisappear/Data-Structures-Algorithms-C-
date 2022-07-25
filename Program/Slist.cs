using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class SingleList<T> where T : IComparable
    {
        public int Count { get; set; }     // количество элементов(узлов) в списке
        SingleNode<T> head;

        // добавление узла в начало
        public void AddHead(int k, T v)
        {
            SingleNode<T> new_node = new SingleNode<T>(k, v);

            if (head == null) head = new_node;
            else new_node.Next = head;
            head = new_node;
            Count++;
        }
        // добавление узла в конец
        public void AddEnd(int k, T v)
        {
            SingleNode<T> new_node = new SingleNode<T>(k, v);

            if (head == null)
            {
                AddHead(k, v);
            }
            else
            {
                SingleNode<T> cur = head;
                // ищем последний элемент
                while (cur.Next != null)
                {
                    cur = cur.Next;
                }
                //устанавливаем последний элемент
                cur.Next = new_node;
            }
            Count++;
        }
        // удаление первого узла из односвязного списка
        public void RemoveHead()
        {
            if (Count > 0)
            {
                head = head.Next;
                Count--;
                return;
            }
        }
        // удаление последнего узла из односвязного списка
        public void RemoveEnd()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    head = null; Count = 0; return;
                }
                SingleNode<T> tmp = head;
                // ищем предпоследний узел
                while (tmp.Next.Next != null)  // tmp.Next.Next - предпоследний узел
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Count--;
            }
        }
        // проверка на наличие элемента в односвязном списке
        public bool IsContainsByValue(T value)
        {
            SingleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }
        public void View()
        {
            Console.WriteLine("Single l. List");
            SingleNode<T> cur = head;
            // ищем последний элемент
            while (cur != null)
            {
                Console.Write("{0}=>", cur);
                cur = cur.Next;
            }
            Console.Write("NULL\n");
        }
        // поиск по значению
        public SingleNode<T> FindByValue(T value)
        {
            SingleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }
        // поиск по индексу
        public SingleNode<T> FindByIndex(int index)
        {
            int i = 0;
            SingleNode<T> tmp = head;
            if (index < 0 || index >= Count) return null;
            while (tmp != null)
            {
                if (i == index) { return tmp; }
                tmp = tmp.Next;
                i++;
            }
            return null;
        }
        // поиск по ключу
        public SingleNode<T> FindByKey(int key)
        {
            SingleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Key.Equals(key))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }
        // вставка нового узла после выбранного узла
        public void InsertByAfterValue(T select, int k, T v)
        {
            SingleNode<T> after_node = head;
            while (after_node != null)
            {
                if (after_node.Value.Equals(select))
                {
                    SingleNode<T> new_node = new SingleNode<T>(k, v)
                    {
                        Next = after_node.Next
                    };
                    after_node.Next = new_node;
                }
                after_node = after_node.Next;
            }
            Count++;
        }
        // вставка нового узла перед выбранным узлом
        public void InsertByBeforeValue(T select, int k, T v)
        {
            SingleNode<T> cur = head;
            SingleNode<T> before_node = null;
            while (cur != null)
            {
                if (cur.Value.Equals(select))
                {
                    SingleNode<T> new_node = new SingleNode<T>(k, v)
                    {
                        Next = cur
                    };
                    if (before_node != null)
                    {
                        before_node.Next = new_node;
                    }
                    else head = new_node;
                }
                before_node = cur;
                cur = cur.Next;
            }
            Count++;
        }
        // удаление узла по значению
        public bool RemoveByValue(T value)
        {
            SingleNode<T> cur = head;
            SingleNode<T> prev = null;  //Для отслеживания предыдущего узла применяется переменная prev

            while (cur != null)
            {
                if (cur.Value.Equals(value))
                {
                    if (prev != null)
                    {
                        // убираем узел cur, теперь prev ссылается не на cur, а на cur.Next
                        prev.Next = cur.Next;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;
                    }
                    Count--;
                    return true;
                }
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }
        // удаление узла по индексу
        public bool RemoveByIndex(int index)
        {
            int i = 0;
            SingleNode<T> cur = head;
            SingleNode<T> prev = null;  //Для отслеживания предыдущего узла применяется переменная prev

            if (index < 0 || index >= Count) return false;

            while (cur != null) // ищем нужный узел
            {
                if (i == index)
                {
                    if (prev != null)
                    {
                        // убираем узел cur, теперь prev ссылается не на cur, а на cur.Next
                        prev.Next = cur.Next;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;
                    }
                    Count--;
                    return true;
                }
                i++;
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }
        // удаление узла по ключу
        public bool RemoveByKey(int key)
        {
            SingleNode<T> cur = head;
            SingleNode<T> prev = null;  // для отслеживания предыдущего узла применяется переменная previous

            while (cur != null)
            {
                if (cur.Key.Equals(key))
                {
                    if (prev != null)
                    {
                        // убираем узел cur, теперь prev ссылается не на cur, а на cur.Next
                        prev.Next = cur.Next;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;
                    }
                    Count--;
                    return true;
                }
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }
    }
}