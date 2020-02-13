namespace CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Constants;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Order;
    using Models.Products;
    using Models.Shops;
    using Type;

    [Component]
    public class MarketDataProvider : IDataProvider
    {
        private readonly IDictionary<int, IProduct> productById;

        private readonly IDictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>>
            productsBySizeNameType;

        private readonly IDictionary<int, IDictionary<string, ISet<IProduct>>>
           productsBySizeName;

        private readonly IDictionary<string, IShop> shops;

        [Inject]
        private ITypeProvider typeProvider;

        public MarketDataProvider()
        {
            this.productById = new Dictionary<int, IProduct>();
            this.productsBySizeName = new Dictionary<int, IDictionary<string, ISet<IProduct>>>();
            this.productsBySizeNameType = new Dictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>>();
            this.shops = new Dictionary<string, IShop>();
        }

        public MarketDataProvider(IDictionary<string, IShop> shops, ITypeProvider typeProvider) : this()
        {
            this.shops = shops;
            this.typeProvider = typeProvider;
        }



        public IProduct AddProduct(int size, string name, string type)
        {
            Type currentProductType = this.typeProvider.GetSubClasses(typeof(IProduct))
                .FirstOrDefault(c => c.Name == type);

            int productId = this.productById.Count + 1;

            IProduct product = (IProduct) Activator.CreateInstance(currentProductType, productId, name, size);

            this.productById[productId] = product;

            this.AddProducToNestedStructures(type, product);

            return product;
        }

        public IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type)
        {
            if (!this.productsBySizeNameType.ContainsKey(size))
            {
                return null;
            }

            if (!this.productsBySizeNameType[size].ContainsKey(name))
            {
                return null;
            }

            if (!this.productsBySizeNameType[size][name].ContainsKey(type))
            {
                return null;
            }

            return this.productsBySizeNameType[size][name][type];
        }

        public IEnumerable<IProduct> GetProductsBySizeName(int size, string name)
        {
            if (!this.productsBySizeName.ContainsKey(size))
            {
                return null;
            }

            if (!this.productsBySizeName[size].ContainsKey(name))
            {
                return null;
            }

            return this.productsBySizeName[size][name];
        }

        public IProduct GetProductById(int id)
        {
            IProduct product;
            this.productById.TryGetValue(id, out product);

            return product;
        }

        public IProduct EditProduct(int id, int newSize, string newName)
        {
            IProduct product = this.GetProductById(id);
            if (product == null)
            {
                return null;
            }

            this.productsBySizeName[product.Size][product.Name].Remove(product);
            this.productsBySizeNameType[product.Size][product.Name][product.GetType().Name].Remove(product);

            product.Size = newSize;
            product.Name = newName;

            this.AddProducToNestedStructures(product.GetType().Name, product);

            return product;
        }

        public IShop AddProductToShop(string shopType, int productId)
        {
            IProduct product = this.GetProductById(productId);
            if (product == null)
            {
                return null;
            }

            if (product.Shop != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Messages.ProductAlreadyInShop,
                        productId,
                        product.Shop.GetType().Name
                        )
                    );
            }

            IShop shop = this.shops[shopType];
            product.Shop = shop;

            return shop.AddProduct(product);
        }

        public IEnumerable<IProduct> GetProductByShop(string shopType)
        {
            return this.shops[shopType].Products;
        }

        private void Initialize()
        {
            IEnumerable<Type> shopTypes
                = this.typeProvider.GetClassesByAttribute(typeof(OrderAttribute))
                    .Where(c => typeof(IShop).IsAssignableFrom(c))
                    .OrderBy(c => c.GetCustomAttribute<OrderAttribute>().Order);

            IShop successor = null;

            foreach (Type shopType in shopTypes)
            {
                IShop shop = (IShop)Activator.CreateInstance(shopType, successor);
                this.shops.Add(shopType.Name, shop);
                successor = shop;
            }
        }


        private void AddProducToNestedStructures(string type, IProduct product)
        {
            if (!this.productsBySizeName.ContainsKey(product.Size))
            {
                this.productsBySizeName[product.Size] = new Dictionary<string, ISet<IProduct>>();
                this.productsBySizeNameType[product.Size] = new Dictionary<string, IDictionary<string, ISet<IProduct>>>();
            }

            if (!this.productsBySizeName[product.Size].ContainsKey(product.Name))
            {
                this.productsBySizeName[product.Size][product.Name] = new HashSet<IProduct>();
                this.productsBySizeNameType[product.Size][product.Name] = new Dictionary<string, ISet<IProduct>>();
            }

            if (!this.productsBySizeNameType[product.Size][product.Name].ContainsKey(type))
            {
                this.productsBySizeNameType[product.Size][product.Name][type] = new HashSet<IProduct>();
            }

            this.productsBySizeNameType[product.Size][product.Name][type].Add(product);
            this.productsBySizeName[product.Size][product.Name].Add(product);
        }

    }
}
