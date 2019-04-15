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
	}
}
