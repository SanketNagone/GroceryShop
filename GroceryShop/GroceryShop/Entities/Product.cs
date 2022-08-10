using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal class Product : IProduct
    {
        public Product(IDiscount discount)
        {
            Quantity = 1;
            DiscountOffer = discount;
        }

        public string Name { get; set; }
        public int Prise { get; set; }
        public IDiscount DiscountOffer { get; set; }

        public int Quantity { get; set; }
        public int Id { get; set; }
        public int DiscountId { get; set; }
    }
}
