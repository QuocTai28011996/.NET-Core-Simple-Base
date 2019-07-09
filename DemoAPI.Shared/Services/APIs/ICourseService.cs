using System.Collections.Generic;
using DemoAPI.Shared.APIRequest.Course;
using DemoAPI.Shared.APIResponse;
using DemoAPI.Shared.APIResponse.Course;

namespace DemoAPI.Shared.Services.APIs
{
	public interface ICourseService
	{
		CourseBaseResponse Create(CourseRequest courseRequest);
		PagingQueryResponse<CourseBaseResponse> GetListOfCourse(IDictionary<string, string> @params);
	}
}