using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCatagoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatagory> producatagories;

        public ProductCatagoryRepository()
        {
            producatagories = cache["producatagories"] as List<ProductCatagory>;
            if (producatagories == null)
            {
                producatagories = new List<ProductCatagory>();
            }
        }

        public void Commit()
        {
            cache["producatagories"] = producatagories;
        }

        public void Insert(ProductCatagory p)
        {
            producatagories.Add(p);
        }

        public void Update(ProductCatagory productcatagory)
        {
            ProductCatagory productcatagoryToUpdate = producatagories.Find(p => p.Id == productcatagory.Id);

            if (productcatagoryToUpdate != null)
            {
                productcatagoryToUpdate = productcatagory;
            }
            else
            {
                throw new Exception("Product catagory not found");
            }
        }

        public ProductCatagory Find(string Id)
        {
            ProductCatagory productcatagory = producatagories.Find(p => p.Id == Id);
            if (productcatagory != null)
            {
                return productcatagory;
            }
            else
            {
                throw new Exception("Product catagory not found");
            }
        }

        public IQueryable<ProductCatagory> Collection()
        {
            return producatagories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatagory productcatagoryToDelete = producatagories.Find(p => p.Id == Id);

            if (productcatagoryToDelete != null)
            {
                producatagories.Remove(productcatagoryToDelete);
            }
            else
            {
                throw new Exception("Product catagory not found");
            }
        }
    }
}
