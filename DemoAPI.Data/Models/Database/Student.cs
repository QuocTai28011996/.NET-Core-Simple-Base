using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Student")]
	public class Student : BaseEntity
	{
		[Required]
		public string StudentName { get; set; }

		[Required]
		public string Class { get; set; }

		public virtual ICollection<StudentCourse> StudentCourse { get; set; }
		public virtual ICollection<Attendance> Attendances { get; set; }
		public virtual ICollection<Grade> Grades { get; set; }
	}
}
