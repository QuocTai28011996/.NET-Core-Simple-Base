using System;
using System.Runtime.Serialization;
using DemoAPI.Shared.Models;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIResponse.Login
{
	[DataContract]
	public class RegisterResponse
	{
		[DataMember(Name = "token", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "access_token")]
		public Token Token { get; set; }

		[DataMember(Name = "profile", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "profile")]
		public UserProfileResponse Profile { get; set; }

		[DataMember(Name = "tokenType", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "token_type")]
		public string TokenType { get; set; }

		[DataMember(Name = "expiresIn", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "expires_in")]
		public DateTimeOffset ExpiresIn { get; set; }

		[DataMember(Name = "refreshToke", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "refresh_token")]
		public string RefreshToken { get; set; }
	}
}