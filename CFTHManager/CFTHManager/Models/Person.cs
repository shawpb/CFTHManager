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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Key]
		public Address MainAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }

		public Person()
		{
			this.MainAddress = new Address();
		}
	}
}