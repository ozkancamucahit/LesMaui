using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{
	public interface IUserEndPoint
	{

		Task <UserModel> GetUser(string UserName);

		Task <bool> SaveUser(string UserName);

	}
}
