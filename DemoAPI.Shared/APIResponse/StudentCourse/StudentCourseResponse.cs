using System.Collections.Generic;
using System.Runtime.Serialization;
using DemoAPI.Data.Models;
using DemoAPI.Shared.APIResponse.Course;
using DemoAPI.Shared.APIResponse.Student;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIResponse.StudentCourse
{
	public class StudentCourseResponse
	{
		[DataMember(Name = "student")]
		[JsonProperty(PropertyName = "student")]
		public StudentBaseResponse Student { get; set; }

		[DataMember(Name = "registedCourses")]
		[JsonProperty(PropertyName = "registedCourses")]
		public IEnumerable<CourseBaseResponse> Courses { get; set; }
	}
}
