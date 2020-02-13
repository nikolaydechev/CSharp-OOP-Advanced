namespace _05.BorderControl
{
    public class Pet : IAlive
    {
        public string Name { get; }
        public int Age { get; }
        public string BirthDate { get; }

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}
