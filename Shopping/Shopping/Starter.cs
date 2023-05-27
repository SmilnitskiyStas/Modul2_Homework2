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
            User user = CreateUser();

            ListProducts listProducts = CreateProductForShop();

            if (user.Rols.ToLower() == "admin")
            {
                Console.WriteLine("You can create new product\nDo you want create new product for shop?\n1. Yes\n2. No");
                int choiceForCreateProduct = int.Parse(Console.ReadLine());

                if (choiceForCreateProduct == 1)
                {
                    Console.WriteLine("How you want to create products?");
                    int counteCreateProduct = int.Parse(Console.ReadLine());

                    for (int i = 0; i < counteCreateProduct; i++)
                    {
                        listProducts = AddProduct(listProducts);
                    }
                }
            }

            (int countProduct, double _) = ShowAllProduct(listProducts);

            ListProducts listProductForOrder = AddProductToCart(listProducts, countProduct);

            OrderProducts(listProductForOrder, user);
        }

        private User CreateUser()
        {
            Console.WriteLine("If you want to get a discount, you need to register\n1. I want to register\n2. No, I don`t want to regiatration");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Please, input your data");

                Console.WriteLine("Input your Firstname");
                string firstName = Console.ReadLine();

                Console.WriteLine("Input your Lastname");
                string lastName = Console.ReadLine();

                Console.WriteLine("Input yout Email");
                string email = Console.ReadLine();

                Console.WriteLine("Input your phone numbers");
                string phoneNumbers = Console.ReadLine();

                Console.WriteLine("Input password");
                string password = Console.ReadLine();

                User user = new User(firstName, lastName, email, phoneNumbers, password);

                return user;
            }

            return new User();
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

        private ListProducts AddProduct(ListProducts listProducts)
        {
            Product product = new Product();

            while (listProducts != null)
            {
                product.AddProductToList(listProducts.Value);

                listProducts = listProducts.Next;
            }

            Console.WriteLine("Input name for product:");
            string nameProduct = Console.ReadLine();

            Console.WriteLine($"Input price for product '{nameProduct}' (use ',' format 14,49):");
            double priceProduct = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Input quantity for product '{nameProduct}':");
            int quantityProduct = int.Parse(Console.ReadLine());

            product.AddProductToList(new Product(nameProduct, priceProduct, quantityProduct));

            Console.WriteLine($"\nProduct {nameProduct} is create\n");

            return product.GetListProducts();
        }

        private (int, double) ShowAllProduct(ListProducts listProducts)
        {
            int productIndex = 1;

            double productPrice = 0;

            while (listProducts != null)
            {
                Console.WriteLine($"{productIndex++} - Product name: {listProducts.Value.ProductName} - Product price: {listProducts.Value.ProductPrice}");

                productPrice += listProducts.Value.ProductPrice;

                listProducts = listProducts.Next;
            }

            return (productIndex, productPrice);
        }

        private ListProducts AddProductToCart(ListProducts listProducts, int countProducts)
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

            return cart.GetListOrders();
        }

        private void OrderProducts(ListProducts listProducts, User user)
        {
            if (user.FirstName == null)
            {
                Console.WriteLine("You need to enter your details so that we know where and to whom to send the goods");

                user = CreateUser();
            }

            Console.WriteLine($"\nDear {user.FirstName}\nYou create order product\n");

            (int _, double productPrice) = ShowAllProduct(listProducts);

            Console.WriteLine($"Your order price = {Math.Round(productPrice, 4)}");

            WriteReadFile writeReadFile = new WriteReadFile(listProducts, user);
        }
    }
}
