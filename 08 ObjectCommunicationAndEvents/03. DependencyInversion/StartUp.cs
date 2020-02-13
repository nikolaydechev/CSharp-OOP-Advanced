namespace _03.DependencyInversion
{
    using _03.DependencyInversion.Core;
    using _03.DependencyInversion.Core.IO;
    using _03.DependencyInversion.Interfaces;
    using _03.DependencyInversion.Interfaces.IO;
    using _03.DependencyInversion.Strategies;
    using _03.DependencyInversion.Strategies.Factory;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStrategy additionStrategy = new AdditionStrategy();
            IStrategyFactory factory = new StrategyFactory();
            PrimitiveCalculator calculator = new PrimitiveCalculator(additionStrategy, factory);

            IRunnable engine = new Engine(calculator, reader, writer);
            engine.Run();
        }
    }
}
