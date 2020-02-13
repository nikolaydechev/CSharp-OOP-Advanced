namespace _03.DependencyInversion.Core.IO
{
    using System;
    using _03.DependencyInversion.Interfaces;
    using _03.DependencyInversion.Interfaces.IO;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
