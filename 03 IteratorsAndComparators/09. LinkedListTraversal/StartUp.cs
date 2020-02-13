using System;

namespace _09.LinkedListTraversal
{
    public class StartUp
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Add":
                        linkedList.AddLast(int.Parse(input[1]));
                        break;
                    case "Remove":
                        linkedList.Remove(int.Parse(input[1]));
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}
