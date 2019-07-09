using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DemoAPI.Data.Models.Database.Authorization
{
	[Table("User")]
	[DataContract]
	public class User : BaseEntity
	{
		[DataMember(Name = "displayName")]
		[MaxLength(40)]
		public string DisplayName { get; set; }

		[DataMember(Name = "passwordSalt")]
		[Required]
		public byte[] PasswordSalt { get; set; }

		[DataMember(Name = "passwordHash")]
		[Required]
		public byte[] PasswordHash { get; set; }

		[DataMember(Name = "allowTokensSince")]
		public DateTimeOffset? AllowTokensSince { get; set; }

		[DataMember(Name = "lastLogin")]
		public DateTimeOffset? LastLogin { get; set; }
	}
}
