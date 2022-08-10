using GroceryShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryShop.DAL
{
    internal interface IProductAccessor
    {
        List<IProduct> GetAllProducts();
        void AddProduct(IProduct product);

        void RemoveProduct(int productId);

        void UpdateProduct(int productId, IProduct product);
            
    }
}
