namespace BashSoftTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            //this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            //// Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            //// Assert
            string previous = this.names.First();

            foreach (var name in this.names)
            {
                if (name != previous)
                {
                    Assert.IsTrue(string.Compare(
                        previous, name, StringComparison.Ordinal) < 0);
                }

                previous = name;
            }
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            //// Arrange
            string element = "Element";

            //// Act
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(element);
            }

            //// Assert
            Assert.AreEqual(this.names.Size, 17);
            Assert.AreNotEqual(this.names.Capacity, 16);
        }


        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            //// Arrange
            var list = new List<string>() { "Gosho", "Pesho" };

            //// Act
            this.names.AddAll(list);

            //// Assert
            Assert.AreEqual(this.names.Size, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            //// Act
            this.names.AddAll(null);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            //// Arrange
            var list = new List<string>() { "Gosho", "Pesho", "Acho" };

            //// Act
            this.names.AddAll(list);

            //// Assert
            string previous = this.names.First();

            foreach (var name in this.names)
            {
                if (name != previous)
                {
                    Assert.IsTrue(string.Compare(
                                      previous, name, StringComparison.Ordinal) < 0);
                }

                previous = name;
            }
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            //// Arrange
            this.names.Add("Pesho");
            this.names.Add("Gosho");

            //// Act
            this.names.Remove("Pesho");

            //// Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            //// Arrange
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            //// Act
            this.names.Remove("Ivan");

            //// Assert
            foreach (var name in this.names)
            {
                Assert.AreNotEqual(name, "Ivan");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            //// Act
            this.names.Remove(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            //// Act
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            //// Arrange
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            //// Act
            string result = this.names.JoinWith(", ");

            //// Assert
            Assert.AreEqual(result, "Ivan, Nasko");
        }
    }
}
