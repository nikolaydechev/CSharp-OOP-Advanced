using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09.LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private IList<T> linkedList;

        public LinkedList(params T[] args)
        {
            this.linkedList = new List<T>(args);
        }

        public int Count => this.linkedList.Count;

        public void AddLast(T element)
        {
            this.linkedList.Add(element);
        }

        public bool Remove(T number)
        {
            var numberToRemove = this.linkedList.FirstOrDefault(x => x.Equals(number));
            if (numberToRemove == null)
            {
                return false;
            }
            this.linkedList.Remove(numberToRemove);
            return true;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.linkedList)
            {
                yield return element;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
