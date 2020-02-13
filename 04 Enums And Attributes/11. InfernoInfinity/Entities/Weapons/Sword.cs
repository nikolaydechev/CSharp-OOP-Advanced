namespace _11.InfernoInfinity.Entities.Weapons
{
    using _11.InfernoInfinity.Entities.Gems;

    public class Sword : Weapon
    {
        public Sword(string weaponType, string weaponName)
            : base(weaponType, weaponName)
        {
            this.MinimumDamage = 4;
            this.MaximumDamage = 6;
            this.Sockets = new IGem[3];
            LevelOfRarity(this.WeaponType);
        }
    }
}
