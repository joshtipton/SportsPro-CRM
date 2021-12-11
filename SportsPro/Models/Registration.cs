using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Just setting this up for now
namespace SportsPro.Models
{
    public class Registration
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        // navigation properties
        public Customer CurrentCustomer { get; set; }

        public Product CurrentProduct { get; set; }
    }
}
