using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIRequest.Student
{
	public class StudentRequest
	{
		[DataMember(Name = "studentId", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "studentId")]
		public Guid Id { get; set; }

		[DataMember(Name = "studentName", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "studentName")]
		public string StudentName { get; set; }

		[DataMember(Name = "class", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "class")]
		public string Class { get; set; }
	}
}
