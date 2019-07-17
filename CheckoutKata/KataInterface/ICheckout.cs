using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.KataInterface
{
    interface ICheckout
    {
        void Scan(string product, int timesScanned);
        decimal GetTotalPrice();
    }
}
