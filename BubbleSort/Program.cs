using System;

namespace BubbleSort
{
    internal class Program
    {
        public static int[] array = new int[10];
        static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
                GenArray();
                array = BubbleSort(array, array.Length);
                //PrintArray(array);
                Console.WriteLine();
            }

        }

        private static int[] BubbleSort(int[] arr, int length)
        {
            if (length == 1)
            {
                return arr;
            }
            for (int i = 0; i < length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int tmp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = tmp;
                }
            }
            PrintArray(arr);
            return BubbleSort(arr, length - 1);
        }

        private static void GenArray()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 999);
            }
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i],4}");
            }
            Console.WriteLine();
        }
    }
}
