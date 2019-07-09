using System.Runtime.Serialization;
using DemoAPI.Data.Models;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIResponse.Course
{
	[DataContract]
	public class CourseBaseResponse : BaseEntity
	{
		[DataMember(Name = "courseName")]
		[JsonProperty(PropertyName = "courseName")]
		public string CourseName { get; set; }
	}
}