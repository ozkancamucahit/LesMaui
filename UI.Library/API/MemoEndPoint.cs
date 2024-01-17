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



        public async Task<bool> AddMemo(int UserId, string About)
		{
			var request = new { UserId, About};

			using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Memo/SaveMemo", request))
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

		public async Task<IEnumerable<MemoModel>> GetMemos(string UserName)
		{
			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.GetAsync($"/api/Memo/UserMemos/{UserName}"))
				{
					if (response.IsSuccessStatusCode)
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
			catch 
			{
				return Enumerable.Empty<MemoModel>();
			}
		}

		public async Task<bool> RemoveMemo(int MemoId)
		{
			var request = new { MemoId };

			using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Memo/RemoveMemo", request))
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
	}
}
