namespace _11.InfernoInfinity.Entities.Weapons
{
    using _11.InfernoInfinity.Entities.Gems;

    public class Knife : Weapon
    {
        public Knife(string weaponType, string weaponName)
            : base(weaponType, weaponName)
        {
            this.MinimumDamage = 3;
            this.MaximumDamage = 4;
            this.Sockets = new IGem[2];
            LevelOfRarity(this.WeaponType);
        }
    }
}
