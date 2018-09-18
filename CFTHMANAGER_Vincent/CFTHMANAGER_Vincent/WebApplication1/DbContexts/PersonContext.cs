using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DbContexts
{
	public class PersonContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}