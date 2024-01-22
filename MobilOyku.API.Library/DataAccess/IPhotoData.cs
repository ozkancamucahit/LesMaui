using MobilOyku.API.Library.DTOS;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IPhotoData
	{
		Task<IEnumerable<MemoReadDTO>> GetMemos(string UserName);
		Task<bool> SavePhoto(PhotoCreateDTO photo);

		Task<bool> RemovePhoto(PhotoDeleteDTO photo);

	}
}