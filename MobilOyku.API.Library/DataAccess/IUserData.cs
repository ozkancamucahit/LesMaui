using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Models;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IUserData
	{
		Task<UserModel> GetUserByUserName(string UserName);

		Task<bool> SaveUser(UserCreateDTO user);
	}
}