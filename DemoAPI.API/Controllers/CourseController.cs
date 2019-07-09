using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DemoAPI.Shared.APIRequest.Course;
using DemoAPI.Shared.APIRequest.Student;
using DemoAPI.Shared.APIResponse.Course;
using DemoAPI.Shared.APIResponse.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.API.Controllers
{
	[Produces("application/json")]
	[Route("api/v1/course")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly Shared.Services.APIs.ICourseService _courseService;

		public CourseController(Shared.Services.APIs.ICourseService courseService)
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
