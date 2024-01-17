using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.DTOS
{
	public sealed class PhotoCreateDTO
	{
        public string FilePath { get; set; }

		public int MemoId { get; set; }
    }
}
