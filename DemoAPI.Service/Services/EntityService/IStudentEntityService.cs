using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services.EntityService
{
	public interface IStudentEntityService : IEntityService<Student>
	{
		
	}

	public class StudentEntityService : EntityService<Student>, IStudentEntityService
	{
		
	}
}