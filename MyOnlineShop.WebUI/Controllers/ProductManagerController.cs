using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOnlineShop.Core.Models;
using MyOnlineShop.DataAccess.InMemory;

namespace MyOnlineShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        public ProductRepository context;
        public ProductManagerController()
        {
            context = new ProductRepository();
        } 

       
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

       

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.AddProduct(product);
                context.Commit();
                return RedirectToAction("Index","ProductManager");
            }
            
        }




    }
}