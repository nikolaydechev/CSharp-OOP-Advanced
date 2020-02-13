namespace _02.KingsGambit.Interfaces
{
    public interface IKillable
    {
        bool IsAlive { get; }

        void Kill();
    }
}
