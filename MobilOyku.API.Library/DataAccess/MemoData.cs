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


		public async Task<int> SaveMemo(MemoCreateDTO memo)
		{
			try
			{
				var id = await sql.SaveMemo("[dbo].[spMemoInsert]", memo);
				return id;
			}
			catch (Exception ex)
			{

				return 0;
			}
		}
		
		public async Task<IEnumerable<MemoReadDTO>> GetUserMemos(string UserName)
		{
			IEnumerable<MemoReadDTO> result;
			try
			{
				result = await sql.LoadData<MemoReadDTO, dynamic>("[dbo].[spLookupMemo]", new {UserName});
			}
			catch
			{

				result = Enumerable.Empty<MemoReadDTO>();
			}

			return result;
		}

		public async Task RemoveMemo(MemoDeleteDTO memo)
		{
			try
			{
				await sql.SaveData("[dbo].[spMemo_Remove]", memo);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<MemoReadDTO> GetMemo(int memoId)
		{
			IEnumerable<MemoReadDTO> result;
			try
			{
				result = await sql.LoadData<MemoReadDTO, dynamic>("[dbo].[spMemoGetMemoById]", new { memoId });
			}
			catch
			{

				result = Enumerable.Empty<MemoReadDTO>();
			}

			return result.FirstOrDefault() ?? new MemoReadDTO();
		}
	}
}
