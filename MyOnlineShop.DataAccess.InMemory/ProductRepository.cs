using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOnlineShop.Core.Models;
using System.Runtime.Caching;

namespace MyOnlineShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        public List<Product> products = new List<Product>();

       public ProductRepository()
        {
            if (products == null)
            {
                products = new List<Product>();
                cache["products"] = products as List<Product>;
            }
            else
            {
                cache["products"] = products;
            }
            
        }

        public void Commit()
        {
            /*if (products == null)
            {
                products = new List<Product>();
                cache["products"] = products;
            }
            else
            {
                cache["products"] = products;
            }*/

            cache["products"] = products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            /*if (product == null)
            {
                throw new Exception();
            }
            else
            {
                products.Add(product);
            }*/
        }

        public void DeleteProduct(string id)
        {
            Product productToDelete = products.Find(p => p.ID == id);
            if (productToDelete == null)
            {
                throw new Exception();
            }
            else
            {
                products.Remove(productToDelete);
            }
        }

        public void EditProduct(Product product, string id)
        {
            Product productToEdit = products.Find(p => p.ID == id);
            if (productToEdit == null)
            {
                throw new Exception();
            }
            else
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Category = product.Category;
                productToEdit.Image = product.Image;
            }
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.ID == product.ID);
            if (productToUpdate == null)
            {
                throw new Exception();
            }
            else
            {
                productToUpdate = product;
            }
        }

        public Product Find(string id)
        {
            Product product = products.Find(p => p.ID == id);
            if (product == null)
            {
                throw new Exception();
            }
            else
            {
                return product;
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

    }
}
