namespace _03.DependencyInversion.Strategies
{
    using _03.DependencyInversion.Interfaces;

    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
