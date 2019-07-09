using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIRequest.Course
{
	public class CourseRequest
	{
		[DataMember(Name = "courseId", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "courseId")]
		public Guid Id { get; set; }

		[DataMember(Name = "courseName", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "courseName")]
		public string CourseName { get; set; }
	}
}