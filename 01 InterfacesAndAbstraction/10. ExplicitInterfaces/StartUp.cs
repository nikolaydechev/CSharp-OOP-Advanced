using System;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfPeople = new List<Citizen>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var citizen = new Citizen(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]));
                listOfPeople.Add(citizen);
            }

            foreach (var citizen in listOfPeople)
            {
                var person = (IPerson)citizen;
                Console.WriteLine(person.GetName());
                var resident = (IResident)citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
