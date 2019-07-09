using System;

namespace DemoAPI.Data.EF.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{
		}
	}
}