using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class IndTask
    {
		// non-recursive quicksort
		public static T[] QuickSortNR<T>(T[] arr, int minindex, int maxindex) where T : IComparable
		{
			Stack<int> stack = new Stack<int>(); // создание стека для хранения подмассивов
			var pivotindex = partition(arr, minindex, maxindex); // // метод получения индекса элемента pivot / разделение на подмассивы
			if (pivotindex - 1 > minindex) // заполение в стэк индексов в интервале левого подмассива
			{
				stack.Push(minindex);
				stack.Push(pivotindex - 1);
			}
			if (pivotindex + 1 < maxindex) // заполение в стэк индексов в интервале правого подмассива
			{
				stack.Push(pivotindex + 1);
				stack.Push(maxindex);
			}
			while (stack.Count() != 0) // пока стэк не пустой происходит сортировка подмассивов
			{
				int right = stack.Pop(); // правая граница (координаты) подмассива
				int left = stack.Pop(); // левая граница (координаты) подмассива
				var newpivot = partition(arr, left, right);
				if (newpivot - 1 > left)  // помещение в стек координат левого подмассива
				{
					stack.Push(left);
					stack.Push(newpivot - 1);
				}
				if (newpivot + 1 < right) // помещение в стек координат правого подмассива
				{
					stack.Push(newpivot + 1);
					stack.Push(right);
				}
			}
			return arr;
		}
		public static int partition<T>(T[] arr, int minindex, int maxindex) where T : IComparable
		{
			int pivot = minindex;
			for (int j = minindex; j <= maxindex; j++)
			{
				// когда он меньше, чем опорный элемент
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
		// non-recursive mergesort
		public static T[] MergeSortNR<T>(T[] arr) where T : IComparable
		{
			for (int gap = 1; gap < arr.Length; gap = 2 * gap)
			{
				MergePass(arr, gap, arr.Length);
			}
			return arr;
		}
		public static void MergePass<T>(T[] arr, int gap, int length) where T : IComparable
		{
			int i = 0;
			// разбиение исходного массива на подмассивы для последующей сортировки
			for (i = 0; i + 2 * gap - 1 < length; i = i + 2 * gap)
			{
				Merge(arr, i, i + gap - 1, i + 2 * gap - 1);
			}
			// если кол-во элементов массива нечетное
			if (i + gap - 1 < length)
			{
				Merge(arr, i, i + gap - 1, length - 1);
			}
		}
		public static void Merge<T>(T[] arr, int minindex, int middleindex, int maxindex) where T : IComparable
        {
            var left = minindex; // указатель левого подмассива
            var right = middleindex + 1; // указатель правого подмассива
            var temparr = new T[maxindex - minindex + 1]; // переменный массив для записи отсортированного массива
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
            for (var i = left; i <= middleindex; i++) // дозаполенение отсортированными элементами левого подмассива (под левым указателем)
			{
                temparr[index] = arr[i];
                index++;
            }
            for (var i = right; i <= maxindex; i++) // дозаполенение отсортированными элементами правого подмассива (под правым указателем)
            {
                temparr[index] = arr[i];
                index++;
            }
            for (var i = 0; i < temparr.Length; i++) // заполнение исходного массива элементами отсортированного подмассива
            {
                arr[minindex + i] = temparr[i];
            }
        }
        public static T[] MergeSortNR2<T>(T[] arr) where T : IComparable
        {
            Stack<T[]> stack1 = new Stack<T[]>(); // создаем стек1
            Stack<T[]> stack2 = new Stack<T[]>(); // создаем стек2
            for (int i = 0; i < arr.Length; i++) // заполняем стек1
            {   // одномерными массивами, элементами которых явлются элементы arr
                stack1.Push(new T[] { arr[i] });
            }
            while (stack1.Count > 1) // пока массив не отсортирован в стеке находится больше 1 элемента
            {
                while (stack1.Count > 1) 
                {
                    T[] right = stack1.Pop(); // достаем из стека1 правый подмассив
                    T[] left = stack1.Pop(); // достаем из стека1 левый подмассив
                    T[] merged = Merge2(left, right); // выполняем их Объединение и Сортировку 
                    stack2.Push(merged); // помещаем в стек2 отсортированный подмассив
                }
                while (stack2.Count > 1)
                {
                    T[] right = stack2.Pop(); // достаем из стека1 правый подмассив
                    T[] left = stack2.Pop(); // достаем из стека1 левый подмассив
                    T[] merged = Merge2(left, right); // выполняем их Объединение и Сортировку 
                    stack1.Push(merged); // помещаем в стек1 отсортированный подмассив
                }
            }
            if (stack1.Count != 0 && stack2.Count != 0) // случай, когда оба стека не пусты
            {
                return Merge2(stack1.Pop(), stack2.Pop());
            }
            if (stack2.Count == 0) return stack1.Pop();
            else return stack2.Pop();
        }
        public static T[] Merge2<T>(T[] left, T[] right) where T : IComparable
        {
            int llen = left.Length; // размерность левого подмассива
            int rlen = right.Length; // размерность правого подмассива
            T[] MergedArray = new T[llen + rlen]; // объединенный массив с суммарной размерностью
            int l = 0; // левый указатель
            int r = 0; // правый указатель
            int index = 0; // индекс для нового (объединенного) массива
            while (l < llen && r < rlen) // передвижение указателей, пока они не выйдут за пределы массивов
            {
                if (left[l].CompareTo(right[r]) < 0)
                {
                    MergedArray[index++] = left[l++];
                }
                else
                {
                    MergedArray[index++] = right[r++];
                }
            }
            while (l < llen) // дозаполенение отсортированными элементами левого подмассива (под левым указателем)
            {
                MergedArray[index++] = left[l++];
            }
            while (r < rlen) // дозаполенение отсортированными элементами правого подмассива (под правым указателем)
            {
                MergedArray[index++] = right[r++];
            }
            return MergedArray;
        }
    }
}