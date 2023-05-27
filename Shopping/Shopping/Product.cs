using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Product
    {
        public ListProducts _products;

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public Product() { }

        public Product(string productName, double productPrice, int productQuantity)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }

        public void AddProductToList(Product product)
        {
            if (_products == null)
            {
                _products = new ListProducts(product, null);
            }
            else
            {
                ListProducts listOrders = new ListProducts(product, _products);

                _products = listOrders;
            }
        }

        public ListProducts GetListProducts()
        {
            return _products;
        }
    }
}
