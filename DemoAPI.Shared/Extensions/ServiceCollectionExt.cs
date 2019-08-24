using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAPI.Shared.Extensions
{
	public static class ServiceCollectionExt
	{
		public static IServiceCollection AddWebDataLayer(this IServiceCollection services)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var interfaceAssemblies = new[] { typeof(ServiceCollectionExt).GetTypeInfo().Assembly, typeof(IServiceCollection).GetTypeInfo().Assembly };

			foreach (var assembly in assemblies.Where(m => m.FullName.Contains("DemoAPI")))
			{
				foreach (var interfaceAssembly in interfaceAssemblies)
				{
					services.AddSingletonsByConvention(interfaceAssembly, assembly, x => x.Name.EndsWith("Service"));
				}
			}

			return services;
		}

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