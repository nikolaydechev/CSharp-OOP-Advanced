namespace _03.DependencyInversion.Core.IO
{
    using System;
    using _03.DependencyInversion.Interfaces;
    using _03.DependencyInversion.Interfaces.IO;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
