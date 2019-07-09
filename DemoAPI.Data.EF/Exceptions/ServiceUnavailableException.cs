using System;

namespace DemoAPI.Data.EF.Exceptions
{
	public class ServiceUnavailableException : Exception
	{
		public ServiceUnavailableException(string message) : base(message)
		{
		}
	}
}