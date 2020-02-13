namespace _11.InfernoInfinity.Entities.Weapons
{
    using System.Text;
    using _11.InfernoInfinity.Core;
    using _11.InfernoInfinity.Entities.Gems;
    using _11.InfernoInfinity.Enums;

    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private int minimumDamage;
        private int maximumDamage;
        private string weaponType;

        protected Weapon(string weaponType, string weaponName)
        {
            this.MinimumDamage = minimumDamage;
            this.MaximumDamage = maximumDamage;
            this.WeaponType = weaponType;
            this.WeaponName = weaponName;
        }

        public string WeaponName { get; }

        public IGem[] Sockets { get; protected set; }

        public int MinimumDamage { get { return this.minimumDamage; } protected set { this.minimumDamage = value; } }

        public int MaximumDamage { get { return this.maximumDamage; } protected set { this.maximumDamage = value; } }

        public string WeaponType { get { return this.weaponType; } protected set { this.weaponType = value; } }


        public void LevelOfRarity(string levelType)
        {
            switch (levelType)
            {
                case "Common":
                    AddDamage(Rarity.Common);
                    break;
                case "Uncommon":
                    AddDamage(Rarity.Uncommon);
                    break;
                case "Rare":
                    AddDamage(Rarity.Rare);
                    break;
                case "Epic":
                    AddDamage(Rarity.Epic);
                    break;
            }
        }

        private void AddDamage(Rarity rarityType)
        {
            this.MinimumDamage *= (int)rarityType;
            this.MaximumDamage *= (int)rarityType;
        }

        public void AddGem(IGem gem, int socketIndex)
        {
            if (socketIndex < 0 || socketIndex >= this.Sockets.Length) return;

            if (this.Sockets[socketIndex] == null)
            {
                this.Sockets[socketIndex] = gem;

                AddAdditionalDamage(gem);
                //magicalStats.IncreaseStats(gem);
            }
            else
            {
                var currentGem = this.Sockets[socketIndex];

                ClearAdditionalDamage(currentGem);
                // magicalStats.DecreaseStats(currentGem);

                this.Sockets[socketIndex] = gem;
                AddAdditionalDamage(gem);
                //magicalStats.IncreaseStats(gem);
            }
        }

        public void RemoveGem(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex >= this.Sockets.Length) return;
            if (this.Sockets[socketIndex] == null) return;

            var currentGem = this.Sockets[socketIndex];

            //magicalStats.DecreaseStats(currentGem);
            ClearAdditionalDamage(currentGem);

            this.Sockets[socketIndex] = null;
        }

        public void ClearAdditionalDamage(IGem gem)
        {
            this.MaximumDamage -= gem.Strength * 3 + gem.Agility * 4;
            this.MinimumDamage -= gem.Strength * 2 + gem.Agility * 1;
        }

        public void AddAdditionalDamage(IGem gem)
        {
            this.MaximumDamage += gem.Strength * 3 + gem.Agility * 4;
            this.MinimumDamage += gem.Strength * 2 + gem.Agility * 1;
        }

        public override string ToString()
        {
            var str = 0;
            var agi = 0;
            var vit = 0;

            foreach (var socket in this.Sockets)
            {
                if (socket != null)
                {
                    str += socket.Strength;
                    agi += socket.Agility;
                    vit += socket.Vitality;
                }
            }

            var sb = new StringBuilder();

            sb.Append($"{this.WeaponName}: {this.MinimumDamage}-{this.MaximumDamage} Damage, ");
            sb.Append($"+{str} Strength, ");
            sb.Append($"+{agi} Agility, ");
            sb.AppendLine($"+{vit} Vitality");

            return sb.ToString().Trim();
        }
    }
}
