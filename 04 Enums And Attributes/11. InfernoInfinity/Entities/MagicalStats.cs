using _11.InfernoInfinity.Entities.Gems;

namespace _11.InfernoInfinity.Entities
{
    public class MagicalStats
    {
        public MagicalStats()
        {
            this.TotalStrength = 0;
            this.TotalAgility = 0;
            this.TotalVitality = 0;
        }

        public int TotalStrength { get; set; }

        public int TotalAgility { get; set; }

        public int TotalVitality { get; set; }

        public void IncreaseStats(IGem gem)
        {
            this.TotalStrength += gem.Strength;
            this.TotalAgility += gem.Agility;
            this.TotalVitality += gem.Vitality;
        }

        public void DecreaseStats(IGem gem)
        {
            this.TotalStrength -= gem.Strength;
            this.TotalAgility -= gem.Agility;
            this.TotalVitality -= gem.Vitality;
        }

        public override string ToString()
        {
            return
                $"+{this.TotalStrength} Strength, +{this.TotalAgility} Agility, +{this.TotalVitality} Vitality";
        }
    }
}
