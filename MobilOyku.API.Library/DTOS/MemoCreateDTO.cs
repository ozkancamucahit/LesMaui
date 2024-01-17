using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DTOS
{
	public sealed class MemoCreateDTO
	{
		public int UserId { get; set; }

		private string _about = String.Empty;

		public string About
		{
			get { return _about.Trim(); }
			set { _about = value.Trim(); }
		}


	}
}
