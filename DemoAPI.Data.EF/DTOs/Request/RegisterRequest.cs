using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DemoAPI.Data.EF.DTOs.Request
{
	/// <summary>
	/// Used for AuthController
	/// </summary>
	[DataContract]
	public class RegisterRequest
	{
		[DataMember(Name = "username", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "username")]
		public string Username { get; set; }

		[DataMember(Name = "password", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "password")]
		public string Password { get; set; }

		[DataMember(Name = "passwordRetype", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "passwordRetype")]
		public string PasswordRetype { get; set; }
	}
}