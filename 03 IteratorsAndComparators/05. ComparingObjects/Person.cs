using System;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        
        public int CompareTo(Person other)
        {
            int comparing = this.Name.CompareTo(other.Name);
            if (comparing == 0)
            {
                comparing = this.Age.CompareTo(other.Age);
                if (comparing == 0)
                {
                    comparing = this.Town.CompareTo(other.Town);
                }
            }
            return comparing;
        }
    }
}
