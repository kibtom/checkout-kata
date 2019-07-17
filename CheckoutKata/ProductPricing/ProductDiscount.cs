using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.ProductPricing
{
    public class ProductDiscount 
    {
        //Get the bundle
        private List<PromotionBundle> _bundle = new List<PromotionBundle>();

        public ProductDiscount DiscountedBundle (string sku, int productCount, decimal bundlePrice)
        {
            
            _bundle.RemoveAll(x => x.ProductSku == sku);
            _bundle.Add(new PromotionBundle(sku, productCount, bundlePrice));
            return this;
        }

        public decimal GetDiscountedPrice(string sku, ref int productCount)
        {
            var discount = _bundle.Where(x => x.ProductSku == sku).FirstOrDefault();

            if (discount == null)
                return 0;

            var discountedPrice = (productCount / discount.ProductCount) * discount.BundlePrice;
            productCount = productCount % discount.ProductCount;

            return discountedPrice;
        }
    }
}
