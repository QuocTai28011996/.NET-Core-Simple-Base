using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Data.Models;
using DemoAPI.Shared.APIResponse.StudentCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.API.Controllers
{
	[Produces("application/json")]
	[Route("api/v1/studentCourse")]
	[ApiController]
	public class StudentCourseController : ControllerBase
	{
		private readonly Shared.Services.APIs.IStudentCourseService _studentCourseService;

		public StudentCourseController(Shared.Services.APIs.IStudentCourseService studentCourseService)
		{
			_studentCourseService = studentCourseService;
		}

		/// <summary>
		/// Create a new Student
		/// </summary>
		/// <param name="studentId"></param>
		/// <param name="courseId"></param>
		/// <returns></returns>

		[HttpPost("registerCourse")]
		[Produces("application/json")]
		[Authorize]
		public ResponseMessage RegisterACourseForAStudent(Guid studentId, Guid courseId)
		{
			return _studentCourseService.RegisterACourseForAStudent(studentId, courseId);
		}

		/// <summary>
		/// Get List of Course of A Student
		/// </summary>
		/// <param name="studentId"></param>
		/// <returns></returns>

		[HttpGet("getCourses")]
		[Produces("application/json")]
		[Authorize]
		public StudentCourseResponse GetListOfCourseOfAStudent(string studentId)
		{
			return _studentCourseService.GetListOfCourseOfAStudent(studentId);
		}
	}
}
