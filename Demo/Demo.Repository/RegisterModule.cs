using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Reflection;

namespace Demo.Repository
{
	public class RegisterModule:Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.PropertiesAutowired();
		}
	}
}
