using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;

namespace AuthenticationCenter
{
	public class RegisterModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly)
				.Where(t => t.Name.EndsWith("Controller"))
				.PropertiesAutowired();
		}
	}
}
