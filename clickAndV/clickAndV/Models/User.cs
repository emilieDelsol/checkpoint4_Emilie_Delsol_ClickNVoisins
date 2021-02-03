using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CorrectionCheckpoint3.Models
{
    public class User : IdentityUser
    {
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public DateTime Birthday { get; set; }
		public String Address { get; set; }
		public Int32 PostalCode { get; set; }
		public String CountryCode { get; set; }
		public DateTime CreationDate { get; set; }
		public ICollection<Ad> Ads { get; set; } 
    }
}