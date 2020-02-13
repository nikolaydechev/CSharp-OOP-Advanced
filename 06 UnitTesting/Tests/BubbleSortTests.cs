namespace Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using _03.BubbleSort;

    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void CreateBubbleList()
        {
            Bubble bubble = new Bubble();
            var sortedList = bubble.Sort(new List<int>() { 7, 8, 1, 6 });
            IList<int> numbers = new List<int>() { 1, 6, 7, 8 };

            CollectionAssert.AreEqual(sortedList, numbers);
        }

        [Test]
        public void SortOneItemList()
        {
            Bubble bubble = new Bubble();
            var list = bubble.Sort(new List<int>() { 10 });
            IList<int> numbers = new List<int>() { 10 };

            CollectionAssert.AreEqual(list, numbers);
        }
    }
}
