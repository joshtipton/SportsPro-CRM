using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace SportsPro.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }

        public List<Registration> Registrations { get; set; }

        public Registration CurrentRegistration;

        public int SelectedItem { get; set; }

        public bool HasProduct { get; set; }

        public Customer CurrentCustomer { get; set; }
    }
}
