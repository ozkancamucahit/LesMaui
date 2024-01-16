using MobilOyku.API.Library.Internal.DataAccess;
using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DataAccess
{
	public sealed class UserData : IUserData
	{
		private readonly ISQLDataAccess sql;

		#region CTOR
		public UserData(ISQLDataAccess sql)
		{
			this.sql = sql;
		}
		#endregion

		public UserModel GetUserByUserName(string _UserName)
		{
			IEnumerable<UserModel> result;
			try
			{
				var UserName = _UserName.Trim().Replace(" ", "");
				result = sql.LoadData<UserModel, dynamic>("dbo.spUserLookUp", new { UserName }, "OYKUDATA");
			}
			catch
			{
				// TODO : LOG
				result = Enumerable.Empty<UserModel>();
			}

			return result.Any() ? result.First() : new UserModel();
		}
	}
}
