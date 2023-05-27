using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Cart
    {
        private ListOrders _head;

        public Cart()
        {
        }

        public void AddProductToCart(Product product)
        {
            if (_head == null)
            {
                _head = new ListOrders(product, null);
            }
            else
            {
                ListOrders node = new ListOrders(product, _head);

                _head = node;
            }
        }

        public ListOrders GetListOrders()
        {
            return _head;
        }
    }
}
