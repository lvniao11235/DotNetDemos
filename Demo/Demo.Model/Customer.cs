using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Model
{
	public class Customer
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool Vip { get; set; }
	}
}
