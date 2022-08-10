using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.DAL
{
    internal interface ISpecialDayDiscountAccessor
    {
        List<ISpecialDiscount> GetSpecialDiscounts();
       
     
    }
}
