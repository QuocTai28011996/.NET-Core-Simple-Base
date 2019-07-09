using System.Runtime.Serialization;

namespace DemoAPI.Shared.APIResponse
{
	[DataContract]
	public class PageInformation
	{
		[DataMember(Name = "totals", EmitDefaultValue = false)]
		public int Total { get; set; }

		[DataMember(Name = "page", EmitDefaultValue = false)]
		public int Page { get; set; }

		[DataMember(Name = "limit", EmitDefaultValue = false)]
		public int Limit { get; set; }
	}
}