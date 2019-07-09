using System.Collections.Generic;
using DemoAPI.Shared.APIRequest.Student;
using DemoAPI.Shared.APIResponse;
using DemoAPI.Shared.APIResponse.Student;

namespace DemoAPI.Shared.Services.APIs
{
	public interface IStudentService
	{
		StudentBaseResponse Create(StudentRequest student);
		PagingQueryResponse<StudentBaseResponse> GetStudentForPaging(IDictionary<string, string> @params);
		StudentBaseResponse GetAStudent(StudentRequest student);
	}
}