using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.WebUI.Models;
using Demo.Repository;

namespace Demo.WebUI.Controllers
{
	public class HomeController : Controller
	{
		public CustomerRepository Customer { get; set; }

		//public HomeController(CustomerRepository customer)
		//{
		//	this.Customer = customer;

		//}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
