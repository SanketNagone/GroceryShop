using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.DAL
{
    internal class SpecialDayDiscountAccessor : ISpecialDayDiscountAccessor
    {
        public List<ISpecialDiscount> GetSpecialDiscounts()
        {
            List<ISpecialDiscount> lstSpecialDiscounts = new List<ISpecialDiscount>();
            DataSet ds = new DataSet();
            ds.ReadXml("Data/SpecialDayDiscounts.xml");
            DataView dvDiscounts;
            dvDiscounts = ds.Tables[0].DefaultView;
            dvDiscounts.Sort = "Id";
            foreach (DataRowView dr in dvDiscounts)
            {
                ISpecialDiscount model;
                model = new SpecialDiscount();
                model.Id = Convert.ToInt32(dr[0]);
                model.DiscountPercentage = Convert.ToInt32(dr[1]);
                int date;
                model.Day = Int32.TryParse(Convert.ToString(dr[2]), out date) ? date.ToString() : Convert.ToString(dr[2]);
                model.Month = Convert.ToString(dr[3]);
                lstSpecialDiscounts.Add(model);
            }
            return lstSpecialDiscounts;
        }
    }
}
