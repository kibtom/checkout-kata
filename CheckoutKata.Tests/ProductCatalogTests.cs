using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class ProductCatalogTests
    {
        [Test]
        public void UpdateProductPrice_WhenCalled_PriceShouldChange()
        {
            //Arrange
            var productCatalog = new ProductCatalog();
            //Act
            productCatalog.UpdateProductPrice("A", 50);
            //Assert
            Assert.AreEqual(50, productCatalog.GetProductPrice("A"));
        }
    }
}
