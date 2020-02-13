namespace _03.DependencyInversion.Strategies
{
    using _03.DependencyInversion.Interfaces;

    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
