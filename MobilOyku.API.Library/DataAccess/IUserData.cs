using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Models;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IUserData
	{
		UserModel GetUserByUserName(string UserName);

		bool SaveUser(UserCreateDTO user);
	}
}