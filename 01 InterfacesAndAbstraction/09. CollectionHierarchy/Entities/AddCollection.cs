using System.Collections.Generic;
using _09.CollectionHierarchy.Interfaces;

namespace _09.CollectionHierarchy.Entities
{
    public class AddCollection : IListCollection
    {
        public IList<string> ListAddCollection { get; }
        
        public AddCollection()
        {
            this.ListAddCollection = new List<string>(100);
        }

        public int Add(string data)
        {
            this.ListAddCollection.Add(data);
            var index = this.ListAddCollection.Count - 1;
            return index;
        }
    }
}
