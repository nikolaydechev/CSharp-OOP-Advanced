namespace _05.BorderControl
{
    public interface IBuyer : IAlive
    {
        int Food { get; set; }

        void BuyFood();
    }
}
