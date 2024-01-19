using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{
	public sealed class PhotoEndPoint : IPhotoEndPoint
	{
		private readonly IAPIHelper apiHelper;

		#region CTOR
		public PhotoEndPoint(IAPIHelper apiHelper)
		{
			this.apiHelper = apiHelper;
		}
		#endregion



		public async Task<bool> AddPhoto(int MemoId, string FilePath)
		{
			var request = new { MemoId, FilePath};

			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Photo/SavePhoto/", request))
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

		public async Task<bool> RemovePhoto(int PhotoId)
		{
			var request = new { PhotoId };

			try
			{
				using (HttpResponseMessage response = await apiHelper.ApiClient.PostAsJsonAsync("/api/Photo/RemovePhoto/", request))
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
