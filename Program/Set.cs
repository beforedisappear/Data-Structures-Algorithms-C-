using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class Set<T> where T:IComparable
    {
        public int size; // размер множества 
        public int count; // количество элементов 
        public T[]data;
        // конструктор - метод необходимый для инициализации экземпляра класса.
        // специализорованный метод.
        public Set(int size)
        { 
            this.size = size; this.count = 0;
            data = new T[size];
            for (int i = 0; i < size; i++)
            { data[i] = default(T); }
        }
        // констуктор для передачи элементов массива
        public Set (T[] arr)
        {
            this.size = arr.Length;
            data = new T[size];
            for(int i = 0; i < size; i++)
            {
                data[i] = arr[i];
            }
            count = size;
        }
        // проверка на наличие элемента
        public bool Contains(T el)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(el))
                    return true;
            }
            return false;
        }
        // получение индекса элемента
        public int GetIndex(T el)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(el))
                    return i;
            }
            return -1;
        }
        // добавление нового элемента
        public void Add(T el)
        {
            if (data.Contains(el) == false)
            {
                if (count < size)
                {
                    data[count] = el;
                    count++;
                }
                else
                {
                    this.Resize(2 * size);
                    data[count] = el;
                    count++;
                }
            }
        }
        // изменение размера множеста
        public void Resize(int newsize)
        {
            if (count > 0)
            {
                T[] temp = new T[count];
                for (int i = 0;i < count; i++)
                {
                    temp[i] = data[i];
                }
                data = new T[newsize];
                if(newsize > size) // новая размер больше
                {
                    for (int i = 0; i < count; i++)
                    {
                        data[i] = temp[i];
                    }
                }
                else // меньше
                {
                    if (newsize >= count)
                    {
                        count = newsize;
                        for (int i = 0;i < count; i++)
                        {
                            data[i] = temp[i];
                        }
                    }
                }
            }
            else
            {
                data = new T[newsize]; size = newsize; count = 0; 
            }
        }
        // удаление элемента по индексу
        public bool RemoveInd(int index)
        {
            if (index < 0 || index-1 > count) return false;
            for (int i = index; i < count - 1; i++) // смещаем элементы влево от удаленного
            {
                data[i] = data[i + 1];
            }
            data[count - 1] = default(T); // отсекаем последний
            count--;
            return true;
        }
        // удаление элемента по значению
        public bool RemoveEL(T el)
        {
            return RemoveInd(GetIndex(el));
        }
        // получение данных множества по индексу
        public T GetElementByIndex(int i)
        {
            return data[i];
        }
        // установить новый элемент по индексу
        public T SetElementByIndex(int index, T newEl)
        {
            if (index < 0 || index >= count) return default;
            data[index] = newEl;
            return data[index];
        }
        // объедение множеств
        public static Set<T> Union(Set<T> s1, Set<T> s2) 
        {
            Set<T> rab = new Set<T>(s1.size + s2.size);
            for (int i = 0; i < s1.count; i++)
            {
                rab.Add(s1.data[i]);
            }
            for (int i = 0; i < s2.count; i++)
            {
                rab.Add(s2.data[i]);
            }
            return rab;
        }
        // пересечение множеств
        public static Set<T> Intersection(Set<T> s1, Set<T> s2)
        {
            Set<T> rab = new Set<T>(s1.size + s2.size);
            for (int i = 0; i < s1.size; i++)
            {
                if (s2.Contains(s1.data[i]))
                {
                    rab.Add(s1.data[i]);
                }
            }
            return rab;
        }
        // дополнение множеств
        public static Set<T> Addition(Set<T> s1, Set<T> s2)
        {
            Set<T> rab = new Set<T>(s1.size + s2.size);
            for (int i = 0; i < s1.count; i++)
            {
                if (!s2.Contains(s1.data[i]))
                {
                    rab.Add(s1.data[i]);
                }
            }
            return rab;
        }
        // получение набора множеств из последовательности элементов множества
        public List<Set<T>> SelectSets()
        {
            List <Set<T>> lsets = new List<Set<T>>();
            for (int i = 0; i < count; i++)
            {
                Set<T> temp = new Set<T>(i + 1);
                for (int j = 0; j <= i; j++)
                    temp.Add(data[j]);
                lsets.Add(temp);
            }
            return lsets;
        }
        // поиск всех подмножеств множества
        public void Allsubsets(T[] list)
        {
            int comb = (int)Math.Pow(2, list.Length); // количество подмножеств
            string[] result = new string[comb]; // массив подмножеств как элементов 
            for (int i = 0; i < comb; i++) // кол-во подмножеств
            {
                for (int j = 0; j < list.Length; j++)  // перебор индекса массива 0,1,2 (for n=3)
                {
                    int t = (int)Math.Pow(2, j);
                    if ((i & t) != 0) // формирование подмножества
                    { // вывод происходит при содержании на одних и тех же позициях единичных битов (в порядке cba)
                        result[i] = result[i] + " " + list[j]; 
                    } // к примеру : подмножество {a,b} = {011 и 001, 011 и 010}
                }
                Console.WriteLine("subset {0} : {1}", i, result[i]); // вывод подмножества
            }
        }
        public override string ToString()
        {
            string res = "{";
            for (int i = 0; i < count - 1; i++)
            {
                res = res + data[i].ToString() + ";";
            }
            res = res + data[count - 1].ToString() + "}";
            return res;
        }
    }
}
