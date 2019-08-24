using DemoAPI.Data.EF;
using DemoAPI.Shared.Authorization.Handlers;
using DemoAPI.Shared.Filters;
using DemoAPI.Shared.Helpers;
using DemoAPI.Util.Utils;
using DemoAPI.Shared.Extensions;
using DemoAPI.Data.EF.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace DemoAPI.API
{
	public class Startup
	{
		private IConfiguration ConfigRoot { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();
			ConfigRoot = builder.Build();
			AutoMapperConfig.RegisterModel();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton((IConfigurationRoot)ConfigRoot);
			services.AddCors();
			services.AddSingleton(ConfigRoot);
			services.AddSingleton<IAuthorizationHandler, ClientHandler>();
			services.AddWebDataLayer();

			services.AddMvc(ConfigureMvc)
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.NullValueHandling = NullValueHandling.Include;

				});
			services.AddMvc().AddJsonOptions(
				options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info { Title = "Demo.API", Version = "v1" });
				//var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				//var xmlPath = Path.Combine(basePath, "Demo.API.xml");
				//options.IncludeXmlComments(xmlPath);
				//options.CustomSchemaIds(x => x.FullName);
			});

			services.AddAuthentication(JwtHelper.ConfigureAuthenticationOptions)
				.AddJwtBearer(Const.Jwt.DefaultScheme, JwtHelper.ConfigureJwtBearerOptions);

			////Use raven to send logs to sentry.io
			//services.Configure<RavenOptions>(ConfigRoot.GetSection("RavenOptions"));
			//Add HTTPContextAccessor as Singleton
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			//Configure RavenClient

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			ServiceProviderHelper.Init(app.ApplicationServices);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(ConfigureCors);
			app.UseAuthentication();
			app.UseMvc();
			app.UseStaticFiles();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo.API v1");
			});
		}



		private void ConfigureCors(CorsPolicyBuilder builder)
		{
			builder
				.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials();
		}

		public static void ConfigureMvc(MvcOptions options)
		{
			options.Filters.Add<JsonExceptionFilter>();
		}
	}
}
