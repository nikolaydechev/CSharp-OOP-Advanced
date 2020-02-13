namespace _03.DependencyInversion.Core
{
    using System;
    using _03.DependencyInversion.Interfaces;
    using _03.DependencyInversion.Interfaces.IO;

    public class Engine : IRunnable
    {
        private const string TerminatingCommand = "End";

        private IReader reader;
        private IWriter writer;
        private PrimitiveCalculator primitiveCalculator;

        public Engine(PrimitiveCalculator primitiveCalculator, IReader reader, IWriter writer)
        {
            this.primitiveCalculator = primitiveCalculator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string inputLine;
            while ((inputLine = this.reader.ReadLine()) != TerminatingCommand)
            {
                var commandArgs = inputLine.Split(' ');
                if (commandArgs[0] == "mode")
                {
                    char operand = Convert.ToChar(commandArgs[1]);
                    IStrategy strategy = this.primitiveCalculator.StrategyFactory.Create(this.StrategyName(operand));
                    this.primitiveCalculator.ChangeStrategy(strategy);
                }
                else
                {
                    this.writer.WriteLine(
                        this.primitiveCalculator.PerformCalculation(int.Parse(commandArgs[0]),
                                                                    int.Parse(commandArgs[1])).ToString());
                }
            }
        }

        private string StrategyName(char @operand)
        {
            switch (@operand)
            {
                case '+': return "Addition";
                case '-': return "Subtraction";
                case '/': return "Division";
                default: return "Multiplication";
            }
        }
    }
}
