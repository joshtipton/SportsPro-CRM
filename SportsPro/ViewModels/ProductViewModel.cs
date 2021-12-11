using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class ProductViewModel
    {
        // Lists
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }

        // Current Customer
        public Customer CurrentCustomer { get; set; }

        // Action: Only Edit; May Be Unnecessary For Now
        public string Action { get; set; }
    }
}

