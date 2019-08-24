using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services
{
	public interface IStudentCourseEntityService : IEntityService<StudentCourse>
	{
		//To-be Implement 
	}

	public class StudentCourseEntityService : EntityService<StudentCourse>, IStudentCourseEntityService
	{

	}
}