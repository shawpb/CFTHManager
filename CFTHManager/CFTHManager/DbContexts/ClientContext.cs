using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CFTHManager.Models;

namespace CFTHManager.DbContexts
{
	public class ClientContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Address> Addresses { get; set;}
		public DbSet<Client> Clients { get; set; }
	}
}