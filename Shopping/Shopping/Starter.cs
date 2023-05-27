using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Starter
    {
        public void Run()
        {
            Console.WriteLine("Hello");

            Cart cart = new Cart();

            cart.AddProductToCart(new Product("T-shirts", 14.99, 3));
        }
    }
}
