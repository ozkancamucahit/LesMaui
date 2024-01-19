using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DTOS
{
	public sealed class MemoReadDTO
	{
        public int Id { get; set; }

        public string CityId { get; set; } = String.Empty;

		private DateTime _memoDate;

		public DateTime MemoDate
		{
			get { return _memoDate.ToLocalTime(); }
			set { _memoDate = value; }
		}

        public string UserName { get; set; } = String.Empty;
        public int UserId { get; set; }

		public string PhotoFilePath { get; set; } = String.Empty;

		public string About { get; set; } = String.Empty;


        private DateTime? _photoCreateDate;

		public DateTime? PhotoCreateDate
		{
			get { return _photoCreateDate?.ToLocalTime(); }
			set { _photoCreateDate = value; }
		}




	}
}
