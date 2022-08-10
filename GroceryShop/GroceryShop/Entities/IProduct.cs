using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal interface IProduct
    {
        public int Id { get; set; }
        string Name { get; set; }
        public int Prise { get; set; }

        public int DiscountId { get; set; }
        public IDiscount DiscountOffer { get; set; }

        public int Quantity { get; set; }
    }
}
