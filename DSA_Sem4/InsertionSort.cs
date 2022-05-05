using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class InsertionSort
    {
        // For this, we start a loop from the 2nd element, pick the element as key and go back in a linear order checking
        // if the elements are in the right place adjacently, once all elements before the key have been checked, we move
        // to the next element and set that as the key
        public static void InsertionSortMethod(int[] array)
        {

            for (int i = 1; i < array.Length; i++) // we start the loop from the 2nd element
            {
                int key = array[i];

                int j = i - 1; // one element before key

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
