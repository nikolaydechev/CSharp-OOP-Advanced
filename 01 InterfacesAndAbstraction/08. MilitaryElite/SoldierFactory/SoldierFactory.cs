using _08.MilitaryElite.Models;

namespace _08.MilitaryElite.SoldierFactory
{
    public class SoldierFactory
    {
        private SoldierFactory() { }

        public static Private Private(string id, string firstName, string lastName, double salary)
        {
            return new Private(id, firstName, lastName, salary);
        }

        public static LeutenantGeneral LeutenantGeneral(string id, string firstName, string lastName, double salary)
        {
            return new LeutenantGeneral(id, firstName, lastName, salary);
        }

        public static Engineer Engineer(string id, string firstName, string lastName, double salary, string corps)
        {
            return new Engineer(id, firstName, lastName, salary, corps);
        }

        public static Commando Commando(string id, string firstName, string lastName, double salary, string corps)
        {
            return new Commando(id, firstName, lastName, salary, corps);
        }

        public static Spy Spy(string id, string firstName, string lastName, int codeNumber)
        {
            return new Spy(id, firstName, lastName, codeNumber);
        }
    }
}
