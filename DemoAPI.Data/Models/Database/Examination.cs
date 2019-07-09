using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Examination")]
	public class Examination : BaseEntity
	{
		[ForeignKey("Course")]
		public Guid CourseId { get; set; }

		[ForeignKey("Teacher")]
		public Guid ResponsibleTeacherId { get; set; }

		public string Description { get; set; }

		[Required]
		public string Date { get; set; }

		public Course Course { get; set; }
		public Teacher Teacher { get; set; }

		public virtual ICollection<Grade> Grades { get; set; }
	}
}
