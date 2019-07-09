using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoAPI.Data.Models.Database
{
	[Table("Grade")]
	public class Grade
	{
		[Key]
		[Column(Order = 1)]
		[ForeignKey("Examination")]
		public Guid ExaminationId { get; set; }

		[Key]
		[Column(Order = 2)]
		[ForeignKey("Student")]
		public Guid StudentId { get; set; }

		[Key]
		[Column(Order = 3)]
		[ForeignKey("Teacher")]
		public Guid GradingTeacherId { get; set; }

		[Required]
		public byte StudentGrade { get; set; }


		public Examination Examination { get; set; }
		public Student Student { get; set; }
		public Teacher Teacher { get; set; }
	}
}
