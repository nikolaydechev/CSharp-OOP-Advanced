namespace Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using _02.ListIterator;

    [TestFixture]
    public class ListIteratorTests
    {
        private ListIterator sut;

        [SetUp]
        public void TestUnit()
        {
            this.sut = new ListIterator(new List<string>() { "Pesho", "Gosho", "Acho" });
        }

        [Test]
        public void CreateListIteratorWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>((() => this.sut = new ListIterator(null)));
        }

        [Test]
        public void MoveIsPossible()
        {
            for (int i = 0; i < 2; i++)
            {
                bool result = this.sut.Move();

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void MoveIsNotPossible()
        {
            this.sut.Move();
            this.sut.Move();
            bool result = this.sut.Move();

            Assert.IsFalse(result);
        }

        [Test]
        public void MoveIsNotPossibleWithEmptyList()
        {
            this.sut = new ListIterator(new List<string>());

            bool result = this.sut.Move();

            Assert.IsFalse(result);
        }

        [Test]
        public void PrintLastElement()
        {
            this.sut.Move();
            this.sut.Move();

            var result = this.sut.Print();

            Assert.AreEqual("Acho", result);
        }

        [Test]
        public void PrintFirstElement()
        {
            string result = this.sut.Print();

            Assert.AreEqual("Pesho", result);
        }

        [Test]
        public void PrintWithEmptyListThrowsException()
        {
            this.sut = new ListIterator(new List<string>());

            Assert.Throws<InvalidOperationException>(() => this.sut.Print());
        }

        [Test]
        public void ListHasNextElement()
        {
            Assert.IsTrue(this.sut.HasNext());
        }

        [Test]
        public void ListDoesNotHaveNextElement()
        {
            this.sut.Move();
            this.sut.Move();

            Assert.IsFalse(this.sut.HasNext());
        }

        [Test]
        public void EmptyListDoesNotHaveNextElement()
        {
            this.sut = new ListIterator(new List<string>());

            Assert.False(this.sut.HasNext());
        }
    }
}