using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Product
    {
        public string Sku;
        public int Price;

        public Product(string sku, int price)
        {
            Price = price;
            Sku = sku;
        }
    }
}
