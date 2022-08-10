using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.DAL
{
    internal interface IDiscountAccessor
    {
        List<IDiscount> GetAllDiscounts();

        IDiscount GetDiscountById(int discountId);

        void AddDiscounts(IDiscount discount);

        void RemoveDiscounts(int discountId);

        void UpdateDiscount(int discountId, IDiscount discount);
    }
}
