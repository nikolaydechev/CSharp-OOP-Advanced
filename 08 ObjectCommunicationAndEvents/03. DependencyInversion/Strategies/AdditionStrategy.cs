namespace _03.DependencyInversion.Strategies
{
    using _03.DependencyInversion.Interfaces;

    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
