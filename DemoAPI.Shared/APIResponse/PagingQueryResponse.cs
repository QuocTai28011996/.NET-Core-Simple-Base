using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DemoAPI.Shared.APIResponse
{
	[DataContract]
	public class PagingQueryResponse<T>
	{
		[DataMember(Name = "results")]
		public IEnumerable<T> Data { get; set; }

		[DataMember(Name = "pagination")]
		public PageInformation PageInformation { get; set; }
	}
}