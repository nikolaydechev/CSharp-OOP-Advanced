using System.Collections.Generic;

namespace _09.CollectionHierarchy.Interfaces
{
    public interface IListCollection
    {
        IList<string> ListAddCollection { get; }

        int Add(string data);
    }
}
