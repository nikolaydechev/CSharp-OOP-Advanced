using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethod
{
    public class Program
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var listOfBoxes = new List<Box<double>>();

            for (int i = 0; i < N; i++)
            {
                var input = double.Parse(Console.ReadLine());
                listOfBoxes.Add(new Box<double>(input));
            }

            var comparingElement = double.Parse(Console.ReadLine());
            int res = CompareMethod<Box<double>>(listOfBoxes, new Box<double>(comparingElement));

            Console.WriteLine(res);
        }

        public static int CompareMethod<T>(List<T> listOfBoxes, T element)
            where T: IComparable<T>
         => listOfBoxes.Count(b => b.CompareTo(element) > 0);
        //{
        //    int result = listOfBoxes.Count(b => b.CompareTo(element) > 0);
        //    return result;
        //} 
        

        //public static int CompareMethod<T>(List<Box<T>> listOfBoxes, T element)
        //    where T : IComparable<T>
        //{
        //    int result = listOfBoxes.Count(x => x.Item.CompareTo(element) > 0);
        //    return result;
        //}
    }
}
