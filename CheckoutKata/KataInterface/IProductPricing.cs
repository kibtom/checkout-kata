using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    interface IProductPricing
    {
        decimal GetDiscountedPrice(List<string> products);
    }
}
