using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Cart
    {
        private ListProducts _head;

        public Cart()
        {
        }

        public void AddProductToCart(Product product)
        {
            if (_head == null)
            {
                _head = new ListProducts(product, null);
            }
            else
            {
                ListProducts node = new ListProducts(product, _head);

                _head = node;
            }
        }

        public ListProducts GetListOrders()
        {
            return _head;
        }
    }
}
