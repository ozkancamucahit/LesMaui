using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{
	public class UserEndPoint : IUserEndPoint
	{
		private readonly IAPIHelper apiHelper;

		#region CTOR
		public UserEndPoint(IAPIHelper apiHelper)
        {
			this.apiHelper = apiHelper;
		}
        #endregion


        public async Task<UserModel> GetUser(string UserName)
		{
			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.GetAsync($"/api/User/ByUserName/{UserName}"))
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return new UserModel();
					}

					else if (response.IsSuccessStatusCode)
					{
						var result = await response.Content.ReadAsAsync<UserModel>();
						return result;
					}
					else
					{
						throw new InvalidOperationException(response.ReasonPhrase);
					}
				}
			}
			catch (Exception ex)
			{
				return new UserModel();
			}
		}

		public async Task<bool> SaveUser(string UserName)
		{
			var request = new { UserName };

			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/User/SaveUser", request))
				{

					if (response.IsSuccessStatusCode)
					{
						//TODO: Log Call
						return true;
					}
					else
					{
						throw new InvalidOperationException(response.ReasonPhrase);
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
