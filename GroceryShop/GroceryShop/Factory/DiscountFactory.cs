using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GroceryShop.GroceryEnums;

namespace GroceryShop.Factory
{
    internal class DiscountFactory
    {
        public static IDiscount GetDiscount(DiscountType discountType, int Id, int percentage, int toBuy, int free)
        {
            switch (discountType)
            {
                case DiscountType.Flat:
                    return new FlatDiscount(Id, percentage);
                    break;
                case DiscountType.UnitDiscount:
                    return new UnitDiscount(Id,toBuy,free);
                    break;
                default: return new FlatDiscount(Id,0);
                    break;
            }

        }
    }
}
