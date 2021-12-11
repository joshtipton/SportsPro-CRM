using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        // Lists
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }

        // Current Incident
        public Incident CurrentIncident { get; set; }

        // Action: Only Edit; May Be Unnecessary For Now
        public string Action { get; set; }
    }
}
