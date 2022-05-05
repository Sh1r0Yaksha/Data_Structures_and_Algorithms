using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class BubbleSort
    {
        public static void BubbleSortMethod(int[] array)
        {
            for (int i = 0; i < array.Length; i++) // running loop n times
            {
                //each time this loop runs the last element is sorted
                for (int j = 0; j < array.Length - i - 1; j++) // running loop from 0 to last - i, 
                {
                    if (array[j] > array[j + 1]) // checks if next element is bigger or not, swaps if smaller
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
