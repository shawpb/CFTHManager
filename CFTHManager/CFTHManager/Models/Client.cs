using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CFTHManager.Models
{
	public class Client
	{
		[Key]
		public int Id { get; set; }
		
		public int PersonalInformationId { get; set; }
		public int? AdvocateId { get; set; }
		public int? IntakePersonId { get; set; }
		public int? DataEntryPersonId { get; set; }


		public Person PersonalInformation { get; set; }
		public int FamilySize { get; set; }
		public Person Advocate { get; set; }
		public bool AgencyPickUp { get; set; }
		public bool CfhToDeliver { get; set; }
		public DateTime EnteredDate { get; set; }

		public Person IntakePerson { get; set; }
		public Person DataEntryPerson { get; set; }
	}
}