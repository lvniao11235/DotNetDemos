using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.WebUI.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4;
using IdentityServer4.AspNetIdentity;

namespace Demo.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
	{
		public CustomerRepository Customer { get; set; }
        
		public IActionResult Index()
		{
			return View(Customer.GetCustomers());
		}
        
	}
}
