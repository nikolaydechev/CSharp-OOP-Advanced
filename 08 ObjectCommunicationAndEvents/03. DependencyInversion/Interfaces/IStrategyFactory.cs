namespace _03.DependencyInversion.Interfaces
{
    public interface IStrategyFactory
    {
        IStrategy Create(string strategyName);
    }
}
