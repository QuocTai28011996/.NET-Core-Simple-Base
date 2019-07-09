using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("StudentCourse")]
	public class StudentCourse : BaseEntity
	{
		public Guid StudentId { get; set; }

		public Guid CourseId { get; set; }

		public virtual Student Student { get; set; }
		public virtual Course Course { get; set; }
	}
}
