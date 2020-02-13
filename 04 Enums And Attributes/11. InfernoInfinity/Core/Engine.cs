namespace _11.InfernoInfinity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _11.InfernoInfinity.Entities.Gems;
    using _11.InfernoInfinity.Entities.Weapons;

    public class Engine
    {
        //private MagicalStats magicalStats;
        private IList<IWeapon> weapons;
        private string[] input;

        public Engine()
        {
            //this.magicalStats = new MagicalStats();
            this.weapons = new List<IWeapon>();
        }

        public IList<IWeapon> Weapons { get { return this.weapons; } }

        public void Run()
        {
            while (true)
            {
                this.input = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "END") break;

                var command = this.input[0];

                switch (command)
                {
                    case "Create":
                        var levelType = string.Join("", input[1].Split().Take(1));
                        var typeOfWeapon = string.Join("", input[1].Split().Skip(1));

                        this.Weapons.Add(WeaponsFactory.CreateNewWeapon(levelType, typeOfWeapon, input[2]));
                        break;

                    case "Add":
                        var weaponName = input[1];
                        var socketIndex = int.Parse(input[2]);
                        var gemType = string.Join("", input[3].Split().Skip(1));
                        var gemClarity = string.Join("", input[3].Split().Take(1));
                        var currentWeapon = this.Weapons.First(x => x.WeaponName == weaponName);
                        var currentGem = GemsFactory.MakeNewGem(gemClarity, gemType);

                        currentWeapon.AddGem(currentGem, socketIndex);//, this.magicalStats);
                        break;

                    case "Remove":
                        weaponName = input[1];
                        socketIndex = int.Parse(input[2]);
                        currentWeapon = this.Weapons.First(x => x.WeaponName == weaponName);

                        currentWeapon.RemoveGem(socketIndex);//, this.magicalStats);
                        break;

                    case "Print":
                        foreach (var weapon in this.Weapons.Where(x => x.WeaponName == input[1]))
                        {
                            Console.Write(weapon);
                            //Console.WriteLine(this.magicalStats);
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }
    }
}
