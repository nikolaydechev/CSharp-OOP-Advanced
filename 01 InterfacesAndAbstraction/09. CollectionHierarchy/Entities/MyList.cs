using System.Collections.Generic;
using _09.CollectionHierarchy.Interfaces;

namespace _09.CollectionHierarchy.Entities
{
    public class MyList : IMyList
    {
        public IList<string> ListAddCollection { get; }

        public MyList()
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
            string firstElement = this.ListAddCollection[0];
            this.ListAddCollection.RemoveAt(0);
            return firstElement;
        }
    }
}
