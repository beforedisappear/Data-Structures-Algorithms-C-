using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class HTList<T> where T : IComparable
    {
        public List<SingleNode<T>>[] htLists;
        public int Size;    //кол-во списков
        public int Count;   //кол-во всех эл-ов в таблице
        public HTList(int size) // констуктор
        {
            this.Size = size;
            htLists = new List<SingleNode<T>>[size]; // ht на основе списков где ячейка - snode
            for (int i = 0; i < size; i++)
                htLists[i] = new List<SingleNode<T>>();
            Count = 0;
        }
        public int HashCode(int key) // возвращает хеш-функцию
        {
            return key % Size;
        }
        public void Adds(int key, T value)
        {
            //if (Count >= Size)
            //{
            //    Console.WriteLine("Error! HT is full!\n");
            //    return;
            //}
            int index = HashCode(key);
            SingleNode<T> el = new SingleNode<T>(key, value);
            htLists[index].Add(el);
            Count++;
        }

        public void RemoveByKey(int key)  // удаление элемента по ключу
        {
            int index = HashCode(key);
            int findind = -1;
            for (int i = 0; i < htLists[index].Count; i++) // ищем элемент в списке ячейки
            {
                SingleNode<T> cur = htLists[index][i];
                if (cur.Key.CompareTo(key) == 0) { findind = i; break; }
            }
            if (findind >= 0) // если элемент найден - удаляем
            { 
                htLists[index].RemoveAt(findind); 
                Count--; 
            }

        }
        public void Resize(int newSize) // изменить размер хеш-таблицы   
        {
            List<SingleNode<T>> tmp = new List<SingleNode<T>>(); // создаем список для заполнения текущих элементов

            for (int index = 0; index < Size; index++) // заполняем
            {
                for (int i = 0; i < htLists[index].Count; i++)
                {
                    SingleNode<T> cur = htLists[index][i];
                    tmp.Add(cur);
                }
            }
            htLists = new List<SingleNode<T>>[newSize]; // создаем новую хт с большей размерностью
            this.Size = newSize;
            for (int i = 0; i < Size; i++) // создаем ячейки
            {
                htLists[i] = new List<SingleNode<T>>();
            }
            Count = 0;
            foreach (SingleNode<T> el in tmp) // заполняем новую хт текущими элементами
            {
                Adds(el.Key, el.Value);
            }
        }
        public SingleNode<T> SearchByKey(int key) // поиск
        {
            int index = HashCode(key);
            for (int i = 0; i < htLists[index].Count; i++)
            {
                var cur = htLists[index][i];
                if (cur.Key.CompareTo(key) == 0) { return cur; }
            }
            return null;
        }
        public void View()
        {
            for (int index = 0; index < Size; index++)
            {
                Console.Write("HTist {0} ", index);
                for (int i = 0; i < htLists[index].Count; i++)
                {
                    SingleNode<T> cur = htLists[index][i];
                    Console.Write("{0}", cur);
                }
                Console.WriteLine();
            }
        }
    }
}