using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services
{
	public interface ICourseService : IEntityService<Course>
	{

	}

	public class CourseService : EntityService<Course>, ICourseService
	{

	}
}