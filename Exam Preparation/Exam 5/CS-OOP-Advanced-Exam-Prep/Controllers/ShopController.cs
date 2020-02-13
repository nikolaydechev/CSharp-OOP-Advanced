namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    using System;
    using Constants;
    using Framework.Lifecycle;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Controller;
    using Framework.Lifecycle.Request;
    using Provider.Data;

    [Controller]
    public class ShopController
    {
        [Inject]
        private IDataProvider dataProvider;

        [RequestMapping("/shop/{type}/{productId}", RequestMethod.ADD)]
        public string AddProduct(
            [UriParameter("type")]string type, 
            [UriParameter("productId")]int productId)
        {
            try
            {
                var result = this.dataProvider.AddProductToShop(type, productId);
                if (result == null)
                {
                    return string.Format(
                        Messages.ProductNotFound,
                        productId);
                }

                return string.Format(
                    Messages.ProductMovedSuccessfully,
                    productId,
                    result.GetType().Name);
            }
            catch (InvalidOperationException ioe)
            {
                return ioe.Message;
            }
        }

        [RequestMapping("/shop/{shopType}", RequestMethod.GET)]
        public string GetProducts([UriParameter("shopType")]string shopType)
        {
            var products = this.dataProvider.GetProductByShop(shopType);
            var result = string.Join("\r\n", products);
            if (result.Trim() == string.Empty)
            {
                return Messages.ProductsNotFound;
            }

            return result;
        }
    }
}
