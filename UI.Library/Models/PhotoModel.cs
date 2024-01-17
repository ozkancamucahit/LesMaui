using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.Models
{
	public sealed class PhotoModel
	{
		public int Id { get; set; }

		public string FilePath { get; set; } = String.Empty;

		public DateTime CreatedDate { get; set; }
	}
}
