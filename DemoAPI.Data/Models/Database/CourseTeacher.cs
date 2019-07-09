using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("CourseTeacher")]
	public class CourseTeacher
	{
		[Key]
		[Column(Order = 1)]
		[ForeignKey("Course")]
		public Guid CourseId { get; set; }

		[Key]
		[Column(Order = 2)]
		[ForeignKey("Teacher")]
		public Guid TeacherId { get; set; }
		
		[Required]
		public string StartDate { get; set; }

		[Required]
		public string EndDate { get; set; }

		public Course Course { get; set; }
		public Teacher Teacher { get; set; }
	}
}
