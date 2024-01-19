using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DTOS
{
	public sealed class UserCreateDTO
	{

        private string _userName = String.Empty;

		public string UserName
		{
			get { return _userName; }
			set { _userName = value.Trim().Replace(" ", ""); }
		}


	}
}
