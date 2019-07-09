using System;
using System.Linq;
using System.Reflection;
using DemoAPI.Data.EF.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAPI.Shared.Extensions
{
	public static class ServiceCollectionExt
	{
		public static IServiceCollection AddWebDataLayer(this IServiceCollection services)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var interfaceAssemblies = new[] { typeof(ServiceCollectionExt).GetTypeInfo().Assembly, typeof(Service.Services.IStudentService).GetTypeInfo().Assembly };

			foreach (var assembly in assemblies.Where(m => m.FullName.Contains("DemoAPI")))
			{
				foreach (var interfaceAssembly in interfaceAssemblies)
				{
					services.AddSingletonsByConvention(interfaceAssembly, assembly, x => x.Name.EndsWith("Service"));
				}
			}

			return services;
		}
	}
}