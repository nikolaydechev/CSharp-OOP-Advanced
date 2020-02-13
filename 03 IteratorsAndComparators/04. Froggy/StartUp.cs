using System;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(inputNumbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
