namespace _05.BorderControl
{
    public class Rebel : IBuyer
    {
        private string group;

        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public string Name { get;  }
        public int Age { get;  }
        public string BirthDate { get; }
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
            this.Group = group;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
