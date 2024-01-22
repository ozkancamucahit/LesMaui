using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MobilOyku.API.Library.DTOS;

namespace MobilOyku.API.Library.Internal.DataAccess
{
	public sealed class SQLDataAccess : IDisposable, ISQLDataAccess
	{

		#region FIELDS
		private IDbConnection? _dbConnection;
		private IDbTransaction? _dbTransaction;
		private readonly IConfiguration configuration;

		#endregion

		#region CTOR
		public SQLDataAccess(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		#endregion

		public string GetConnectionString(string name)
		{
			try
			{
				return configuration.GetConnectionString(name) ?? String.Empty;
			}
			catch
			{
				return String.Empty;
			}
		}


		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
		{
			string cnnString = GetConnectionString(connectionStringName);
			IEnumerable<T> result;

			try
			{
				using (IDbConnection cnn = new SqlConnection(cnnString))
				{
					var rows = await cnn.QueryAsync<T>(
						storedProcedure,
						parameters,
						commandType: CommandType.StoredProcedure);
					result = rows;
				}
			}
			catch
			{
				result = Enumerable.Empty<T>();
			}

			return result ?? Enumerable.Empty<T>();

		}

		public async Task<bool> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
		{
			string cnnString = GetConnectionString(connectionStringName);
			int RowsEffected;

			try
			{
				using (IDbConnection cnn = new SqlConnection(cnnString))
				{
					RowsEffected = await cnn.ExecuteAsync(
						storedProcedure,
						parameters,
						commandType: CommandType.StoredProcedure);
				}
			}
			catch
			{
				RowsEffected = 0;
			}

			return RowsEffected > 0;

		}


		public void StartTransaction(string connStringName)
		{
			string connString = GetConnectionString(connStringName);

			_dbConnection = new SqlConnection(connString);
			_dbConnection.Open();
			_dbTransaction = _dbConnection.BeginTransaction();
			isClosed = false;
		}

		public async Task SaveDataInTransaction<T>(string storedProcedure, T parameters)
		{
			if (_dbConnection != null)
			{
				await _dbConnection.ExecuteAsync(
					storedProcedure,
					parameters,
					commandType: CommandType.StoredProcedure,
					transaction: _dbTransaction
					); 
			}

		}

		public async Task<IEnumerable<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
		{

			IEnumerable<T>? rows = null;
			if (_dbConnection != null)
			{

				rows = await _dbConnection.QueryAsync<T>(
				storedProcedure,
				parameters,
				commandType: CommandType.StoredProcedure,
				transaction: _dbTransaction
				);
			}

			return rows ?? Enumerable.Empty<T>();
		}

		private bool isClosed = false;

		public void CommitTransaction()
		{
			_dbTransaction?.Commit();
			_dbConnection?.Close();
			isClosed = true;
		}

		public void RollbackTransaction()
		{
			_dbTransaction?.Rollback();
			isClosed = true;
		}

		public void Dispose()
		{
			if (isClosed == false)
			{
				try
				{
					CommitTransaction();
				}
				catch (Exception ex)
				{
					//TODO : Log exception logic
				}
			}

			_dbTransaction = null;
			_dbConnection = null;
		}

		public async Task<int> SaveMemo(string storedProcedure, MemoCreateDTO parameter, string connectionStringName = "OYKUDATA")
		{

			try
			{
				string cnnString = GetConnectionString(connectionStringName);
				int RowsEffected;

				var p = new DynamicParameters();
				p.Add("@UserId", parameter.UserId);
				p.Add("@About", parameter.About, dbType: DbType.String, direction: ParameterDirection.Input, 2000);
				p.Add("@Latitude", parameter.Latitude, dbType: DbType.Decimal, precision: 13, scale: 10);
				p.Add("@Longitude", parameter.Longitude, dbType: DbType.Decimal, precision: 13, scale: 10);
				p.Add("@Id", null, dbType: DbType.Int32, direction: ParameterDirection.Output);

				using (IDbConnection cnn = new SqlConnection(cnnString))
				{
					RowsEffected = await cnn.ExecuteAsync(
						storedProcedure,
						param: p,
						commandType: CommandType.StoredProcedure);
				}

				if (RowsEffected <= 0)
					throw new DataException("NO ROWS EFFECTED");
				
				var id = p.Get<int>("@Id");
				return id;
			}
			catch (Exception ex)
			{
				return 0;
			}

		}
	}
}
