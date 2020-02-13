using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class StackCollection<T> : IEnumerable<T>
    {
        private IList<T> elements;

        public StackCollection(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public void Push(T[] items)
        {
            foreach (var item in items)
            {
                this.elements.Add(item);
            }
        }

        public void Pop()
        {
            if (this.elements.Count > 0)
            {
                this.elements.RemoveAt(this.elements.Count - 1);
            }
            else
            {
                throw new ArgumentException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}