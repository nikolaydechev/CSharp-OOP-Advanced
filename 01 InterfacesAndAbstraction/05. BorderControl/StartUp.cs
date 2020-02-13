using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfPeople = new List<IBuyer>();
            int totalAmountOfFood = 0;
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (inputArgs.Length)
                {
                    case 4:
                        listOfPeople.Add(new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3]));
                        break;

                    case 3:
                        listOfPeople.Add(new Rebel(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));
                        break;

                    default: break;
                }
            }

            var listOfBuyers = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                listOfBuyers.Add(input);
            }


            foreach (var buyerName in listOfBuyers)
            {
                var person = listOfPeople.FirstOrDefault(x => x.Name == buyerName);
                if (person != null && person.GetType().Name.Equals("Citizen"))
                {
                    totalAmountOfFood += 10;
                }
                else if (person != null && person.GetType().Name.Equals("Rebel"))
                {
                    totalAmountOfFood += 5;
                }
            }

            Console.WriteLine(totalAmountOfFood);
        }
    }
}
