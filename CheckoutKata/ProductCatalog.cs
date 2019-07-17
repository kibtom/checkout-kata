using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class ProductCatalog
    {
        //list of the products 
        private List<Product> _catalog = new List<Product>();

        public ProductCatalog UpdateProductPrice(string sku, decimal price)
        {
            try
            {
                //Remove the product needing update from the List
                _catalog.RemoveAll(x => x.ProductSku == sku);

                //Add the new product
                _catalog.Add(new Product(sku, price));
                return this;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetProductPrice(string sku)
        {
            try
            {
                //Get the product based on the SKU
                var product = _catalog.Where(x => x.ProductSku == sku).FirstOrDefault();
                if (product == null)
                    throw new NullReferenceException($"product {sku} is not in our catalog");
                return product.Price;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
