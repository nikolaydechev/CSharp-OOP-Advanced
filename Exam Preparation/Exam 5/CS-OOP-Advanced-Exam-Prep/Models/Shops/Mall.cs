namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using Framework.Lifecycle.Order;

    [Order(1)]
    public class Mall : Shop
    {
        private const int Capacity = int.MaxValue;

        public Mall(IShop successor) : base(successor, Capacity)
        {
        }
    }
}
