

using MobilOyku.API.Library.DTOS;

namespace MobilOyku.API.Library.DataAccess
{
	public interface IMemoData
	{
		Task<int> SaveMemo(MemoCreateDTO memo);

		Task RemoveMemo(MemoDeleteDTO memo);

		Task<IEnumerable<MemoReadDTO>> GetUserMemos(string UserName);

		
		Task<MemoReadDTO> GetMemo(int memoId);

	}
}