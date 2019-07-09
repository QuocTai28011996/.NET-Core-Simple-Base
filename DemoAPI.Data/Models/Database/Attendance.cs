using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Attendance")]
	public class Attendance
	{
		[Key]
		[Column(Order = 1)]
		[ForeignKey("Student")]
		public Guid StudentId { get; set; }

		[Key]
		[Column(Order = 2)]
		[ForeignKey("Lecture")]
		public Guid LectureId { get; set; }

		public Student Student { get; set; }
		public Lecture Lecture { get; set; }

		[Required]
		public bool IsAttendance { get; set; }
	}
}
