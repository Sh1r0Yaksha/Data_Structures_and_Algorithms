using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class MergeSort
    {
        // In this sorting method, we split the array into to parts until 1 or 0 elements remain and then
        // build the array by comparing those arrays from the ground up
        static void Merge(int[] array, int startIndex, int middleIndex, int lastindex)
        {
            int leftSize = middleIndex - startIndex + 1;
            int rightSize = lastindex - middleIndex;

            int[] leftarray = new int[leftSize + 1];
            int[] rightarray = new int[rightSize + 1];
            // Up until this point, 2 temporary arrays are made


            int i,j;

            // Filling the left array
            for (i = 0; i < leftSize; i++)
            {
                leftarray[i] = array[startIndex + i];
            }

            // Filling the right array
            for (j = 0; j < rightSize; j++)
            {
                rightarray[j] = array[middleIndex + j + 1];
            }

            // For the last elements of the 2 arrays, we add Int.Max() value as a sentinel value
            // it is like infinite and make sure that every other element is smaller than it while merging
            leftarray[leftSize] = int.MaxValue;
            rightarray[rightSize] = int.MaxValue;

            i = 0;
            j = 0;

            // checking which element is smaller one, the main array element is replaced by the smaller one
            // and index of respective array is increased
            for (int k = startIndex; k <= lastindex; k++)
            {
                if (leftarray[i] <= rightarray[j]) 
                {
                    array[k] = leftarray[i]; 
                    i++;
                }
                else
                {
                    array[k] = rightarray[j];
                    j++;
                }
            }
        }

        public static void Sort(int[] array, int startIndex, int lastIndex)
        {
            if (startIndex < lastIndex)
            {
                int middleIndex = (lastIndex + startIndex - 1) / 2;

                Sort(array, startIndex, middleIndex);

                Sort(array, middleIndex + 1, lastIndex);

                Merge(array, startIndex, middleIndex, lastIndex);
            }
            
        }
    }
}
