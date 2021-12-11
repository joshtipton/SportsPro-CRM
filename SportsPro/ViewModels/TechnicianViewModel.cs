using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace SportsPro.Models
{
    public class TechnicianViewModel
    {
        public List<Technician> Technicians { get; set; }

        public Incident CurrentIncident { get; set; }

        public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Please select a valid technician from the list below.")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public SelectList TechnicianList { get; set; }

        public Technician CurrentTechnician { get; set; }
    }
}
