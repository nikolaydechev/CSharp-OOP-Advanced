namespace _02.Blobs.Entities.Attacks.Factory
{
    using _02.Blobs.Interfaces;

    public abstract class CreateAttack
    {
        public abstract IAttack ProduceAttack(string attackType);
    }
}
