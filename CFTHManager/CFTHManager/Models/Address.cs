using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CFTHManager.Models
{
	public class Address
	{
		[ReadOnly(true)]
		public int Id { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		[DisplayName("Apartment Number")]
		public string ApartmentNumber { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
	}
}