using System;

namespace U7
{
    class Program
    {
static void Main(string[] args)
        {
            Random r = new();
            int[] randomNumbers = new int[30];
            
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = r.Next(200);
            }

            MinHeap<int> heap = new();
            foreach (int number in randomNumbers)
            {
                heap.Insert(number);
            }

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                Console.WriteLine(heap.ExtractMin());
            }
        }
    }
}
