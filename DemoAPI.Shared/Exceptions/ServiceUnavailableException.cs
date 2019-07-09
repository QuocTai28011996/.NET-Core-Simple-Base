using System;

namespace DemoAPI.Shared.Exceptions
{
	public class ServiceUnavailableException : Exception
	{
		public ServiceUnavailableException(string message) : base(message)
		{
		}
	}
}