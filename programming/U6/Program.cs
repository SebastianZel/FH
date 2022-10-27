using System;

namespace U6
{
    class Program
    {
       static void Main(string[] args)
        {            Random r = new();
            int[] randomNumbers = new int[30];
            
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = r.Next(200);
            }

            Console.WriteLine("MinHeap");
            MinHeap<int> heap = new();
            foreach (int number in randomNumbers)
            {
                Console.Write($"{number}, ");
                heap.Insert(number);
            }
            Console.WriteLine();

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                Console.Write($"{heap.ExtractMin()}, ");
            }
            Console.WriteLine();

            Console.WriteLine("MaxHeap");
            MaxHeap<int> maxHeap = new();
            foreach (int number in randomNumbers)
            {
                Console.Write($"{number}, ");
                maxHeap.Insert(number);
            }
            Console.WriteLine();
            maxHeap.Insert(-10);
            maxHeap.Insert(-2);
            maxHeap.Insert(-99);

            for (int i = 0; i < randomNumbers.Length+3; i++)
            {
                Console.Write($"{maxHeap.ExtractMax()}, ");
            }
            Console.WriteLine();

        }
    }
}
