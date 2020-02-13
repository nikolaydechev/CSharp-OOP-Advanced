namespace _02.Blobs.Core.IO
{
    using System;
    using _02.Blobs.Interfaces;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
