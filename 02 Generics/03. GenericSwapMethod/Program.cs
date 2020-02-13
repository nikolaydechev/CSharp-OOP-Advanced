using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethod
{
    public class Program
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            IList<Box<int>> boxList = new List<Box<int>>();

            for (int i = 0; i < N; i++)
            {
                var input = int.Parse(Console.ReadLine());
                boxList.Add(new Box<int>(input)); 
            }

            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                var indexes = readLine
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                SwapMethod(boxList, indexes[0], indexes[1]);
            }

            Console.WriteLine(string.Join(Environment.NewLine, boxList));
        }

        private static void SwapMethod<T>(IList<T> items, int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
