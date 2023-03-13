using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class nCBSmaxEL
    {
        public static T getMax<T>(T[] arr) where T : IComparable
        {
            T max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max.CompareTo( arr[i]) < 0) { max = arr[i]; }
            }
            return max;
        }

    }
    class MySort
    {
        // non-comparison-based sorts
        public static void CountSort(int[] arr)
        {
            int n = arr.Length;
            int[] resarr = new int[n];

            // находим макс. элемент и создаем массив размерности max
            int max = nCBSmaxEL.getMax(arr);
            
            int[] count = new int[max+1];

            // записываем кол-во каждого элемента в соотв. индексе count
            for (int i = 0; i < n; i++)
                count[arr[i]]++;

            // кумулятивная сумма элементов массива count
            for (int i = 1; i < max+1; i++)
                count[i] += count[i - 1];

            int k = n - 1;
            while (k >= 0)
            {
                resarr[count[arr[k]] - 1] = arr[k];
                count[arr[k]]--;
                k--;
            }

            // запись элементов в отсортированном порядке
            for (int i = 0; i < n; i++)
                arr[i] = resarr[i];
        }

        public static void CountSortForRadix(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] count = new int[10];
            int[] resarr = new int[n];

            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // помещаем элементы в массив в отсортированном порядке
            for (int i = n - 1; i >= 0; i--)
            {
                resarr[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // запись элементов в отсортированном порядке в исходный массив
            for (int i = 0; i < n; i++)
                arr[i] = resarr[i];
        }

        public static void RadixSort(int[] arr)
        {
            int max_digit = nCBSmaxEL.getMax(arr); // максимальный разряд
            // перебираем разряды до максимального
            // применяем подсчетную сортировку для сортировки элементов на основе значения места
            for (int exp = 1; max_digit / exp > 0; exp *= 10)
                CountSortForRadix(arr, exp);
        }

        public static void BucketSort(double[] arr) // for double
        {
            int numberOfBuckets = 10;
            List<double>[] bucket = new List<double>[10];

            for (int i = 0; i < numberOfBuckets; i++)
                bucket[i] = new List<double>();

            var rmax = nCBSmaxEL.getMax(arr);

            if (rmax > 1) { rmax = rmax.ToString().Length;  }
            else { rmax = 0; }

            // помещаем элементы в соответствующую корзину
            for (int i = 0; i < arr.Length; i++)
            {
                var selectedBucket = Convert.ToInt32(arr[i] * numberOfBuckets / Math.Pow(10, rmax));
                bucket[selectedBucket].Add(arr[i]);
            }

            // индивидуально сортируем каждую корзину
            for (int i = 0; i < numberOfBuckets; i++)
                if (bucket[i].Count > 1)
                    bucket[i].Sort();

            // запись элементов в отсортированном порядке в исходный массив
            int k = 0;
            foreach (List<double> lst in bucket)
            {
                if (lst.Count != 0)
                {
                    foreach (double i in lst)
                    {
                        arr[k] = i;
                        k++;
                    }
                }
            }
        }

        // comparison-based sorts
        public static void BubbleSort<T>(T[] arr) where T : IComparable
        {
            int n = arr.Length;
            int swapcount = n - 1;
            int k = 0;
            while (swapcount > 0)
            {
                for (int i = 0; i < swapcount; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T c = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = c;
                        k++;
                    }
                }
                swapcount--;
                if (k == 0) // условие выхода из цикла если массив отсортирован
                {
                    break;
                }
            }
        }
        public static void SelectionSort<T>(T[] arr) where T : IComparable
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i+1; j < n; j++) // ищем минимальный элемент
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (min != i) // если минимальный эл уже стоял на своем месте
                { // меняем местами с первым элементом 
                    T temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }
        public static void InsertionSort<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var temp = arr[i];
                var j = i;
                while (j > 0 && temp.CompareTo(arr[j - 1]) < 0) // пока правая подколлекция не пустая, продвигать элемент влево / пока элемент слева больше / temp < arr[j-1]
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }

        }
        public static void ShakerSort<T>(T[] arr) where T : IComparable  // bubblesort с двух сторон 
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T c = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = c;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (arr[i].CompareTo(arr[i - 1]) < 0)
                    {
                        T b = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = b;
                    }
                }
                left++;
            }
        }
        public static void ShellSort<T>(T[] arr) where T : IComparable
        {
            var step = arr.Length / 2;
            while (step > 0)
            {
                for (int i = step; i < arr.Length; i++)
                {
                    int j = i;
                    while ((j >= step) && (arr[j - step].CompareTo(arr[j])) > 0)
                    {
                        T c = arr[j - step];
                        arr[j - step] = arr[j];
                        arr[j] = c;
                        j = j - step; 
                    }
                }
                step /= 2;
            }
        }
        public static int BinSearch<T>(T[] arr, T el) where T : IComparable
        {
            int indbegin = 0;
            int indend = arr.Length;
            while (indbegin <= indend)
            {
                int mid = (indend + indbegin) / 2;
                if (el.CompareTo(arr[mid]) == 0) return mid;
                else if (el.CompareTo(arr[mid]) > 0) indbegin = mid + 1;
                else if (el.CompareTo(arr[mid]) < 0) indend = mid - 1;
            }
            return -1;
        }
        public static T[] QuickSort<T>(T[] arr, int minindex, int maxindex) where T : IComparable
        {   
            if (minindex >= maxindex) { return arr; }  // критерий выхода из рекурсии во избежании переполения стэка (массив отсортирован)
            var pivotindex = Partition(arr, minindex, maxindex); // метод получения индекса элемента pivot / разделение на подмассивы
            QuickSort(arr, minindex, pivotindex - 1); // сортировка левого подмассива
            QuickSort(arr, pivotindex + 1, maxindex); // сортировка правого подмассива
            return arr;
        }
        public static int Partition<T>(T[] arr, int minindex, int maxindex) where T : IComparable
        {
            int pivot = minindex; // определение индекса pivot
            for (int j = minindex; j <= maxindex; j++) // размещение слева элементов,меньших опорного
            {                                          // размещение справа элементов,больших опорного
                if (arr[j].CompareTo(arr[maxindex]) <= 0)
                {
                    T temp = arr[pivot];
                    arr[pivot] = arr[j];
                    arr[j] = temp;
                    pivot++;
                }
            }
            return pivot - 1;
        }
        public static T[] MergeSort<T>(T[] arr, int minindex, int maxindex) where T : IComparable
        {
            if (minindex < maxindex) // критерий выхода из рекурсии
            {
                var middleindex = (minindex + maxindex) / 2; // вспомогательная переменная для разделения массива
                MergeSort(arr, minindex, middleindex); // сортировка левого подмассива
                MergeSort(arr, middleindex + 1, maxindex); // сортировка правого подмассива
                Merge(arr, minindex, middleindex, maxindex); // слияние подмассивов
            }
            return arr;
        }
        // метод для слияния массивов
        public static void Merge<T>(T[] arr, int minindex, int middleindex, int maxindex) where T : IComparable
        {
            var left = minindex; // указатель левого подмассива
            var right = middleindex + 1; // указатель правого подмассива
            var temparr = new T[maxindex - minindex + 1]; // переменный массив для записи отосортированного массива
            var index = 0; // индекс для заполнения переменного массива
            while ((left <= middleindex) && (right <= maxindex)) // передвижение левого и правого указателя
            {   // указатели движутся, пока не выйдут за пределы массива
                if (arr[left].CompareTo(arr[right]) < 0)
                {
                    temparr[index] = arr[left];
                    left++;
                }
                else
                {
                    temparr[index] = arr[right];
                    right++;
                }
                index++;
            }
            for (var i = left; i <= middleindex; i++) // дозаполенение отсортированными элементами левого подмассива
            {
                temparr[index] = arr[i];
                index++;
            }
            for (var i = right; i <= maxindex; i++) // дозаполенение отсортированными элементами правого подмассива
            {
                temparr[index] = arr[i];
                index++;
            }
            for (var i = 0; i < temparr.Length; i++) // заполнение исходного массива элементами отсортированного подмассива
            {
                arr[minindex + i] = temparr[i];
            }
        }

        public static void InsertionSortForTim<T>(T[] arr, int left, int right) where T : IComparable
        {
            for (int i = left + 1; i <= right; i++)
            {
                T temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j].CompareTo(temp) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        public const int RUN = 4;
        public static T[] TimSort<T>(T[] arr) where T : IComparable
        {
            int n = arr.Length;
            // сортировка подмассивов размерности RUN
            for (int i = 0; i < n; i += RUN)
                InsertionSortForTim(arr, i, Math.Min((i + RUN - 1), (n - 1)));

            // слиянием и сортировка подмассивов размерности size = RUN
            // после каждого слияния size увеличивается в 2 раза
            // увеличение происходит до тех пор, пока size не будет равен размер массива
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));
                    if (mid < right) Merge(arr, left, mid, right);
                }
            }

            return arr;
        }


    }
}