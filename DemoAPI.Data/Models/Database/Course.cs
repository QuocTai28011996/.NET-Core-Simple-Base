using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Course")]
	public class Course : BaseEntity
	{
		[Required]
		public string CourseName { get; set; }

		public virtual ICollection<StudentCourse> StudentCourse { get; set; }
		public virtual ICollection<Lecture> Lectures { get; set; }
		public virtual ICollection<Examination> Examinations { get; set; }
		public virtual ICollection<CourseTeacher> CourseTeacher { get; set; }
	}
}
