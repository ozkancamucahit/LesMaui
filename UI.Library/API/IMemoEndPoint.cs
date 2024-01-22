using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Library.Models;

namespace UI.Library.API
{
	public interface IMemoEndPoint
	{
		Task<IEnumerable<MemoModel>> GetMemos(string UserName);
		Task<int> AddMemo(int UserId, string About, double Latitude, double Longitude);
		Task<bool> RemoveMemo(int MemoId);



	}
}
