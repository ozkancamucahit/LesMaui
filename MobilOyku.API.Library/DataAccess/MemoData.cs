using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Internal.DataAccess;
using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DataAccess
{
	public sealed class MemoData : IMemoData
	{
		private readonly ISQLDataAccess sql;

		#region CTOR
		public MemoData(ISQLDataAccess sql)
		{
			this.sql = sql;
		}

		#endregion


		public void SaveMemo(MemoCreateDTO memo)
		{
			try
			{
				sql.SaveData("[dbo].[spMemoInsert]", memo);
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		
		public IEnumerable<MemoReadDTO> GetUserMemos(string UserName)
		{
			IEnumerable<MemoReadDTO> result;
			try
			{
				result = sql.LoadData<MemoReadDTO, dynamic>("[dbo].[spLookupMemo]", new {UserName});
			}
			catch
			{

				result = Enumerable.Empty<MemoReadDTO>();
			}

			return result;
		}

		public void RemoveMemo(MemoDeleteDTO memo)
		{
			try
			{
				sql.SaveData("[dbo].[spMemo_Remove]", memo);
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
