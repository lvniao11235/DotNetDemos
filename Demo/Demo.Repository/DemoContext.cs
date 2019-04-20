using System;
using Microsoft.EntityFrameworkCore;
using Demo.Model;

namespace Demo.Repository
{
	public class DemoContext : DbContext
	{
		public DemoContext(DbContextOptions<DemoContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }

		public DbSet<User> Users { get; set; }
	}
}
