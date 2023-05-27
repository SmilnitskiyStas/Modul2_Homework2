using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Order
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Product[] Products { get; set; }

        public Order(User user, Product[] products)
        {
            Id = user.GetHashCode();
            User = user;
            Products = products;
        }
    }
}
