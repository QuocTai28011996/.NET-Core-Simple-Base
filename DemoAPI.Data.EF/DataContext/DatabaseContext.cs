using DemoAPI.Data.Models.Database;
using DemoAPI.Data.Models.Database.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoAPI.Data.EF.DataContext
{
	public class DatabaseContext : DbContext, IDataContext
	{
		public DbSet<User> Authorization { get; set; }

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<CourseTeacher> CourseTeachers { get; set; }
		public DbSet<Examination> Examinations { get; set; }
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Lecture> Lectures { get; set; }
		public DbSet<Teacher> Teachers { get; set; }

		private readonly IConfigurationRoot _configRoot;

		public DatabaseContext(IConfigurationRoot configRoot)
		{
			_configRoot = configRoot;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = _configRoot.GetConnectionString("DefaultConnection");
			optionsBuilder.UseMySql(connectionString);
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Attendance>().HasKey(a => new { a.StudentId, a.LectureId });
			modelBuilder.Entity<Grade>().HasKey(g => new { g.StudentId, g.GradingTeacherId, g.ExaminationId });
			modelBuilder.Entity<CourseTeacher>().HasKey(ct => new { ct.CourseId, ct.TeacherId});
		}
	}
}