using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIRequest.StudentCourse
{
	public class StudentCourseRequest
	{
		[DataMember(Name = "studentId", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "studentId")]
		public Guid StudentId { get; set; }

		[DataMember(Name = "courseId", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "courseId")]
		public Guid CourseId { get; set; }
	}
}