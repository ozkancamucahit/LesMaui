using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{
	public interface IPhotoEndPoint
	{
		Task<bool> AddPhoto(int MemoId, string FilePath);
		Task<bool> RemovePhoto(int PhotoId);
	}
}
