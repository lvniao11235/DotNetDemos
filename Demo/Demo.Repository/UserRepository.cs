using System;
using System.Collections.Generic;
using System.Text;
using Demo.Model;
using System.Linq;

namespace Demo.Repository
{
	public class UserRepository
	{
		public DemoContext Context { get; set; }

		public User GetUser(string username, string password)
		{
			return Context.Users.FirstOrDefault(
				x => x.Username == username && x.Password == password);
		}

		public User GetUser(string username)
		{
			return Context.Users.FirstOrDefault(
				x => x.Username == username);
		}
	}
}
