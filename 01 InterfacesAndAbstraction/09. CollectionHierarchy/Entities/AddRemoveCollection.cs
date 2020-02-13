using System.Collections.Generic;
using _09.CollectionHierarchy.Interfaces;

namespace _09.CollectionHierarchy.Entities
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public IList<string> ListAddCollection { get; }

        public AddRemoveCollection()
        {
            this.ListAddCollection = new List<string>(100);
        }

        public int Add(string data)
        {
            this.ListAddCollection.Insert(0, data);
            return 0;
        }

        public string Remove()
        {
            string lastElement = this.ListAddCollection[this.ListAddCollection.Count - 1];
            this.ListAddCollection.RemoveAt(this.ListAddCollection.Count - 1);
            return lastElement;
        }
    }
}
