using System;
using DemoAPI.Data.Models;
using DemoAPI.Shared.APIRequest.StudentCourse;
using DemoAPI.Shared.APIResponse.StudentCourse;

namespace DemoAPI.Shared.Services.APIs
{
	public interface IStudentCourseService
	{
		ResponseMessage RegisterACourseForAStudent(Guid studentId, Guid courseId);
		StudentCourseResponse GetListOfCourseOfAStudent(string studentId);
	}
}