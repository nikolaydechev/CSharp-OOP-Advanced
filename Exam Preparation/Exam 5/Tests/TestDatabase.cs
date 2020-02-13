namespace Tests
{
    using System.Collections.Generic;
    using System.Reflection;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Type;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDatabase
    {
        private IDataProvider dataProvider;

        [TestInitialize]
        public void SetUp()
        {
            this.dataProvider = DatabaseUtils.CreateDataProvider();
        }

        [TestMethod]
        public void TestEditBigProduct_ValidSize_ExpectedChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            IProduct product = this.dataProvider.EditProduct(1, 44, "pesho");

            Assert.AreEqual(88, product.Size);
        }

        [TestMethod]
        public void TestEditSmallProduct_ValidSize_ExpectedChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "SmallProduct");
            IProduct product = this.dataProvider.EditProduct(1, 44, "pesho");

            Assert.AreEqual(22, product.Size);
        }

        [TestMethod]
        public void TestEditProduct_ValidName_ExpectedChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            IProduct product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.AreEqual("gosho", product.Name);
        }

        [TestMethod]
        public void TestEditProduct_ValidData_ExpectedIdNotChanged()
        {
            this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            IProduct product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.AreEqual(1, product.Id);
        }

        [TestMethod]
        public void TestEditProduct_ValidData_ExpectedSameReferences()
        {
            IProduct product = this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            IProduct editedProduct = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.AreSame(product, editedProduct);
        }

        [TestMethod]
        public void TestEditProduct_InvalidId_ExpectedNull()
        {
            IProduct editedProduct = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.IsNull(editedProduct);
        }
    }
}
