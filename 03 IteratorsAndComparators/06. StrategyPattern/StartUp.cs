using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var sortedSet1 = new SortedSet<Person>(new NameComparator());
            var sortedSet2 = new SortedSet<Person>(new AgeComparator());

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                sortedSet1.Add(new Person(input[0], int.Parse(input[1])));
                sortedSet2.Add(new Person(input[0], int.Parse(input[1])));
            }

            foreach (var person in sortedSet1)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
            foreach (var person in sortedSet2)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
