using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using DemoAPI.Data.Models;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIResponse.Student
{
	[DataContract]
	public class StudentBaseResponse : BaseEntity
	{
		[DataMember(Name = "studentName")]
		[JsonProperty(PropertyName = "studentName")]
		public string StudentName { get; set; }

		[DataMember(Name = "class")]
		[JsonProperty(PropertyName = "class")]
		public string Class { get; set; }
	}
}
