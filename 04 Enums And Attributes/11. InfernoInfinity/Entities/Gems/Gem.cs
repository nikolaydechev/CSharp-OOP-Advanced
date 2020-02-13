namespace _11.InfernoInfinity.Entities.Gems
{
    using _11.InfernoInfinity.Enums;

    public abstract class Gem : IGem
    {
        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public void AddStatsByClarity(string gemClarity)
        {
            switch (gemClarity)
            {
                case "Chipped":
                    AddStats(Clarity.Chipped);
                    break;
                case "Regular":
                    AddStats(Clarity.Regular);
                    break;
                case "Perfect":
                    AddStats(Clarity.Perfect);
                    break;
                case "Flawless":
                    AddStats(Clarity.Flawless);
                    break;
            }
        }

        private void AddStats(Clarity type)
        {
            this.Strength += (int)type;
            this.Agility += (int)type;
            this.Vitality += (int)type;
        }
    }
}
