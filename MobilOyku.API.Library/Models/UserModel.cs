﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilOyku.API.Library.Models
{
	public sealed class UserModel
	{
		public int Id { get; init; }
		public string UserName { get; set; } = String.Empty;

		private DateTime _CreatedDate;

		public DateTime CreatedDate
		{
			get { return _CreatedDate.ToLocalTime(); }
			set { _CreatedDate = value; }
		}


	}
}
