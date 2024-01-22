using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DataAccess
{
	public sealed class PhotoData : IPhotoData
	{
		private readonly ISQLDataAccess sql;
		private readonly IMemoData memoData;

		#region CTOR
		public PhotoData(ISQLDataAccess sql, IMemoData memoData)
		{
			this.sql = sql;
			this.memoData = memoData;
		}
		#endregion

		public async Task<IEnumerable<MemoReadDTO>> GetMemos(string UserName)
		{
			return await memoData.GetUserMemos(UserName);
		}

		public async Task<bool> RemovePhoto(PhotoDeleteDTO photo)
		{
			try
			{
				await sql.SaveData("[dbo].[spPhoto_Remove]", photo);
				return true;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<bool> SavePhoto(PhotoCreateDTO photo)
		{
			try
			{
				sql.StartTransaction();
				sql.SaveDataInTransaction("spPhoto_Insert", photo);
				sql.CommitTransaction();
				return true;
			}
			catch 
			{
				return false;
			}
		}



	}
}
