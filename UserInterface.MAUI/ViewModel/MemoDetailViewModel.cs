using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobilOyku.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Library.API;
using UI.Library.Models;

namespace UserInterface.MAUI.ViewModel
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

		//[ObservableProperty]
		//string localFilePath;

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
				IsBusy = true;
				if (MediaPicker.Default.IsCaptureSupported)
				{
					FileResult photo = await mediaPicker.PickPhotoAsync();

					if (photo != null)
					{

						Memo.PhotoFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to pick photo: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		public async Task SaveMemo()
		{

			try
			{
				IsBusy = true;

				UserModel UserRes = await userEndPoint.GetUser(UserName);
				var memoId = await memoEndPoint.AddMemo(UserRes.Id, Memo.About, Latitude, Longitude);

				if (memoId == 0)
					throw new InvalidOperationException("UNABLE TO ADD MEMO");
				else if (!String.IsNullOrWhiteSpace(Memo.PhotoFilePath))
				{
					var photoRes = await photoEndPoint.AddPhoto(memoId, Memo.PhotoFilePath);
					if (photoRes == false)
					{
						throw new InvalidOperationException("UNABLE TO ADD PHOTO");
					}
					else
					{
						await Shell.Current.DisplayAlert("Memo Added", "Your memo have been added", "OK");
						await Shell.Current.GoToAsync($"MemosPage?UserName={UserName}");

					}
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to save memo: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}

		}


	}
}
