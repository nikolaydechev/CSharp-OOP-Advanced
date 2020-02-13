using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        private List<T> elements;

        public ListyIterator(params T[] elements)
        {
            this.currentIndex = 0;
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            if ((this.currentIndex + 1) < this.elements.Count)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if ((this.currentIndex + 1) <this.elements.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.elements.Count < 1)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.elements[this.currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
