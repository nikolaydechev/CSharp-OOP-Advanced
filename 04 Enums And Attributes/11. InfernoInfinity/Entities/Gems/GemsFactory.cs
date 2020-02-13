namespace _11.InfernoInfinity.Entities.Gems
{
    public class GemsFactory
    {
        public static IGem MakeNewGem(string typeClarity, string gemType)
        {
            switch (gemType)
            {
                case "Ruby":
                    return new Ruby(typeClarity);
                case "Amethyst":
                    return new Amethyst(typeClarity);
                //case "Emerald":
                default:
                    return new Emerald(typeClarity);
            }
        }
    }
}
