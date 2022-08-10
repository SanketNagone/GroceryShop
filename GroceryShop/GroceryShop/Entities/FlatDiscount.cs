using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal class FlatDiscount : IDiscount
    {
        public FlatDiscount()
        {}
        public FlatDiscount(int id,int percentage)
        {
            Id = id;
            DiscountPercentage = percentage;
        }
        public int DiscountPercentage { get; set; }
        public string Description => $"Flat {DiscountPercentage}% Off.";

        public int Id { get; set ; }
        public int ToBuy { get ; set; }
        public int Free { get; set; }
        public GroceryEnums.DiscountType Type { get; set; }

        public int CalculateDiscount(IProduct product)
        {
            return (product.Prise * DiscountPercentage / 100);
        }
    }
}
