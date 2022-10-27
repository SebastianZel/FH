using System;

namespace U3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {4000, 8000, 16000, 32000, 64000, 128000, 256000};
            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine();
            QuickSort<int>.Sort(numbers);
            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine();
        }
    }

    class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] list)        
        {
            Sort(list, 0, list.Length - 1);
        }

        private static void Sort(T[] list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);
                Sort(list, left, pivot - 1);
                Sort(list, pivot + 1, right);
            }
        }

        private static int Partition(T[] list, int left, int right)
        {
            T x = list[right];
            int pivot = left - 1;

            for (int i = left; i < right; i++)
            {
                if (list[i].CompareTo(x) <= 0)
                {
                    pivot++;
                    T tmp = list[i];
                    list[i] = list[pivot];
                    list[pivot] = tmp;
                }
            }

            T tmpPivot = list[pivot + 1];
            list[pivot + 1] = list[right];
            list[right] = tmpPivot;

            return pivot + 1;
        }



        private static int PartitionRandom(T[] list, int left, int right)
        {
            T x = list[right];
            Random r = new Random();
            int pivot = r.Next(right);

            for (int i = left; i < right; i++)
            {
                if (list[i].CompareTo(x) <= 0)
                {
                    pivot++;
                    T tmp = list[i];
                    list[i] = list[pivot];
                    list[pivot] = tmp;
                }
            }

            T tmpPivot = list[pivot + 1];
            list[pivot + 1] = list[right];
            list[right] = tmpPivot;

            return pivot + 1;
        }

        private static int PartitionHalf(T[] list, int left, int right)
        {
            T x = list[(left+right)/2];
            int pivot = left - 1;

            for (int i = left; i < right; i++)
            {
                if (list[i].CompareTo(x) <= 0)
                {
                    pivot++;
                    T tmp = list[i];
                    list[i] = list[pivot];
                    list[pivot] = tmp;
                }
            }

            T tmpPivot = list[pivot + 1];
            list[pivot + 1] = list[right];
            list[right] = tmpPivot;

            return pivot + 1;
        }
        public static int[] generateRandomArray(int num)
        {
            int[] array = new int[num];
            Random r = new Random();
            for(int i= 0 ; i < array.Length; i++)
            {
                array[i] = r.Next();
            }
            return array;


        }
        public static int[] generateSortedArray(int num)
        {
           int[] array = new int[num];
            for(int i= 0 ; i < num; i++)
            {
                array[i] = i;
            }
            return array;


        }
    }
}
