

using MobilOyku.API.Library.DTOS;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IMemoData
	{
		void SaveMemo(MemoCreateDTO memo);

		void RemoveMemo(MemoDeleteDTO memo);

		IEnumerable<MemoReadDTO> GetUserMemos(string UserName);
	}
}