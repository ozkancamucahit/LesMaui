using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{

	public sealed class APIHelper : IAPIHelper
	{
		#region FIELDS
		private HttpClient apiClient;
		#endregion


		public HttpClient ApiClient => apiClient;


        #region CTOR
        public APIHelper()
        {
			string api = String.Empty;

			// api = "http://localhost:5124"; // PC
			//api = "http://10.0.2.2:5124"; // MOBILE
			//api = "https://192.168.1.89:54592"; // LOCAL_MOBILE

			api = "https://dbljjqqb-5124.euw.devtunnels.ms";

			apiClient = new HttpClient();
			apiClient.BaseAddress = new Uri(api);
			apiClient.DefaultRequestHeaders.Accept.Clear();
			apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
        #endregion

    }
}
