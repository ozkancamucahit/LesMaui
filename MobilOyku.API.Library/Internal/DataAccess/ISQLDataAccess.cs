using MobilOyku.API.Library.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.Internal.DataAccess
{
	public interface ISQLDataAccess
	{
		#region GENERAL
		void CommitTransaction();
		void Dispose();
		string GetConnectionString(string name);
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "OYKUDATA");
		Task<IEnumerable<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
		void RollbackTransaction();
		Task<bool> SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "OYKUDATA");
		Task SaveDataInTransaction<T>(string storedProcedure, T parameters);
		void StartTransaction(string connStringName = "OYKUDATA");
		#endregion



		#region MEMO
		/// <summary>
		/// inserts data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="storedProcedure"></param>
		/// <param name="connectionStringName"></param>
		/// <returns>scope identity of inserted value</returns>
		Task<int> SaveMemo(string storedProcedure, MemoCreateDTO parameter, string connectionStringName = "OYKUDATA"); 

		#endregion
	}
}
