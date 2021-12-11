using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace SportsPro.Models
{
    public class IncidentListViewModel
    {
        // Store list of incidents
        public List<Incident> Incidents { get; set; }

        // Filter to be used later
        public string Filter { get; set; }

        // Set to the item selected in the select technician page
        public int SelectedItem { get; set; }

        // Determine if a technician has at least one incident
        public bool HasIncident { get; set; }

        public Technician CurrentTechnician { get; set; }
    }
}
