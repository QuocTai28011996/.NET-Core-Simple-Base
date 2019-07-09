using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAPI.Data.EF.Extensions
{
	public static class ServiceCollectionExt
	{
		public static IServiceCollection AddSingletonsByConvention(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementationAssembly, Func<Type, bool> interfacePredicate, Func<Type, bool> implementationPredicate)
		{
			var interfaces = interfaceAssembly.ExportedTypes
				.Where(x => x.IsInterface && interfacePredicate(x))
				.ToList();
			var implementations = implementationAssembly.ExportedTypes
				.Where(x => !x.IsInterface && !x.IsAbstract && implementationPredicate(x))
				.ToList();
			foreach (var @interface in interfaces)
			{
				var implementation = implementations.FirstOrDefault(x => @interface.IsAssignableFrom(x));
				if (implementation == null)
				{
					continue;
				}

				services.AddSingleton(@interface, implementation);
			}

			return services;
		}

		public static IServiceCollection AddSingletonsByConvention(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementationAssembly, Func<Type, bool> predicate)
			=> services.AddSingletonsByConvention(interfaceAssembly, implementationAssembly, predicate, predicate);
	}
}