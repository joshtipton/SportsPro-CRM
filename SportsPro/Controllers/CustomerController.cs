using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System;

namespace SportsPro.Controllers
{
        public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
        }
        // Attribute Routing
        [Route("Customers")]
        public IActionResult List()
        {
             List<Customer> customers = context.Customers.OrderBy(c => c.LastName).ToList();
            return View(customers);
        }

        public IActionResult Update(int id)
        {
            ViewBag.Countries = context.Countries.ToList();
            Country country = context.Countries.Find(id);
            return View(country);
             
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Countries = context.Countries.ToList();

            return View("AddEdit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Countries = context.Countries.ToList();

            var customer = context.Customers.Find(id);
           
            return View("AddEdit", customer);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                ViewBag.Action = "Add";
            }
            else
            {
                ViewBag.Action = "Edit";
            }

            // If an email already exists, and the email being checked isn't the current customer but all others
            if (context.Customers.Any(c => c.Email == customer.Email && c.CustomerID != customer.CustomerID)) 
            {
                ModelState.AddModelError("Email", "This email address is already in use. Please try another.");
            }

            if (ModelState.IsValid)
            {
                if (ViewBag.Action == "Add")
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Countries = context.Countries.ToList();
                return View("AddEdit", customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Customers.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}