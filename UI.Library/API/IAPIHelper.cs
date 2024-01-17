using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Library.API
{
	public interface IAPIHelper
	{
		HttpClient ApiClient { get; }
	}
}
