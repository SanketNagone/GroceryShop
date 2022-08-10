using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GroceryShop.GroceryEnums;

namespace GroceryShop.Entities
{
    internal interface IDiscount
    {
        public int Id { get; set; }
        public string Description { get; }
        public int DiscountPercentage { get; set; }

        public int ToBuy { get; set; }
        public int Free { get; set; }
        public DiscountType Type { get; set; }
        int CalculateDiscount(IProduct product);
    }
}
