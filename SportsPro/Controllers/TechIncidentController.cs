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
    public class TechIncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public TechIncidentController(SportsProContext ctx)
        {

            context = ctx;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model = new TechnicianViewModel
            {
                Technicians = context.Technicians.ToList(),
                CurrentTechnician = context.Technicians.First()
            };

            // check if JSON key for tech id has a value yet, if not catch the exception and continue
            try
            {
                model.CurrentTechnician = context.Technicians.Find(GetTechnician());   
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message); // Error - occurs when a technician hasn't been selected during the session
            }
            model.TechnicianList =
                new SelectList(model.Technicians, "TechnicianID", "Name", model.CurrentTechnician.TechnicianID.ToString());

            return View("Select", model);
        }

        public IActionResult SetTechnician(int SelectedItem)
        {
            string techJson = JsonConvert.SerializeObject(SelectedItem);
            HttpContext.Session.SetString("technician", techJson);

            return RedirectToAction("List");
        }

        public int GetTechnician()
        {
            string techJson = HttpContext.Session.GetString("technician");
            int techID = JsonConvert.DeserializeObject<int>(techJson);

            return techID;
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


        public IActionResult List()
        {
            int id = GetTechnician();

            var model = new IncidentListViewModel
            {
                Incidents = new List<Incident>(),
                CurrentTechnician = context.Technicians.Find(id)
            };

            StoreListsInViewModel();

            ViewBag.selectedTechnician = model.CurrentTechnician.Name;

            // a list of incidents with the selected technician
            var filteredList = context.Incidents.Where(m => m.TechnicianID.Equals(id) && !m.DateClosed.HasValue);

            if (filteredList.Any()) // when a technician has an incident on record
            {
                foreach (Incident incident in filteredList)
                {
                    model.Incidents.Add(incident); // add incidents to the model that have a technician
                }
                
                model.HasIncident = true;
            }

            else
            {
                model.HasIncident = false;
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Save(Incident CurrentIncident)
        {
            IncidentViewModel model = new IncidentViewModel()
            {
                CurrentIncident = context.Incidents.Find(GetTechnician())
            };


            if (ModelState.IsValid)
            {
                context.Incidents.Update(CurrentIncident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                StoreListsInViewModel();
                return View("Edit", model);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {

            var model = new IncidentViewModel
            {
                Action = "Edit",
                CurrentIncident = context.Incidents.Find(id),
                Customers = context.Customers.ToList(),
                Technicians = context.Technicians.ToList(),
                Products = context.Products.ToList()
            };

            StoreListsInViewModel();

            return View("Edit", model);
        }
    }
}