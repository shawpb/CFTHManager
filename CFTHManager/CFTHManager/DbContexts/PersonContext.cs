using System.Data.Entity;
using CFTHManager.Models;

namespace CFTHManager.DbContexts
{
	public class PersonContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}