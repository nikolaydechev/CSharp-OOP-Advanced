using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfPeople = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personInfo = input.Split(' ');
                listOfPeople.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
            }
            //listOfPeople.Sort(...);

            var N = int.Parse(Console.ReadLine());
            var comparedPerson = listOfPeople.ElementAt(N - 1);

            int numberOfEqualPeople = listOfPeople.Count(x => x.Name == comparedPerson.Name &&
                                                              x.Age == comparedPerson.Age &&
                                                              x.Town == comparedPerson.Town);

            int numberOfNotEqualPeople = listOfPeople.Count(x => x.Name != comparedPerson.Name ||
                                                                 x.Age != comparedPerson.Age ||
                                                                 x.Town != comparedPerson.Town);

            Console.WriteLine(numberOfEqualPeople < 2
                ? "No matches"
                : $"{numberOfEqualPeople} {numberOfNotEqualPeople} {listOfPeople.Count}");
        }
    }
}
