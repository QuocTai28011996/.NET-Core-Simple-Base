using DemoAPI.Data.Models.Database;
using DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Service.Services.EntityService
{
	public interface ICourseEntityService : IEntityService<Course>
	{

	}

	public class CourseEntityService : EntityService<Course>, ICourseEntityService
	{

	}
}