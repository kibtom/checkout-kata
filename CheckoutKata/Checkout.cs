using CheckoutKata.KataInterface;
using CheckoutKata.ProductPricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public Checkout(ProductCatalog catalog, ProductDiscount productDiscount)
        {
            _catalog = catalog;
            _discount = productDiscount;
            _scannedItem = new Dictionary<string, int>();
        }

        private readonly ProductCatalog _catalog;
        private readonly ProductDiscount _discount;
        private readonly Dictionary<string, int> _scannedItem;

        public void Scan(string sku, int timesScanned = 1)
        {
            //We should be able to keep track of scans incase of Multiple items
            try
            {
                if (_scannedItem.ContainsKey(sku))
                    _scannedItem[sku] += timesScanned;

                else
                    _scannedItem.Add(sku, timesScanned);                    

            }
            catch (Exception)
            {

                throw;
            }
        }
        public decimal GetTotalPrice()
        {
            decimal total = 0;

            foreach (var item in _scannedItem)
            {
                var sku = item.Key;
                int scannedTimes = item.Value;
                total += _discount.GetDiscountedPrice(sku, ref scannedTimes);
                total += scannedTimes * _catalog.GetProductPrice(item.Key);
            }
            return total;
        }
    }
}
