using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DemoAPI.Shared.APIRequest.Course;
using DemoAPI.Shared.APIRequest.Login;
using DemoAPI.Shared.APIRequest.Student;
using DemoAPI.Shared.APIResponse.Course;
using DemoAPI.Shared.APIResponse.Login;
using DemoAPI.Shared.APIResponse.Student;

namespace DemoAPI.API
{
	public static class AutoMapperConfig
	{
		public static void RegisterModel()
		{
			var cfg = new MapperConfigurationExpression();

			#region Student

			cfg.CreateMap<Data.Models.Database.Student, StudentRequest>();
			cfg.CreateMap<Data.Models.Database.Student, StudentBaseResponse>();
			cfg.CreateMap<StudentBaseResponse, Data.Models.Database.Student>();
			cfg.CreateMap<StudentRequest, Data.Models.Database.Student>();

			#endregion


			#region Course

			cfg.CreateMap<Data.Models.Database.Course, CourseRequest>();
			cfg.CreateMap<Data.Models.Database.Course, CourseBaseResponse>();
			cfg.CreateMap<CourseBaseResponse, Data.Models.Database.Course>();
			cfg.CreateMap<CourseRequest, Data.Models.Database.Course>();

			#endregion

			Mapper.Initialize(cfg);
		}
	}
}
