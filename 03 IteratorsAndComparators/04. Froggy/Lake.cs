using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private IList<int> stoneNumbers;

        public Lake(params int[] stoneNumbers)
        {
            this.stoneNumbers = new List<int>(stoneNumbers);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stoneNumbers.Count; i += 2)
            {
                yield return this.stoneNumbers[i];
            }
            
            switch (this.stoneNumbers.Count % 2 == 0)
            {
                case true:
                    for (int i = this.stoneNumbers.Count - 1; i > 0; i-=2)
                    {
                        yield return this.stoneNumbers[i];
                    }
                    break;

                case false:
                    for (int i = this.stoneNumbers.Count - 2; i > 0; i-=2)
                    {
                        yield return this.stoneNumbers[i];
                    }
                    break;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
