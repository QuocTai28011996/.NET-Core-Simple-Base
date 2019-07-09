using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services
{
	public interface IStudentCourseService : IEntityService<StudentCourse>
	{
		//To-be Implement 
	}

	public class StudentCourseService : EntityService<StudentCourse>, IStudentCourseService
	{

	}
}