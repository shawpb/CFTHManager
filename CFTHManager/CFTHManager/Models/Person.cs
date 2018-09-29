using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CFTHManager.Models
{
	public class Person
	{
		public int Id { get; set; }
		[Display(Name ="First Name")]
		public string FirstName { get; set; }
		[Display(Name ="Last Name")]
		public string LastName { get; set; }
		[Key]
		public Address MainAddress { get; set; }
		[Display(Name ="Phone Number")]
		public string PhoneNumber { get; set; }
		[Display(Name ="Email Address")]
		public string EmailAddress { get; set; }

		public Person()
		{
			this.MainAddress = new Address();
		}
	}
}