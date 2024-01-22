
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.Library.API;
using UI.Library.Models;

namespace MAUI.UI.ViewModel
{
	[QueryProperty("Memo", "Memo")]
	[QueryProperty("UserName", "UserName")]

	public partial class MemoDetailViewModel : BaseViewModel
	{

		#region FIELDS 

		private readonly IMemoEndPoint memoEndPoint;
		private readonly IMediaPicker mediaPicker;
		private readonly IUserEndPoint userEndPoint;
		private readonly IPhotoEndPoint photoEndPoint;
		[ObservableProperty]
		MemoModel memo = new();

		[ObservableProperty]
		string userName = String.Empty;

		[ObservableProperty]
		double latitude;

		[ObservableProperty]
		double longitude;
		

		#endregion

		#region CTOR
		public MemoDetailViewModel(IMemoEndPoint memoEndPoint,
							 IMediaPicker mediaPicker,
							 IUserEndPoint userEndPoint,
							 IPhotoEndPoint photoEndPoint
							 )
		{
			Title = "Memos";
			this.memoEndPoint = memoEndPoint;
			this.mediaPicker = mediaPicker;
			this.userEndPoint = userEndPoint;
			this.photoEndPoint = photoEndPoint;
		}
		#endregion




		[RelayCommand]
		public async Task PickPhoto()
		{
			try
			{
				if (MediaPicker.Default.IsCaptureSupported)
				{
					FileResult photo = await mediaPicker.PickPhotoAsync();

					if (photo != null)
					{

						UserModel UserRes = await userEndPoint.GetUser(UserName);
						string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

						var res = await memoEndPoint.AddMemo(UserRes.Id, "about test", Latitude, Longitude);
					}
				}
			}
			catch (Exception ex)
			{

			}
		}


	}
}
