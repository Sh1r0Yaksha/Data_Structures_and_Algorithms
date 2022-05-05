using System;

namespace DSA_Sem4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = {1,9,2,4,3,6,5,7,8};
            int[] temp = testArray;

            Console.WriteLine("Bubble sort: ");
            BubbleSort.BubbleSortMethod(testArray);
            PrintArray(testArray);

            Console.WriteLine("\n\nBinary search:");
            Console.WriteLine(BinarySearch.BinarySearchMethod(9, testArray, 0, testArray.Length - 1));

            testArray = temp;
            Console.WriteLine("\n\nInsertion sort:");
            InsertionSort.InsertionSortMethod(testArray);
            PrintArray(testArray);

            testArray = temp;
            Console.WriteLine("\n\nMergeSort: ");
            MergeSort.Sort(testArray, 0, testArray.Length - 1);
            PrintArray(testArray);


        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
                Console.WriteLine(i);
        }
    }
}