namespace _02.KingsGambit.Models
{
    using _02.KingsGambit.Interfaces;

    public abstract class Person : IPerson
    {
        protected Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
