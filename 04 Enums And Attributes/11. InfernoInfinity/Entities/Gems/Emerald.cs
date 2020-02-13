namespace _11.InfernoInfinity.Entities.Gems
{
    public class Emerald : Gem
    {
        public Emerald(string typeClarity)
        {
            this.Strength = 1;
            this.Agility = 4;
            this.Vitality = 9;
            AddStatsByClarity(typeClarity);
        }
    }
}
