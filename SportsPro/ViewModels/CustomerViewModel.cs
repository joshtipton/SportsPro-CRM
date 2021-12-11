using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace SportsPro.Models
{
    public class CustomerViewModel
    {
        public List<Customer> Customers { get; set; }

        public SelectList CustomerList { get; set; }

        public Customer CurrentCustomer { get; set; }

        [Required(ErrorMessage = "Please select a valid customer from the list below.")]
        public string FullName { get; set; }

        public List<Product> Products { get; set; }
    }
}
