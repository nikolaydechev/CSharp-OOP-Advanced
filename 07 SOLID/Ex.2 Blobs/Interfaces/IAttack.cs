namespace _02.Blobs.Interfaces
{
    using _02.Blobs.Entities;

    public interface IAttack
    {
        void Execute(Blob attacker, Blob target);
    }
}