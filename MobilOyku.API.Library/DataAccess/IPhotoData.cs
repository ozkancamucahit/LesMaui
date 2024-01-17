using MobilOyku.API.Library.DTOS;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IPhotoData
	{
		IEnumerable<MemoReadDTO> GetMemos(string UserName);
		bool SavePhoto(PhotoCreateDTO photo);

		bool RemovePhoto(PhotoDeleteDTO photo);

	}
}