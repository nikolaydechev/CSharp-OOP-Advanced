using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.CustomList
{
    public class GenericDataStructure<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private IList<T> collection;

        public GenericDataStructure()
        {
            this.Collection = new List<T>();
        }
        
        public IList<T> Collection
        {
            get { return this.collection; }
            set { this.collection = value; }
        }

        public void Add(T element)
        {
            this.Collection.Add(element);
        }

        public T Remove(int index)
        {
            return this.Collection[index];
        }

        public bool Contains(T element)
        {
            return this.Collection.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var temp = this.Collection[index1];
            this.Collection[index1] = this.Collection[index2];
            this.Collection[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            return this.Collection.Count(x => x.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.Collection.Max();
        }

        public T Min()
        {
            return this.Collection.Min();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }
    }
}
