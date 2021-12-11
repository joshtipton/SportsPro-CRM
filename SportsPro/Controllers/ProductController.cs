using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        
        private SportsProContext context { get; set; }

        
        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }
        // Attribute Routing
        [Route("/Products")]
        public ViewResult List()
        {
            List<Product> products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
            
            return View(products);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Product());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    context.Products.Add(product);
                    // Store the name of the added product
                    TempData["tempName"] = product.Name;
                    // Store the message 
                    TempData["p-addmessage"] = $"The product {TempData["tempName"]} has been added successfully.";
                }
                else
                {
                    context.Products.Update(product);
                    // Store the name of edited product
                    TempData["tempName"] = product.Name;
                    // Store the message
                    TempData["p-editmessage"] = $"The product {TempData["tempName"]} has been modified successfully.";
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (product.ProductID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }

                return View(product);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            // Store the name of deleted product
            TempData["tempName"] = product.Name;
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            
            // store the delete message
            TempData["p-delmessage"] = $"The product {TempData["tempName"]} has been removed successfully.";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}