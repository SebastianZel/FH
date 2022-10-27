using System;
using System.Diagnostics;

namespace U2
{
    class Program{
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int[] numbers = {8,16,31,64,4000,8000,16000,32000,64000,128000,256000};
             for(int i = 0; i<numbers.Length;i++){
                int[] ar = AlgoDatSort<int>.generateRandomArray(numbers[i]);
                
                sw.Restart();
                Console.WriteLine("Merge Sort");
                AlgoDatSort<int>.MergeSort(ar,0, ar.Length - 1);
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                 int[] ar2 = AlgoDatSort<int>.generateRandomArray(numbers[i]);
                sw.Restart();
                Console.WriteLine("Insertion Sort");
                AlgoDatSort<int>.InsertionSort(ar2);
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);


            }


        }
    }
    class AlgoDatSort<T> where T : IComparable<T>
    {
       
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
        public static void InsertionSort(T[] list)
        {
           
            for (int j = 1; j < list.Length; j++)
            {
                T key = list[j];
                int i = j - 1;
                while (i >= 0 && list[i].CompareTo(key) > 0)
                {
                    list[i + 1] = list[i];
                    i--;
                }
                list[i + 1] = key;
            }
        }
        
        public static void MergeSort(T[] list, int left, int right)
        {
           
            if (left < right)
            {
               
                int middle = (left + right) / 2;
                
                MergeSort(list, left, middle);
                MergeSort(list, middle + 1, right);
                Merge(list, left, middle, right);
            }
            
        }

        private static void Merge(T[] list, int left, int middle, int right)
        {
            int lPointer = left;
            int rPointer = middle + 1;
            T[] temp = new T[right - left + 1];
            int cPointer = 0;

            while (lPointer <= middle && rPointer <= right)
            {
                if (list[lPointer].CompareTo(list[rPointer]) <= 0)
                {
                    temp[cPointer] = list[lPointer];
                    lPointer++;
                }
                else
                {
                    temp[cPointer] = list[rPointer];
                    rPointer++;
                }
                cPointer++;
            }

            while (lPointer <= middle)
            {
                temp[cPointer] = list[lPointer];
                lPointer++;
                cPointer++;
            }

            while (rPointer <= right)
            {
                temp[cPointer] = list[rPointer];
                rPointer++;
                cPointer++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                list[left + i] = temp[i];
            }
        }


        }

    }
