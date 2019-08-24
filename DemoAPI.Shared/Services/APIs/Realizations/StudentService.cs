using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DemoAPI.Data;
using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Data.Models.Database;
using DemoAPI.Shared.APIRequest.Student;
using DemoAPI.Shared.APIResponse;
using DemoAPI.Shared.APIResponse.Student;
using DemoAPI.Shared.Constants;
using DemoAPI.Shared.Extensions;
using DemoAPI.Util.Constants;
using DbService = DemoAPI.Service.Services;

namespace DemoAPI.Shared.Services.APIs.Realizations
{
	public interface IStudentService
	{
		StudentBaseResponse Create(StudentRequest student);
		PagingQueryResponse<StudentBaseResponse> GetStudentForPaging(IDictionary<string, string> @params);
		StudentBaseResponse GetAStudent(StudentRequest student);
	}

	public class StudentService: IStudentService
	{
		private readonly DbService.IStudentEntityService _studentService;

		public StudentService(DbService.IStudentEntityService studentService)
		{
			_studentService = studentService;
		}

		public StudentBaseResponse Create(StudentRequest studentRequest)
		{
			studentRequest.Id = Guid.NewGuid();
			var student = Mapper.Map<Student>(studentRequest);

			_studentService.Create(student, out var isStudentSaved);

			if (isStudentSaved == false) throw new InternalServerErrorException(CommonConstant.Error.InternalServerError);

			return Mapper.Map<StudentBaseResponse>(student);
		}

		public PagingQueryResponse<StudentBaseResponse> GetStudentForPaging(IDictionary<string, string> @params)
		{
			var request = @params.ToObject<PagingQueryStudentRequest>();

			var students = GetPagedStudents(request, out var total);

			return new PagingQueryResponse<StudentBaseResponse>
			{
				Data = students,
				PageInformation = new PageInformation
				{
					Total = total,
					Page = request.Page,
					Limit = request.Limit
				}
			};
		}

		public StudentBaseResponse GetAStudent(StudentRequest student)
		{
			throw new NotImplementedException();
		}

		private List<StudentBaseResponse> GetPagedStudents(PagingQueryStudentRequest pagingRequest, out int total)
		{
			var students = _studentService.Where(x => x.EntityStatus == EntityStatus.Activated);

			//filter students by properties
			students = SortStudent(pagingRequest, students);

			var studentList = students.ToList();
			total = studentList.Count();

			return studentList
				.Select(Mapper.Map<StudentBaseResponse>)
				.ToList();
		}

		private IQueryable<Student> SortStudent(PagingQueryStudentRequest request, IQueryable<Student> students)
		{
			if (!string.IsNullOrEmpty(request.Order) && request.Order == ServiceConst.ASC)
			{
				students = students.OrderBy(x => x.StudentName);
			}
			else
			{
				students = students.OrderByDescending(x => x.StudentName);
			}

			return students;
		}
	}
}
