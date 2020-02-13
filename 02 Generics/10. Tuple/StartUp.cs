using System;
using System.Linq;

namespace _10.Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            var tokens = GetTokens();
            var name = string.Join(" ", tokens.Take(2));
            var address = string.Join(" ", tokens.Skip(2).Take(1));
            var town = string.Join(" ", tokens.Skip(3).Take(1));

            var tuple = new Tuple<string, string, string>(name, address, town);
            Print(tuple);

            tokens = GetTokens();
            var tuple1 = new Tuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), tokens[2] == "drunk");
            Print(tuple1);

            tokens = GetTokens();
            var tuple2 = new Tuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);
            Print(tuple2);
        }

        public static string[] GetTokens()
        {
            return Console.ReadLine().Split(' ');
        }

        public static void Print<T, U, V>(Tuple<T, U, V> tuple)
        {
            Console.WriteLine(tuple);
        }
    }
}
