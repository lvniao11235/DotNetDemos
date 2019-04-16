using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Demo.Model;

namespace Demo.Repository
{
	public class CustomerRepository
	{
		public DemoContext Context { get; set; }

        public List<Customer> GetCustomers()
        {
            return Context.Customers.ToList();
        }
	}
}
