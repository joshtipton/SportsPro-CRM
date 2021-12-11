using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Required(ErrorMessage = "Please enter a first name.")]
		[StringLength(51, ErrorMessage = "First Name must be between 1 and 51 characters.")]
		[DisplayName("FirstName")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter a last name.")]
		[StringLength(51, ErrorMessage = "Last Name must be between 1 and 51 characters.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter a valid address")]
		[StringLength(51, ErrorMessage = "Address must be between 1 and 51 characters.")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter a valid city.")]
		[StringLength(51, ErrorMessage = "City must be between 1 and 51 characters.")]
		public string City { get; set; }
		
		[Required(ErrorMessage = "Please enter a valid state.")]
		[StringLength(51, ErrorMessage = "State must be between 1 and 51 characters.")]
		public string State { get; set; }

		[Required(ErrorMessage = "Please enter a valid zip code")]
		[StringLength(21, ErrorMessage = "Postal Code must be between 1 and 21 characters.")]
		public string PostalCode { get; set; }

		[Required(ErrorMessage = "Please select a valid country.")]
		public string CountryID { get; set; }
		public Country Country { get; set; }

		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in (999)-999-9999 format.")]
		public string Phone { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property

		public ICollection<Registration> Registrations { get; set; }
	}
}