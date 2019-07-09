using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DemoAPI.Shared.APIResponse.Login
{
	[DataContract]
	public class UserProfileResponse
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "displayName")]
		public string DisplayName { get; set; }
	}
}