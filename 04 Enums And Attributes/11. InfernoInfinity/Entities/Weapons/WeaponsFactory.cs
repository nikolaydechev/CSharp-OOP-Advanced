namespace _11.InfernoInfinity.Entities.Weapons
{
    public class WeaponsFactory
    {
        public static IWeapon CreateNewWeapon(string levelType, string typeOfWeapon, string weaponName)
        {
            if (typeOfWeapon == "Axe")
            {
                return new Axe(levelType, weaponName);
            }
            else if (typeOfWeapon == "Sword")
            {
                return new Sword(levelType, weaponName);
            }
            else
            {
                return new Knife(levelType, weaponName);
            }
        }
    }
}
