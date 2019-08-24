using System;
using System.Collections.Generic;
using AutoMapper;
using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Data.Models.Database;
using DemoAPI.Shared.APIRequest.Course;
using DemoAPI.Shared.APIResponse;
using DemoAPI.Shared.APIResponse.Course;
using DemoAPI.Util.Constants;
using DbService = DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Shared.Services.APIs.Realizations
{
	public interface ICourseService
	{
		CourseBaseResponse Create(CourseRequest courseRequest);
		PagingQueryResponse<CourseBaseResponse> GetListOfCourse(IDictionary<string, string> @params);
	}

	public class CourseService : ICourseService
	{
		private readonly DbService.ICourseEntityService _courseService;

		public CourseService(DbService.ICourseEntityService courseService)
		{
			_courseService = courseService;
		}
		public CourseBaseResponse Create(CourseRequest courseRequest)
		{
			courseRequest.Id = Guid.NewGuid();
			var course = Mapper.Map<Course>(courseRequest);

			_courseService.Create(course, out var isStudentSaved);

			if (isStudentSaved == false) throw new InternalServerErrorException(CommonConstant.Error.InternalServerError);

			return Mapper.Map<CourseBaseResponse>(course);
		}

		public PagingQueryResponse<CourseBaseResponse> GetListOfCourse(IDictionary<string, string> @params)
		{
			throw new NotImplementedException();
		}
	}
}
