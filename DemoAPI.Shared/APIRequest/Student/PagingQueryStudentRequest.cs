using System.Runtime.Serialization;

namespace DemoAPI.Shared.APIRequest.Student
{
	[DataContract]
	public class PagingQueryStudentRequest : BasePagingQueryRequest
	{
		[DataMember(Name = "studentName")]
		public string StudentName { get; set; }

		[DataMember(Name = "class")]
		public string Class { get; set; }

		[DataMember(Name = "order")]
		public string Order { get; set; }
	}
}