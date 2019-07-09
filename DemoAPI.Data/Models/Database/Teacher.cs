using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Teacher")]
	public class Teacher : BaseEntity
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Mentor { get; set; }

		public virtual ICollection<Lecture> Lectures { get; set; }
		public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
		public virtual ICollection<Grade> Grades { get; set; }
		public virtual ICollection<Examination> Examinations { get; set; }

	}
}
