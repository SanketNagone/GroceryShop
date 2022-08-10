using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroceryShop.DAL
{
    internal class ProductsAccessor : IProductAccessor
    {
        IDiscountAccessor _discountAccessor;
        public ProductsAccessor(IDiscountAccessor discountAccessor)
        {
            _discountAccessor = discountAccessor;
        }
        public int MyProperty { get; set; }
        public void AddProduct(IProduct product)
        {
            var allDiscounts = GetAllProducts();
            var nextId = allDiscounts.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            XDocument xmlDoc = XDocument.Load("Data/ProductsData.xml");
          
            xmlDoc.Element("Discounts").Add(new XElement("Product", new XElement("Id", nextId), new XElement("Name", product.Name),
                new XElement("DiscountId", product.DiscountId), new XElement("Prise", product.Prise)));
            xmlDoc.Save("Data/DiscountsData.xml");
        }

        public List<IProduct> GetAllProducts()
        {
            List<IProduct> lstProducts = new List<IProduct>();
            DataSet ds = new DataSet();
            ds.ReadXml("Data/ProductsData.xml");
            DataView dvProducts;
            dvProducts = ds.Tables[0].DefaultView;
            dvProducts.Sort = "pId";
            foreach (DataRowView dr in dvProducts)
            {
                IProduct model;
                model = new Product(_discountAccessor.GetDiscountById(Convert.ToInt32(dr[2])));
                model.Id= Convert.ToInt32(dr[0]);
                model.Name = Convert.ToString(dr[1]);
                model.Prise = Convert.ToInt32(dr[3]);

                lstProducts.Add(model);
            }
            return lstProducts;
        }

        public void RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId, IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
