// Реализовать Bucketsort, проверить корректность работы
// Реализовать External sort, проверить корректность работы. Реализовать можно на основе Bucketsort, но не обязательно.

using System;
using System.Collections.Generic;

namespace GBAlgo8
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] array = new int[10];
            array = GenArray(array);
            PrintArray(array);

            int[] bucketSortArr = array;

            array = BucketSort(bucketSortArr);
            PrintArray(array);



        }


        //решение
        private static int[] BucketSort(int[] bucketSortArr)
        {
            List<int> list000_199 = new List<int> { };
            List<int> list200_399 = new List<int> { };
            List<int> list400_599 = new List<int> { };
            List<int> list600_799 = new List<int> { };
            List<int> list800_999 = new List<int> { };

            for (int i = 0; i < bucketSortArr.Length; i++)
            {
                if (bucketSortArr[i] >= 0 && bucketSortArr[i] <= 199)
                {
                    list000_199.Add(bucketSortArr[i]);
                }
                if (bucketSortArr[i] >= 200 && bucketSortArr[i] <= 399)
                {
                    list200_399.Add(bucketSortArr[i]);
                }
                if (bucketSortArr[i] >= 400 && bucketSortArr[i] <= 599)
                {
                    list400_599.Add(bucketSortArr[i]);
                }
                if (bucketSortArr[i] >= 600 && bucketSortArr[i] <= 799)
                {
                    list600_799.Add(bucketSortArr[i]);
                }
                if (bucketSortArr[i] >= 800 && bucketSortArr[i] <= 999)
                {
                    list800_999.Add(bucketSortArr[i]);
                }
                //PrintList(list000_199);
                //PrintList(list200_399);
                //PrintList(list400_599);
                //PrintList(list600_799);
                //PrintList(list800_999);




            }
            int[] arr000_199 = new int[list000_199.Count];
            int[] arr200_399 = new int[list200_399.Count];
            int[] arr400_599 = new int[list400_599.Count];
            int[] arr600_799 = new int[list600_799.Count];
            int[] arr800_999 = new int[list800_999.Count];
            arr000_199 = list000_199.ToArray();
            arr200_399 = list200_399.ToArray();
            arr400_599 = list400_599.ToArray();
            arr600_799 = list600_799.ToArray();
            arr800_999 = list800_999.ToArray();

            arr000_199 = BubbleSort(arr000_199, arr000_199.Length);
            arr200_399 = BubbleSort(arr200_399, arr200_399.Length);
            arr400_599 = BubbleSort(arr400_599, arr400_599.Length);
            arr600_799 = BubbleSort(arr600_799, arr600_799.Length);
            arr800_999 = BubbleSort(arr800_999, arr800_999.Length);
            /*
            PrintArray(arr000_199);
            PrintArray(arr200_399);
            PrintArray(arr400_599);
            PrintArray(arr600_799);
            PrintArray(arr800_999);*/

            int[] arraySort = new int[arr000_199.Length + arr200_399.Length + arr400_599.Length + arr600_799.Length + arr800_999.Length];
            int index = 0;
            for (int i = 0; i < arr000_199.Length; index++, i++)
            {
                arraySort[index] = arr000_199[i];
            }
            for (int i = 0; i < arr200_399.Length; index++, i++)
            {
                arraySort[index] = arr200_399[i];
            }
            for (int i = 0; i < arr400_599.Length; index++, i++)
            {
                arraySort[index] = arr400_599[i];
            }
            for (int i = 0; i < arr600_799.Length; index++, i++)
            {
                arraySort[index] = arr600_799[i];
            }
            for (int i = 0; i < arr800_999.Length; index++, i++)
            {
                arraySort[index] = arr800_999[i];
            }

            return arraySort;
        }





        private static int[] BubbleSort(int[] arr, int length)
        {
            if (length <= 1)
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
            //PrintArray(arr);
            return BubbleSort(arr, length - 1);
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i],4}");
            }
            Console.WriteLine();
        }

        public static int[] GenArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 999);
            }
            return array;
        }
    }
}
