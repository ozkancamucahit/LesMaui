using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DTOS
{
	public sealed class PhotoReadDTO
	{
        public int Id { get; set; }

        public string FilePath { get; set; } = String.Empty;

		private DateTime _createdDate;

		public DateTime CreatedDate
		{
			get { return _createdDate.ToLocalTime(); }
			set { _createdDate = value; }
		}

	}
}
