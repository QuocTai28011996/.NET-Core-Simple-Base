﻿using System;

namespace DemoAPI.Shared.APIResponse
{
	public class ErrorResponse
	{
		public string Type { get; set; }
		public string Message { get; set; }

		public ErrorResponse(Exception exception)
		{
			Type = exception.GetType().Name;
			Message = exception.Message;
		}

		public ErrorResponse()
		{
		}
	}
}