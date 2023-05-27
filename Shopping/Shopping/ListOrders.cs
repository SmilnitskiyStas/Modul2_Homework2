using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class ListOrders
    {
        public ListOrders Next { get; }

        public Product Value { get; }

        public ListOrders(Product product, ListOrders next)
        {
            Next = next;

            Value = product;
        }
    }
}
