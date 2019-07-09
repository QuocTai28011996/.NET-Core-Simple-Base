using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoAPI.Shared.APIRequest.Login
{
	[DataContract]
	public class UserProfileRequest
	{
		[DataMember(Name = "displayName")]
		public string DisplayName { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }
	}
}
