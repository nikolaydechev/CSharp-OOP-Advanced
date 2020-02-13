using System;

namespace _10.CreateCustomClassAttribute
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class StartUp
    {
        public static void Main()
        {
            var attributes = typeof(StartUp).GetCustomAttributes(false);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
            }
            Console.WriteLine(attributes[0]);
        }
    }
}
