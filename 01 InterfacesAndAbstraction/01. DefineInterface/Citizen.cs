namespace _01.DefineInterface
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
