using System;

namespace _07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; }

        public int Age { get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(((Person)obj).Name) && this.Age.Equals(((Person)obj).Age);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var nameComparison = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return Age.CompareTo(other.Age);
        }
    }
}
