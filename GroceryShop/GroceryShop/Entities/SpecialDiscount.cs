using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal class SpecialDiscount : ISpecialDiscount
    {
        public int Id { get; set; }

        public int DiscountPercentage { get; set; }
        public DateOnly SpecialDate { get; set; }
        public string Month { get; set; }
        string Day { get; set; }
        string ISpecialDiscount.Day { get; set; }
    }
}
