using CheckoutKata.ProductPricing;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void SetUp()
        {
            var catalog = new ProductCatalog()
                .UpdateProductPrice("A", 50)
                .UpdateProductPrice("B", 30)
                .UpdateProductPrice("C", 20)
                .UpdateProductPrice("D", 15);

            var discounts = new ProductDiscount()
                .DiscountedBundle("A", 3, 130)
                .DiscountedBundle("B", 2, 45);

            _checkout = new Checkout(catalog, discounts);
          
        }

        [TestCase("A", 50.0)]
        [TestCase("B", 30.0)]
        [TestCase("C", 20.0)]
        [TestCase("D", 15.0)]
        public void GetTotalPrice_ScanningSingleItem_ReturnsCorrectPrice(string sku, decimal expectedPrice)
        {
            _checkout.Scan(sku);

            Assert.AreEqual(expectedPrice, _checkout.GetTotalPrice());
        }

        [Test]
        public void GetTotalPrice_ScanningProductA_ReturnsProductAPrice()
        {
            _checkout.Scan("A");

            Assert.That(50, Is.EqualTo(_checkout.GetTotalPrice()));
        }
        public void GetTotalPrice_ScanningProductB_ReturnsProductBPrice()
        {
            _checkout.Scan("B");
            Assert.That(30, Is.EqualTo(_checkout.GetTotalPrice()));
        }
        public void GetTotalPrice_ScanningProductC_ReturnsProductCPrice()
        {
            _checkout.Scan("C");
            Assert.That(20, Is.EqualTo(_checkout.GetTotalPrice()));
        }

        [TestCase("A", 2, 100.0)]
        [TestCase("B", 1, 30.0)]
        [TestCase("C", 10, 200.0)]
        [TestCase("D", 4, 60.0)]
        public void GetTotalPrice_WhenCalled_ReturnsSameProductSumTotal(string sku, int times, decimal expectedTotal)
        {
            _checkout.Scan(sku, times);
            Assert.That(expectedTotal, Is.EqualTo(_checkout.GetTotalPrice()));

        }
        [TestCase("A", 3, 130.0)]
        [TestCase("B", 2, 45.0)]
        [TestCase("A", 9, 390.0)]
        [TestCase("A", 8, 360.0)]
        public void GetTotalPrice_WhenCalled_ReturnsDiscountedPrice(string sku, int times, decimal expectedTotal)
        {
            _checkout.Scan(sku, times);

            Assert.That(expectedTotal, Is.EqualTo(_checkout.GetTotalPrice()));
        }
        [TestCase("ABBAADDC", 225)]
        public void GetTotalPrice_WhenCalled_ReturnTotalPriceOfProducts(string bundle, decimal expectedTotal)
        {
            foreach (var item in bundle)
            {
                _checkout.Scan("" + item);
            }
            Assert.That(expectedTotal, Is.EqualTo(_checkout.GetTotalPrice()));
        }

    }
}
