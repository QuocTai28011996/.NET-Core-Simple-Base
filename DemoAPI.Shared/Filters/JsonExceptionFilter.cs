using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Shared.APIResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoAPI.Shared.Filters
{
	public class JsonExceptionFilter : IExceptionFilter
	{
		private const int BadRequestCode = 400;
		private const int SystemFailureCode = 500;
		private const int ConflictCode = 409;
		private const int NotFoundCode = 404;
		private const int ServiceUnavailableCode = 503;

		public void OnException(ExceptionContext context)
		{
			int code;
			switch (context.Exception)
			{
				case BadRequestException _:
					code = BadRequestCode;
					break;
				case ConflictException _:
					code = ConflictCode;
					break;
				case ServiceUnavailableException _:
					code = ServiceUnavailableCode;
					break;
				case DataNotFoundException _:
					code = NotFoundCode;
					break;
				default:
					code = SystemFailureCode;
					break;
			}

			var result = new ObjectResult(new ErrorResponse(context.Exception)) { StatusCode = code };
			context.Result = result;
		}
	}
}