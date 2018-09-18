using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Address
	{
		[ReadOnly(true)]
		[ScaffoldColumn(false)]
		public int Id { get; set; }
		//[ReadOnly(true)]
		//[ScaffoldColumn(false)]
		//public int PersonId { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
	}
}