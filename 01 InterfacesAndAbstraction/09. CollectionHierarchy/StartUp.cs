using System;
using System.Collections.Generic;
using _09.CollectionHierarchy.Entities;
using _09.CollectionHierarchy.Interfaces;

namespace _09.CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            var result = new List<string>();

            IListCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myListCollection = new MyList();

            var listOfCollections = new List<IListCollection>() { addCollection, addRemoveCollection, myListCollection };

            var data = Console.ReadLine().Split(' ');

            for (int i = 0; i < 3; i++)
            {
                string addedIndexes = "";
                foreach (var @string in data)
                {
                    int index = listOfCollections[i].Add(@string);
                    addedIndexes += index.ToString() + " ";
                }
                result.Add(addedIndexes.Trim());
            }

            var removingOperationsCount = int.Parse(Console.ReadLine());

            string lineRemovedInfo = "";
            for (int i = 0; i < removingOperationsCount; i++)
            {
                lineRemovedInfo += addRemoveCollection.Remove() + " ";
            }
            result.Add(lineRemovedInfo.Trim());

            lineRemovedInfo = "";
            for (int i = 0; i < removingOperationsCount; i++)
            {
                lineRemovedInfo += myListCollection.Remove() + " ";
            }
            result.Add(lineRemovedInfo.Trim());


            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}
