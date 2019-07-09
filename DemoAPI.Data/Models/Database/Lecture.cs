using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Lecture")]
	public class Lecture : BaseEntity
	{
		public string Room { get; set; }

		[ForeignKey("Course"), Column(Order = 0)]
		public Guid CourseId { get; set; }

		[ForeignKey("Teacher"), Column(Order = 1)]
		public Guid TeacherId { get; set; }

		public Course Course { get; set; }
		public Teacher Teacher { get; set; }

		public virtual ICollection<Attendance> Attendances { get; set; }
	}
}
