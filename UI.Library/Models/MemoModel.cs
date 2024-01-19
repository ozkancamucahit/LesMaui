using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UI.Library.Models
{
	public class MemoModel
	{

		public int Id { get; set; }
		public int UserId { get; set; }

		public string CityId { get; set; } = String.Empty;

		public DateTime MemoDate { get; set; }

		public string UserName { get; set; } = String.Empty;

		public string PhotoFilePath { get; set; } = String.Empty;

		public string About { get; set; } = String.Empty;

		public DateTime? PhotoCreateDate { get; set; }
	}

	[JsonSerializable(typeof(List<MemoModel>))]
	public sealed partial class MemoContext : JsonSerializerContext
	{

	}
}
