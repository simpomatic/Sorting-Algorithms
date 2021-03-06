﻿using System.Linq;

namespace SortingAlgorithms
{
    public class ShellSort : ISortingAlgorithm
    {
        /// <summary>
        /// Insertion sort that is performed on all values that are offsets of size `gap` from the given starting index.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        /// <param name="startIndex">Starting index</param>
        /// <param name="gap">Current gap size</param>
        private void GapInsertionSort(ref int[] arr, int startIndex, int gap)
        {
            int currentPosition = startIndex;

            // Make sure the current position plus the gap does not exceed array length
            while (currentPosition + gap < arr.Length)
            {
                // Check to see if the item ahead of the current one has a lower value
                if (arr[currentPosition + gap] < arr[currentPosition])
                {
                    int tempValue = arr[currentPosition];
                    arr[currentPosition] = arr[currentPosition + gap];
                    arr[currentPosition + gap] = tempValue;
                }
                // Check to see if the current value is greater than the previous value
                else if (currentPosition - gap >= startIndex && arr[currentPosition] < arr[currentPosition - gap])
                {
                    int tempValue = arr[currentPosition];
                    arr[currentPosition] = arr[currentPosition - gap];
                    arr[currentPosition - gap] = tempValue;
                    currentPosition -= gap;
                }
                else
                {
                    currentPosition += gap;
                }
            }
        }

        public int[] Sort(int[] arr)
        {
            int gap = arr.Length / 2;

            while (gap > 0)
            {
                // Perform the gap insertion sort with all numbers in the range between zero and the gap size
                foreach (int startingPosition in Enumerable.Range(0, gap))
                {
                    GapInsertionSort(ref arr, startingPosition, gap);
                }

                // Halve the gap until it eventually hits one
                gap /= 2;
            }

            return arr;
        }
    }
}
