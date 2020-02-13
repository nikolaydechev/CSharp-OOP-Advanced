namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    using System;
    using System.Text;
    using Constants;
    using Framework.Lifecycle;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Controller;
    using Framework.Lifecycle.Request;
    using Provider.Data;

    [Controller]
    public class ProductController
    {
        [Inject]
        private IDataProvider dataProvider;

        public ProductController()
        {
        }

        public ProductController(IDataProvider dataProvider)
            : this()
        {
            this.dataProvider = dataProvider;
        }

        [RequestMapping("/product/{size}/{name}/{type}", RequestMethod.ADD)]
        public string AddProduct(
            [UriParameter("size")]int size, 
            [UriParameter("name")]string name, 
            [UriParameter("type")]string type)
        {
            var product = this.dataProvider.AddProduct(size, name, type);

            return string.Format(Messages.ProductRegisteredSuccessfully, product.Id);
        }

        [RequestMapping("/product/{size}/{name}/{type}", RequestMethod.GET)]
        public string GetBySizeNameType(
            [UriParameter("size")]int size,
            [UriParameter("name")]string name,
            [UriParameter("type")]string type)
        {
            var resultCollection = this.dataProvider.GetProductsBySizeNameType(size, name, type);

            if (resultCollection == null)
            {
                return Messages.ProductsNotFound;
            }

            return string.Join("\r\n", resultCollection);
        }

        [RequestMapping("/product/{size}/{name}", RequestMethod.GET)]
        public string GetBySizeName(
            [UriParameter("size")]int size,
            [UriParameter("name")]string name)
        {
            var resultCollection = this.dataProvider.GetProductsBySizeName(size, name);

            if (resultCollection == null)
            {
                return Messages.ProductsNotFound;
            }

            return string.Join("\r\n", resultCollection);
        }

        [RequestMapping("/product/{id}", RequestMethod.GET)]
        public string GetOne([UriParameter("id")] int id)
        {
            var product = this.dataProvider.GetProductById(id);

            if (product == null)
            {
                return string.Format(Messages.ProductNotFound,
                    id
                    );
            }

            return product.ToString();
        }

        [RequestMapping("/product/{id}/{newName}/{newSize}", RequestMethod.EDIT)]
        public string Edit(
            [UriParameter("id")] int id,
            [UriParameter("newName")] string newName,
            [UriParameter("newSize")] int newSize)
        {
            var product = this.dataProvider.EditProduct(id, newSize, newName);

            if (product == null)
            {
                return string.Format(
                    Messages.ProductNotFound,
                    id);
            }

            return string.Format(
                Messages.ProductEditedSuccessfully,
                id);
        }
    }
}
