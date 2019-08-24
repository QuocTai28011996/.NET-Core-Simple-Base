using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services.EntityService
{
	public interface IStudentCourseEntityService : IEntityService<StudentCourse>
	{
		//To-be Implement 
	}

	public class StudentCourseEntityService : EntityService<StudentCourse>, IStudentCourseEntityService
	{

	}
}