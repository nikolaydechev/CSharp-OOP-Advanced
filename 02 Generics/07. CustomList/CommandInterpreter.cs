using System;
using System.Linq;

namespace _07.CustomList
{
    public class CommandInterpreter
    {
        private bool dataRead;
        private GenericDataStructure<string> dataStructure;

        public CommandInterpreter(GenericDataStructure<string> dataStructure)
        {
            this.dataStructure = dataStructure;
            this.dataRead = false;
        }

        public void ExecuteCommand()
        {
            while (!dataRead)
            {
                var inputData = Console.ReadLine().Split(' ').ToList();

                switch (inputData[0])
                {
                    case "Add":
                        this.dataStructure.Add(inputData[1]);
                        break;
                    case "Remove":
                        var elementToRemove = this.dataStructure.Remove(int.Parse(inputData[1]));
                        this.dataStructure.Collection.Remove(elementToRemove);
                        break;
                    case "Contains":
                        Console.WriteLine(this.dataStructure.Contains(inputData[1]));
                        break;
                    case "Swap":
                        this.dataStructure.Swap(int.Parse(inputData[1]), int.Parse(inputData[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(this.dataStructure.CountGreaterThan(inputData[1]));
                        break;
                    case "Max":
                        Console.WriteLine(this.dataStructure.Max());
                        break;
                    case "Min":
                        Console.WriteLine(this.dataStructure.Min());
                        break;
                    case "Print":
                        Console.WriteLine(string.Join("\r\n", this.dataStructure.Collection));
                        break;
                    case "Sort":
                        this.dataStructure.Collection = Sorter.Sort(this.dataStructure.Collection);
                        break;
                    case "END":
                        dataRead = true;
                        break;
                }
            }
        }
    }
}
