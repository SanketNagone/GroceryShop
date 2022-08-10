using GroceryShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.Entities
{
    internal class Bill
    {
        List<IProduct> products;
        ISpecialDayDiscountAccessor _specialDayDiscountAccessor;

        public Bill(List<IProduct> products, DateTime billDate, ISpecialDayDiscountAccessor specialDayDiscountAccessor)
        {
            this.products = products;
            BillDate = billDate;
            this.TotalBillAmount = this.products.Sum(x => x.Prise * x.Quantity);
            _specialDayDiscountAccessor = specialDayDiscountAccessor;
        }

        public int TotalBillAmount { get; set; }
        public int TotalDiscountAmount { get; set; }

        public int TotalAmoutToPay { get; set; }

        public DateTime BillDate { get; set; }

        public int GetBillAmountAfterDiscount()
        {

            var productsDiscount = CalculateProductsDiscount(this.products);
            var finalDiscount = CalculateSpecialDayDiscount(this.BillDate, this.TotalBillAmount - productsDiscount);


            return this.TotalBillAmount - productsDiscount - finalDiscount;
        }

        private int CalculateSpecialDayDiscount(DateTime billDate, int billAmount)
        {
            var specialDayDiscounts = _specialDayDiscountAccessor.GetSpecialDiscounts();

            int total = 0;
            var billDay = billDate.ToString("dddd");
            var billSpecialDate = billDate.Day.ToString();

            var dayPercenatge = specialDayDiscounts.Where(x => x.Day.Equals(billDay, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            int weekDayDiscount = dayPercenatge == null ? 0 : dayPercenatge.DiscountPercentage;

            var specialDay = specialDayDiscounts.Where(x => x.Day.Equals(billSpecialDate, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            int specialDayDiscount = specialDay == null ? 0 : specialDay.DiscountPercentage;

            var totalDayDiscount = weekDayDiscount + specialDayDiscount;

            return (billAmount * totalDayDiscount / 100);
        }

        private int CalculateProductsDiscount(List<IProduct> products)
        {
            int total = 0;

            foreach (var product in products)
            {
                total += product.DiscountOffer.CalculateDiscount(product);
            }

            return total;
        }
    }
}
