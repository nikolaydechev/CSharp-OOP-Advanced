namespace Tests
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Constants;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Controllers;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestProductController
    {

        private ProductController productController;
        private Mock<IDataProvider> dbMock;

        [TestInitialize]
        public void SetUp()
        {
            this.dbMock = new Mock<IDataProvider>();
            this.productController = new ProductController(this.dbMock.Object);
        }

        [TestMethod]
        public void TestEdit_NoProductReturned_ShouldReturnNoProductMessage()
        {
            this.dbMock.Setup(b => b.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(() => null);
            var result = this.productController.Edit(6, "pesho", 44);

            Assert.AreEqual(
                string.Format(Messages.ProductNotFound, 6),
                result
                );
        }

        [TestMethod]
        public void TestEdit_ProductReturned_ShouldReturnProductEditedSuccessfullyMessage()
        {
            this.dbMock.Setup(b => b.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(() => new BigProduct(6, "pesho", 44));
            var result = this.productController.Edit(6, "pesho", 44);

            Assert.AreEqual(
                string.Format(Messages.ProductEditedSuccessfully, 6),
                result
                );
        }

    }
}
