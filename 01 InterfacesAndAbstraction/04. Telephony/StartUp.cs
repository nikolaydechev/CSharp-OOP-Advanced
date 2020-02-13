using System;

namespace _04.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var phone = new Smartphone();

            var numbers = Console.ReadLine().Split(' ');
            var websites = Console.ReadLine().Split(' ');

            foreach (var number in numbers)
            {
                Console.WriteLine(phone.Call(number));
            }
            foreach (var website in websites)
            {
                Console.WriteLine(phone.Browse(website));
            }
        }
    }
}
