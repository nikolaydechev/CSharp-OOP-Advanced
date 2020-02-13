namespace _11.InfernoInfinity.Entities.Weapons
{
    using _11.InfernoInfinity.Entities.Gems;

    public interface IWeapon
    {
        int MinimumDamage { get; }

        int MaximumDamage { get; }

        string WeaponName { get; }

        IGem[] Sockets { get; }

        void AddGem(IGem gem, int socketIndex);//, MagicalStats magicalStats);

        void RemoveGem(int socketIndex); //, MagicalStats magicalStats);
    }
}
