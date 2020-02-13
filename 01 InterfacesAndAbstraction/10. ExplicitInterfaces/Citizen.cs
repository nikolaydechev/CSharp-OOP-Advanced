namespace _10.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
