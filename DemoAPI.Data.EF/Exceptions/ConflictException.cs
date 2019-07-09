using System;

namespace DemoAPI.Data.EF.Exceptions
{
	public class ConflictException : Exception
	{
		public ConflictException(string message) : base(message)
		{
		}
	}
}