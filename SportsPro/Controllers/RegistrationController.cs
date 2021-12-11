using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsPro.Models;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private SportsProContext context { get; set; }

        public RegistrationController(SportsProContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public ViewResult Get()
        {
            var model = new CustomerViewModel
            {
                Customers = context.Customers.ToList(),
                CurrentCustomer = context.Customers.First()
            };

            // check if JSON key for tech id has a value yet, if not catch the exception and continue
            try
            {
                model.CurrentCustomer = context.Customers.Find(GetCustomer());
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message); // Error - occurs when a technician hasn't been selected during the session
            }
            model.CustomerList =
                new SelectList(model.Customers, "CustomerID", "FullName", model.CurrentCustomer.CustomerID.ToString());

            return View("Select", model);
        }

        public IActionResult SetCustomer(int SelectedItem)
        {
            string custJson = JsonConvert.SerializeObject(SelectedItem);
            HttpContext.Session.SetString("customer", custJson);

            return RedirectToAction("List");
        }

        public int GetCustomer()
        {
            string custJson = HttpContext.Session.GetString("customer");
            int custID = JsonConvert.DeserializeObject<int>(custJson);

            return custID;
        }

        [Route("[controller]s/")]
        [HttpGet]
        public IActionResult List()
        {
            int id = GetCustomer();

            var model = new ProductListViewModel
            {
                Products = new List<Product>(),
                CurrentCustomer = context.Customers.Find(id)
            };

            ViewBag.selectedCustomer = model.CurrentCustomer.FullName;

            // a list of incidents with the selected technician
            var filteredList = context.Products.Where(m => m.ProductID.Equals(model.CurrentCustomer.CustomerID));

            if (filteredList.Any()) // when a technician has an incident on record
            {
                foreach (Product Product in filteredList)
                {
                    model.Products.Add(Product); // add incidents to the model that have a technician
                }

                model.HasProduct = true;
            }

            else
            {
                model.HasProduct = false;
            }

            return View(model);

        }


        [HttpPost]
        public IActionResult Save(Product CurrentProduct)
        {
            var model = new CustomerViewModel()
            {
                CurrentCustomer = context.Customers.Find(GetCustomer())
            };


            if (ModelState.IsValid)
            {
                context.Products.Update(CurrentProduct);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", model);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var Product = context.Products.Find(id);
            return View(Product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product Product)
        {
            context.Products.Remove(Product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

