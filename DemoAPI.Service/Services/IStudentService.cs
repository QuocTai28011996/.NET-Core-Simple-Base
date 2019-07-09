using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services
{
	public interface IStudentService : IEntityService<Student>
	{
		
	}

	public class StudentService : EntityService<Student>, IStudentService
	{
		
	}
}