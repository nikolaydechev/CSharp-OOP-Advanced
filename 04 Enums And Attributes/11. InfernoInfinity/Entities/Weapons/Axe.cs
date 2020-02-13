namespace _11.InfernoInfinity.Entities.Weapons
{
    using _11.InfernoInfinity.Entities.Gems;

    public class Axe : Weapon
    {
        public Axe(string weaponType, string weaponName)
            : base(weaponType, weaponName)
        {
            this.MinimumDamage = 5;
            this.MaximumDamage = 10;
            this.Sockets = new IGem[4];
            LevelOfRarity(this.WeaponType);
        }
    }
}
