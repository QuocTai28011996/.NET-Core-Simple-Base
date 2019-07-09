using System;

namespace DemoAPI.Data.EF.Exceptions
{
	public class SmsException : Exception
	{
		public SmsException(string message) : base(message)
		{
		}
	}
}