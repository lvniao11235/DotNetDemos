using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Model;

namespace Demo.Repository
{
    public class SeedData
    {
        public static void Seed(DemoContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(customers);
            }
            context.SaveChanges();
        }

        private static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Name="aa"},
            new Customer(){Name="bb"},
            new Customer(){Name="cc"},
            new Customer(){Name="dd"},
        };
    }
}
