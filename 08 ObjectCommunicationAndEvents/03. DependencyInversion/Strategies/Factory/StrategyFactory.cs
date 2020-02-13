namespace _03.DependencyInversion.Strategies.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03.DependencyInversion.Interfaces;

    public class StrategyFactory : IStrategyFactory
    {
        private const string StrategyNameSuffix = "Strategy";

        public IStrategy Create(string strategyName)
        {
            string strategyCompleteName = strategyName + StrategyNameSuffix;

            Type strategyType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == strategyCompleteName);

            return (IStrategy)Activator.CreateInstance(strategyType);
        }
    }
}
