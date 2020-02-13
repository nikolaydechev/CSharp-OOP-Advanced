namespace _11.InfernoInfinity.Entities.Gems
{
    public class Ruby : Gem
    {
        public Ruby(string typeClarity)
        {
            this.Strength = 7;
            this.Agility = 2;
            this.Vitality = 5;
            AddStatsByClarity(typeClarity);
        }
    }
}
