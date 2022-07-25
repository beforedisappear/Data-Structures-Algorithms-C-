using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class HTArray<T>
    {
        public SingleNode<T>[] htArray; // массив, в котором содержатся все значения
        public int[] active; // массив для активных ячеек
        public int Size; // размер хеш-таблицы
        public int Сount; // кол-во всех элементов в хеш-таблице
        public HTArray(int size) // констуктор
        {
            this.Size = size;
            htArray = new SingleNode<T>[size]; // массив на основе узла snode
            active = new int[Size];
            Сount = 0;
        }
        public int HashCode(int key)    // возвращает хеш-функцию
        {
            return key % Size;
        }
        public void Add(int key, T value) // добавление элемента в ячейку
        {
            if (Сount >= Size) // элементов больше чем ячеек
            {
                Resize(2 * Size);
                Add(key, value);
                return;
            }
            int index = HashCode(key); // хэш - функция
            var hash = new SingleNode<T>(key, value);
            if (active[index] == 0) // если ячейка не занята
            {
                htArray[index] = hash;
                Сount++;
                active[index] = 1;
                return;
            }
            if (active[index] != 0 && htArray[index].Key == key) // ячейка занята и совпадает ключ
            {
                Console.Write("this key exists!\n\n");
                return;
            }
            while (active[index] != 0) // поиск свободной ячейки
            {
                index++;
                if (index == Size) index = 0;
            }
            htArray[index] = hash;
            active[index] = 1;
            Сount++;
            return;
        }
        public SingleNode<T> SearchByKey(int key)    // результат поиска: ключ-значение
        {
            //int j = 0;
            //SingleNode<T> res = null;
            //while (j != active.Length)
            //{
            //    if (htArray[j] != null)
            //    {
            //        if (htArray[j].Key == key) { res = htArray[j]; break; }
            //        if (j == htArray.Length) { res = null; break; }
            //    }
            //    j++;
            //}
            //return res;

            SingleNode<T> res = null;
            int j = HashCode(key);
            if (active[j] == 1)
                if (htArray[j].Key == key) { res = htArray[j]; return res; }
            int limit = j; j = j + 1;
            while(j != limit)
            {
                if (htArray[j] != null)
                {
                    if (htArray[j].Key == key) { res = htArray[j]; return res; }
                }
                j++;
                if (j == active.Length) j = 0;
            }
            return res;
        }
        public int SearchIndex(int key)   // результат поиска: ключ
        {
            int j = 0;
            while (j != active.Length)
            {
                if (htArray[j] != null)
                {
                    if (htArray[j].Key == key) { return j; }
                    if (j == htArray.Length) { return -1; }
                }
                j++;
            }
            return -1;

        }
        public void RemoveByKey(int key)
        {
            var cell = SearchByKey(key);
            var index = SearchIndex(key);
            if (index == -1) return;
            if (cell != null)
            {
                active[index] = 0;
                htArray[index] = null;
            }
            else return;
        }
        public void Resize(int newsize)    // метод для изменения размера хеш-таблицы
        {
            var tmp = new SingleNode<T>[newsize];
            for (int index = 0; index < Size; index++)
            {
                tmp[index] = htArray[index];
            }
            htArray = new SingleNode<T>[newsize];
            Size = newsize;
            for (int index = 0; index < Size; index++)
            {
                htArray[index] = tmp[index];
            }
            Array.Resize(ref active, newsize);

        }
        public void View() // отображение хеш таблицы
        {
            for (int i = 0; i < htArray.Length; i++)
            {
                Console.Write("HTarray {0} ", i);
                if (htArray[i] != null)
                {
                    Console.Write(htArray[i]);
                }
                Console.WriteLine();
            }
        }
    }
}