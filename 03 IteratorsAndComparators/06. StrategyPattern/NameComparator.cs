using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var comparing = x.Name.Length.CompareTo(y.Name.Length);
            if (comparing == 0)
            {
                comparing = x.Name.CompareTo(y.Name);
            }
            return comparing;
        }
    }
}
