using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal class UnitDiscount : IDiscount
    {
        public UnitDiscount()
        { }
        public UnitDiscount(int id, int toBuy, int free)
        {
            Id = id;
            ToBuy = toBuy;
            Free = free;
        }
        public int ToBuy { get; set; }

        public int Free { get; set; }
        public string Description { get => $"Buy {ToBuy} and Get {Free} Free."; }
        public int Id { get; set; }
        public int DiscountPercentage { get; set; }
        public GroceryEnums.DiscountType Type { get; set; }

        public int CalculateDiscount(IProduct product)
        {
            if (product?.Quantity > ToBuy)
            {
                int numberOfProductsFree = product.Quantity / (ToBuy + Free);
                return numberOfProductsFree * product.Prise;
            }
            return 0;
        }
    }
}
