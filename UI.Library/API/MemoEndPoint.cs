using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Library.Models;

namespace UI.Library.API
{
	public sealed class MemoEndPoint : IMemoEndPoint
	{
		private readonly IAPIHelper apiHelper;

		#region CTOR
		public MemoEndPoint(IAPIHelper apiHelper)
        {
			this.apiHelper = apiHelper;
		}
        #endregion



        public async Task<int> AddMemo(int UserId, string About, double Latitude, double Longitude )
		{
			var request = new { UserId, About, Latitude, Longitude};

			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Memo/SaveMemo", request))
				{
					if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.Created)
					{
						// /api/Memo/GetMemo/17
						// 0 => /, api, Memo, GetMemo, 17 => Id 
						return int.Parse(response.Headers.Location?.Segments[4] ?? "0"); // created at route value for inserted id
					}
					else
					{
						throw new InvalidOperationException(response.ReasonPhrase);
					}
				}
			}
			catch (Exception ex) 
			{ 
				return 0; 
			}
		}

		public async Task<IEnumerable<MemoModel>> GetMemos(string UserName)
		{
			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.GetAsync($"/api/Memo/UserMemos/{UserName}"))
				{
					if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return Enumerable.Empty<MemoModel>();
					}

					else if (response.IsSuccessStatusCode)
					{
						var result = await response.Content.ReadAsAsync<IEnumerable<MemoModel>>();
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
				return Enumerable.Empty<MemoModel>();
			}
		}

		public async Task<bool> RemoveMemo(int MemoId)
		{
			var request = new { MemoId };

			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Memo/RemoveMemo", request))
				{
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						throw new InvalidOperationException(response.ReasonPhrase);
					}
				}
			}
			catch (Exception ex) { return false; }
		}
	}
}
