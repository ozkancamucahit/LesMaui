using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
			string api = "http://10.0.2.2:5124"; //ConfigurationManager.AppSettings["api"] ?? "";

			apiClient = new HttpClient();
			apiClient.BaseAddress = new Uri(api);
			apiClient.DefaultRequestHeaders.Accept.Clear();
			apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
        #endregion

    }
}
