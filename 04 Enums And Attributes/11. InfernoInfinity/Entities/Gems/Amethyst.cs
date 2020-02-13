namespace _11.InfernoInfinity.Entities.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(string typeClarity)
        {
            this.Strength = 2;
            this.Agility = 8;
            this.Vitality = 4;
            AddStatsByClarity(typeClarity);
        }
    }
}
