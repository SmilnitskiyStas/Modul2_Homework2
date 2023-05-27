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
            ListProducts listProducts = CreateProductForShop();

            int countProduct = ShowAllProduct(listProducts);

            AddProductToCart(listProducts, countProduct);
        }

        private ListProducts CreateProductForShop()
        {
            Product product = new Product();

            product.AddProductToList(new Product("T-shirt", 14.99, 3));
            product.AddProductToList(new Product("Pants", 18.99, 8));
            product.AddProductToList(new Product("Shoes", 15.99, 5));
            product.AddProductToList(new Product("T-shirt", 16.49, 9));
            product.AddProductToList(new Product("Skirt", 8.99, 15));
            product.AddProductToList(new Product("Hat", 12.49, 12));

            return product.GetListProducts();
        }

        private void AddProduct(string name, int price, int quantity)
        {
            Product product = null;

            product.AddProductToList(new Product(name, price, quantity));
        }

        private int ShowAllProduct(ListProducts listProducts)
        {
            int productIndex = 1;

            while (listProducts != null)
            {
                Console.WriteLine($"{productIndex++} - {listProducts.Value.ProductName}");

                listProducts = listProducts.Next;
            }

            return productIndex;
        }

        private void AddProductToCart(ListProducts listProducts, int countProducts)
        {
            Product product = new Product();

            Cart cart = new Cart();

            int productIndexForAddedToCart = 1;

            Console.WriteLine("\nSelect products, what you want to buy:");

            string[] indexForAddedProductToCart = Console.ReadLine().Split(',');

            for (int i = 0; i < indexForAddedProductToCart.Length; i++)
            {
                indexForAddedProductToCart[i] = indexForAddedProductToCart[i].Trim();
            }

            Array.Sort(indexForAddedProductToCart);

            for (int i = 0; i < indexForAddedProductToCart.Length; i++)
            {
                for (int y = 0; y < countProducts; y++)
                {
                    if (productIndexForAddedToCart == int.Parse(indexForAddedProductToCart[i].Trim()))
                    {
                        product = listProducts.Value;

                        cart.AddProductToCart(product);

                        listProducts = listProducts.Next;

                        productIndexForAddedToCart++;

                        break;
                    }

                    listProducts = listProducts.Next;

                    productIndexForAddedToCart++;
                }
            }
        }
    }
}
