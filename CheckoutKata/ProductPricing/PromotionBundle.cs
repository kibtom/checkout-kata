using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.ProductPricing
{
   public class PromotionBundle
    {
        public string ProductSku;
        public int ProductCount;
        public decimal BundlePrice;

        public PromotionBundle(string sku, int productCount, decimal bundlePrice)
        {
            ProductSku = sku;
            ProductCount = productCount;
            BundlePrice = bundlePrice;
        }
    }
}
