namespace _06.Twitter.Models
{
    using System;
    using _06.Twitter.Interfaces;

    class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
