namespace _05.BorderControl
{
    public class Citizen : IInhabitant, IBuyer
    {

        public string Name { get; }
        public int Age { get;  }
        public string BirthDate { get; }
        public string Id { get; }

        public Citizen(string name,int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
        }

        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
