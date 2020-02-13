using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            var inputCreate = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var inputCreateData = inputCreate.Skip(1).ToArray();

            var listyIterator = new ListyIterator<string>(inputCreateData);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (input)
                    {
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "PrintAll":
                            foreach (var element in listyIterator)
                            {
                                Console.Write(element + " ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        //public List<T> createList<T>(T item, int count)
        //{
        //    List<T> list = new List<T>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        list.Add(item);
        //    }

        //    return list;
        //}

    }
}
