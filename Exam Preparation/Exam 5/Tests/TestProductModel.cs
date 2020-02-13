using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;

    [TestClass]
    public class TestProductModel
    {
        [TestMethod]
        public void TestBigProductChangeSize_ValidSize_ExpectedChangeSuccessfully()
        {
            IProduct product = new BigProduct(1, "pesho", 33);
            product.Size = 66;

            Assert.AreEqual(132, product.Size);
        }

        [TestMethod]
        public void TestSmallProductChangeSize_ValidSize_ExpectedChangeSuccessfully()
        {
            IProduct product = new SmallProduct(1, "pesho", 33);
            product.Size = 44;

            Assert.AreEqual(22, product.Size);
        }

        [TestMethod]
        public void TestProductChangeName_ValidName_ExpectedChangeSuccessfully()
        {
            IProduct product = new BigProduct(1, "pesho", 33);
            product.Name = "gosho";

            Assert.AreEqual("gosho", product.Name);
        }
    }
}
