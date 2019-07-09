using System.Runtime.Serialization;

namespace DemoAPI.Shared.APIRequest
{
	[DataContract]
	public class BasePagingQueryRequest
	{
		[DataMember(Name = "page")]
		public int Page { get; set; }

		[DataMember(Name = "limit")]
		public int Limit { get; set; }
	}
}