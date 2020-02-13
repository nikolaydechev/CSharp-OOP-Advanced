using System;

namespace _01.GenericBox
{
    public class StartUp
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
