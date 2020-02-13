namespace _03.DependencyInversion.Core
{
    using System.Security.AccessControl;
    using _03.DependencyInversion.Interfaces;

    public class PrimitiveCalculator
    {
        public PrimitiveCalculator(IStrategy strategy, IStrategyFactory strategyFactory)
        {
            this.Strategy = strategy;
            this.StrategyFactory = strategyFactory;
        }

        public IStrategyFactory StrategyFactory { get; }

        public IStrategy Strategy { get; set; }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.Strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
