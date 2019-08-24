using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using DemoAPI.Data;
using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Data.EF.Extensions;
using DemoAPI.Data.Models;
using DemoAPI.Data.Models.Database;
using DemoAPI.Shared.APIResponse.Course;
using DemoAPI.Shared.APIResponse.Student;
using DemoAPI.Shared.APIResponse.StudentCourse;
using DemoAPI.Util.Constants;
using Microsoft.EntityFrameworkCore;
using DbService = DemoAPI.Service.Services.EntityService;

namespace DemoAPI.Shared.Services.APIs.Realizations
{
	public interface IStudentCourseService
	{
		ResponseMessage RegisterACourseForAStudent(Guid studentId, Guid courseId);
		StudentCourseResponse GetListOfCourseOfAStudent(string studentId);
	}

	public class StudentCourseService : IStudentCourseService
	{
		private readonly DbService.IStudentEntityService _studentService;
		private readonly DbService.ICourseEntityService _courseService;
		private readonly DbService.IStudentCourseEntityService _studentCourseService;

		public StudentCourseService(DbService.IStudentEntityService studentService, DbService.ICourseEntityService courseService, DbService.IStudentCourseEntityService studentCourseService)
		{
			_studentService = studentService;
			_courseService = courseService;
			_studentCourseService = studentCourseService;
		}

		public ResponseMessage RegisterACourseForAStudent(Guid studentId, Guid courseId)
		{
			var studentCourses = _studentCourseService.Where(x => x.StudentId.Equals(studentId) && x.CourseId.Equals(courseId));

			if (studentCourses.Any())
			{
				//Register one more time to Un-Register
				var isDeleted = _studentCourseService.DeletePermanent(studentCourses.First());
				return isDeleted
					? new ResponseMessage(HttpStatusCode.OK, data: "UnRegistered Successfully")
					: new ResponseMessage(HttpStatusCode.BadRequest, CommonConstant.Error.NotFound);
			}

			var studentCourse = _studentCourseService.Create(new StudentCourse { StudentId = studentId, CourseId = courseId }, out var isSaved);
			studentCourse.Id = new Guid();
			studentCourse = _studentCourseService.Include(x => x.Student).Include(x => x.Course).Find(studentCourse.Id);

			return isSaved
				? new ResponseMessage(HttpStatusCode.OK, data: "Registered Successfully")
				: new ResponseMessage(HttpStatusCode.BadRequest, CommonConstant.Error.BadRequest);
		}

		public StudentCourseResponse GetListOfCourseOfAStudent(string studentId)
		{
			if (Guid.TryParse(studentId, out var id))
			{
				var student = _studentService.Find(id);
				var studentCourses = _studentCourseService.Where(x => x.StudentId == id).Select(x => x.CourseId).ToList();

				var courseList = new List<Course>();
				foreach (var studentCourseId in studentCourses)
				{
					var course = _courseService.Find(studentCourseId);
					courseList.Add(course);
				}

				return new StudentCourseResponse()
				{
					Courses = Mapper.Map<IEnumerable<CourseBaseResponse>>(courseList),
					Student = Mapper.Map<StudentBaseResponse>(student)
				};
			}
			throw new BadRequestException(CommonConstant.Error.InvalidInput);
		}
	}
}
