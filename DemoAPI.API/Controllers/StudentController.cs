using System.Collections.Generic;
using DemoAPI.Shared.APIRequest.Student;
using DemoAPI.Shared.APIResponse;
using DemoAPI.Shared.APIResponse.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DemoAPI.Shared.Services.APIs.Realizations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.API.Controllers
{
	[Produces("application/json")]
	[Route("api/v1/student")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		/// <summary>
		/// Create a new Student
		/// </summary>
		/// <param name="studentRequest">Name, Class</param>
		/// <returns></returns>

		[HttpPost("create")]
		[Produces("application/json")]
		[Authorize]
		public StudentBaseResponse Create([FromBody]StudentRequest studentRequest)
		{
			return _studentService.Create(studentRequest);
		}

		/// <summary>
		/// Get a List of Student with param object that include: order
		/// </summary>
		/// <param name="params"></param>
		/// <returns></returns>

		[HttpGet("list")]
		[Produces("application/json")]
		[Authorize]
		public PagingQueryResponse<StudentBaseResponse> GetListOfStudent([FromHeader]IDictionary<string, string> @params)
		{
			return _studentService.GetStudentForPaging(@params);
		}
	}
}
