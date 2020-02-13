using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                sortedSet.Add(new Person(input[0], int.Parse(input[1])));
                hashSet.Add(new Person(input[0], int.Parse(input[1])));

            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
