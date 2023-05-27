using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Product
    {
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public Product(string productName, double productPrice, int productQuantity)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}
