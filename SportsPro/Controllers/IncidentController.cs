using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;

namespace SportsPro.Controllers
{

    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("[controller]s/")]
        [HttpGet]
        public ViewResult List(string Filter)
        {
            // create an instance of the view model
            var incidentList = new IncidentListViewModel()
            {
                Incidents = new List<Incident>()
            };

            var unasList = context.Incidents.Where(m => m.Technician.Equals(null)); // Unassigned Incidents
            var openList = context.Incidents.Where(m => !m.DateClosed.HasValue); // Open Incidents

            ViewBag.Current = Filter;

            switch (Filter)
            {
                case "All":
                    incidentList.Incidents = context.Incidents.ToList();
                    break;
                case "Open":
                    if (openList.Any()) // dateclosed is null
                    {
                        foreach (Incident incident in openList)
                        {
                            incidentList.Incidents.Add(incident); // add incidents to the model
                        }
                    }
                    break;
                case "Unassigned":
                    if (unasList.Any()) // when a technician has an incident on record
                    {
                        foreach (Incident incident in unasList)
                        {
                            incidentList.Incidents.Add(incident); // add incidents to the model that have a technician
                        }
                    }
                    break;
                default:
                    incidentList.Incidents = context.Incidents.ToList();
                    break;
            }

            StoreListsInViewModel();

            return View("List", incidentList);
        }

        public void StoreListsInViewModel()
        {
            var incidentView = new IncidentViewModel();

            incidentView.Customers = context.Customers
                .OrderBy(c => c.FirstName)
                .ToList();

            incidentView.Products = context.Products
                .OrderBy(c => c.Name)
                .ToList();

            incidentView.Technicians = context.Technicians
                .OrderBy(c => c.Name)
                .ToList();
        }

        [HttpGet]
        public ViewResult Add()
        {

            var model = new IncidentViewModel
            {
                // Set the lists equal to the current context
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                // set incident as new object
                CurrentIncident = new Incident(),
                Action = "Add"
            };


            StoreListsInViewModel();
            return View("AddEdit", model);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = new IncidentViewModel
            {
                // Set the lists equal to the current context
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                // set current incident to one thats being edited
                CurrentIncident = context.Incidents.Find(id),
                // set action to edit
                Action = "Edit"
            };

            StoreListsInViewModel();

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(Incident CurrentIncident)
        {

            var model = new IncidentViewModel();

            if (ModelState.IsValid)
            {
                if (CurrentIncident.IncidentID == 0)
                {
                    context.Incidents.Add(CurrentIncident);
                }
                else
                {
                    context.Incidents.Update(CurrentIncident);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                StoreListsInViewModel();
                if (CurrentIncident.IncidentID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Incidents.Find(id);
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

       