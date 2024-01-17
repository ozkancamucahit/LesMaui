using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.Internal.DataAccess
{
	public interface ISQLDataAccess
	{
		void CommitTransaction();
		void Dispose();
		string GetConnectionString(string name);
		IEnumerable<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "OYKUDATA");
		IEnumerable<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
		void RollbackTransaction();
		bool SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "OYKUDATA");
		void SaveDataInTransaction<T>(string storedProcedure, T parameters);
		void StartTransaction(string connStringName = "OYKUDATA");
	}
}
