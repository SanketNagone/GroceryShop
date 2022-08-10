using GroceryShop.Entities;
using GroceryShop.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static GroceryShop.GroceryEnums;

namespace GroceryShop.DAL
{
    internal class DiscountAccessor : IDiscountAccessor
    {
        public void AddDiscounts(IDiscount discount)
        {
            var allDiscounts = GetAllDiscounts();
            var nextId= allDiscounts.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            XDocument xmlDoc = XDocument.Load("Data/DiscountsData.xml");
            
            xmlDoc.Element("Discounts").Add(new XElement("Discount", new XElement("Id", nextId), new XElement("Type", discount.Type),
                new XElement("DiscountPercent", discount.DiscountPercentage), new XElement("ToBuy", discount.ToBuy),
                new XElement("Free", discount.Free)));
            xmlDoc.Save("Data/DiscountsData.xml");

        }

        public List<IDiscount> GetAllDiscounts()
        {
            List<IDiscount> lstDiscounts = new List<IDiscount>();
            DataSet ds = new DataSet();
            ds.ReadXml("Data/DiscountsData.xml");
            DataView dvDiscounts;
            dvDiscounts = ds.Tables[0].DefaultView;
            dvDiscounts.Sort = "Id";
            foreach (DataRowView dr in dvDiscounts)
            {
                IDiscount model;
                var discountType= Convert.ToInt32(dr[1]);
                model = DiscountFactory.GetDiscount((DiscountType)discountType, Convert.ToInt32(dr[0]), 
                    Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]) , Convert.ToInt32(dr[4]));
                lstDiscounts.Add(model);
            }
            return lstDiscounts;    
        }

        public IDiscount GetDiscountById(int discountId)
        {
            return GetAllDiscounts().Where(x => x.Id == discountId).FirstOrDefault();
        }

        public void RemoveDiscounts(int discountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateDiscount(int discountId, IDiscount discount)
        {
            XDocument xmlDoc = XDocument.Load("Data/DiscountsData.xml");
            var items = (from item in xmlDoc.Descendants("Discounts") select item).ToList();
            XElement selected = items.Where(p => p.Element("Id").Value == discountId.ToString()).FirstOrDefault();
            selected.Remove();
            xmlDoc.Save("Data/DiscountsData.xml");
            xmlDoc.Element("Discounts").Add(new XElement("Discount", new XElement("Id", discount.Id), new XElement("Type", discount.Type),
                new XElement("DiscountPercent", discount.DiscountPercentage), new XElement("ToBuy", discount.ToBuy),
                new XElement("Free", discount.Free)));
            xmlDoc.Save("Data/DiscountsData.xml");
        }
    }
}
