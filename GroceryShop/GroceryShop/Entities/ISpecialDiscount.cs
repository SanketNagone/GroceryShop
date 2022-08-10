using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal interface ISpecialDiscount
    {
        public int Id { get; set; }
        public string Day { get; set; }

        public int DiscountPercentage { get; set; }

        public string Month { get; set; }
    }
}
