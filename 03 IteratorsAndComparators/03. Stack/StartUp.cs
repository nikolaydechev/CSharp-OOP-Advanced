using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new StackCollection<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputParams = input.Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (inputParams.Length)
                    {
                        //Pop
                        case 1:
                            stack.Pop();
                            break;
                        //Push
                        default:
                            stack.Push(inputParams.Skip(1).ToArray());
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
