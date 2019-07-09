﻿using System;
using System.Runtime.Serialization;

namespace DemoAPI.Shared.APIResponse.Login
{
	/// <summary>
	/// Used in API/AuthController
	/// </summary>
	[DataContract]
	public class LoginResponse
	{
		[DataMember(Name = "token", EmitDefaultValue = false)]
		public string Token { get; set; }

		[DataMember(Name = "tokenType", EmitDefaultValue = false)]
		public string TokenType { get; set; }

		[DataMember(Name = "expiresIn", EmitDefaultValue = false)]
		public DateTimeOffset ExpiresIn { get; set; }

		[DataMember(Name = "refreshToken", EmitDefaultValue = false)]
		public string RefreshToken { get; set; }
	}
}