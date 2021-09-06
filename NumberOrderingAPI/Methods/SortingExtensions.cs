using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NumberOrderingAPI.Methods
{
    public static class SortingExtensions
    {
        public static List<BigInteger> BubbleSort(List<BigInteger> list)
        {
            bool requiresSwaps = true;
            while (requiresSwaps)
            {
                requiresSwaps = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        (list[i], list[i + 1]) = (list[i + 1], list[i]);
                        requiresSwaps = true;
                    }
                }
            }

            return list;
        }

        public static List<BigInteger> SelectionSort(List<BigInteger> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                var smallestVal = list[i];
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < smallestVal) smallestVal = list[j];
                }
                (list[i], smallestVal) = (smallestVal, list[i]);
            }

            return list;
        }
    }
}
