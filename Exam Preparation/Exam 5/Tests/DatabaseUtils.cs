namespace Tests
{
    using System.Collections.Generic;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Type;

    public static class DatabaseUtils
    {
        public static IDataProvider CreateDataProvider()
        {
            IDictionary<string, IShop> shops = new Dictionary<string, IShop>();
            IShop mall = new Mall(null);
            IShop bazaar = new Bazaar(mall);
            IShop store = new Store(bazaar);
            shops.Add("Mall", mall);
            shops.Add("Bazaar", bazaar);
            shops.Add("Store", store);
            var dataProvider = new MarketDataProvider(shops, new TypeProvider(typeof(IShop).Assembly));
            return dataProvider;
        }
    }
}
