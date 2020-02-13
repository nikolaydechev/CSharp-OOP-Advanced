namespace BashSoft.DataStructures
{
    using System;

    public static class QuickSort
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static int Partition<T>(T[] array, int mid)
            where T : IComparable<T>
        {
            int midPoint = mid,
                upperBound = array.Length - 1,
                lowerBound = 0;
            while (lowerBound != upperBound)
            {
                while (midPoint < upperBound)
                {
                    if (array[midPoint].CompareTo(array[upperBound]) > 0)
                    {
                        Swap<T>(ref array[midPoint], ref array[upperBound]);
                        midPoint = upperBound;
                        break;
                    }

                    upperBound--;
                }

                while (midPoint > lowerBound)
                {
                    if (array[midPoint].CompareTo(array[lowerBound]) < 0)
                    {
                        Swap<T>(ref array[midPoint], ref array[lowerBound]);
                        midPoint = lowerBound;
                        break;
                    }

                    lowerBound++;
                }
            }
            return midPoint;
        }

        public static void QSort<T>(T[] array, int lower, int upper)
            where T : IComparable<T>
        {
            int mid = Partition(array, (lower + upper) / 2);

            if (upper <= lower)
            {
            }
            else
            {
                QSort(array, mid + 1, upper);
                QSort(array, lower, mid - 1);
            }
        }
    }
}
