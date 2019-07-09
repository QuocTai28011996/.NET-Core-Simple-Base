using System;
using System.Net;
using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Data.Models;

namespace DemoAPI.Shared.Extensions
{
	public static class ResponseMessageExt
	{
		public static Exception ToException(this ResponseMessage message)
		{
			switch (message.StatusCode)
			{
				case HttpStatusCode.BadRequest:
					return new Exceptions.BadRequestException(message.ErrorMessage);
				case HttpStatusCode.Conflict:
					return new Exceptions.ConflictException(message.ErrorMessage);
				case HttpStatusCode.InternalServerError:
					return new InternalServerErrorException(message.ErrorMessage);
				default:
					return new SystemException(message.ErrorMessage);
			}
		}
	}
}