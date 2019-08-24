using DemoAPI.Shared.APIRequest.Course;
using DemoAPI.Shared.APIResponse.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DemoAPI.Shared.Services.APIs.Realizations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.API.Controllers
{
	[Produces("application/json")]
	[Route("api/v1/course")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		/// <summary>
		/// Create a new Course
		/// </summary>
		/// <param name="courseRequest">Name, Class</param>
		/// <returns></returns>

		[HttpPost("create")]
		[Produces("application/json")]
		[Authorize]
		public CourseBaseResponse Create([FromBody]CourseRequest courseRequest)
		{
			return _courseService.Create(courseRequest);
		}
	}
}
