
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
	[QueryProperty(nameof(MemoModel), "Memo")]
	[QueryProperty("UserName", "UserName")]

	public partial class MemoDetailViewModel : BaseViewModel
	{
		private readonly IMemoEndPoint memoEndPoint;
		private readonly IMediaPicker mediaPicker;
		private readonly IUserEndPoint userEndPoint;

		#region FIELDS 
		public ObservableCollection<MemoModel> Memos { get; } = new();

		string _userName = String.Empty;
		public string UserName
		{
			get => _userName;
			set
			{
				_userName = value;
				OnPropertyChanged();
				Task.Run(() => GetMemosAsync());
				Task.Run(() => GetUser());

			}
		}

		[ObservableProperty]
		int userId;

		[ObservableProperty]
		string filePath = String.Empty;

		[ObservableProperty]
		MemoModel memo;

		

		#endregion

		#region CTOR
		public MemoDetailViewModel(IMemoEndPoint memoEndPoint, IMediaPicker mediaPicker, IUserEndPoint userEndPoint)
		{
			Title = "Memos";
			this.memoEndPoint = memoEndPoint;
			this.mediaPicker = mediaPicker;
			this.userEndPoint = userEndPoint;
		} 
		#endregion

		[RelayCommand]
		public async Task GetMemosAsync()
		{
			Debug.WriteLine("Clicked get memos");
			if (IsBusy)
				return;

			try
			{

				var memosFromAPI = await memoEndPoint.GetMemos(UserName);

				if (Memos.Count != 0)
					Memos.Clear();  

				foreach (var memo in memosFromAPI)
				{
					Memos.Add(memo);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get memos: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally 
			{ 
				IsBusy = false;
			}


		}
		
		
		


		[RelayCommand]
		public async Task PickPhoto()
		{
			if (MediaPicker.Default.IsCaptureSupported)
			{
				FileResult photo = await mediaPicker.PickPhotoAsync();

				if (photo != null)
				{
					// save the file into local storage
					string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

					var res = await memoEndPoint.AddMemo(UserId, "test");
				}
			}
		}


		private async Task GetUser()
		{
			try
			{
				var user = await userEndPoint.GetUser(UserName);
				if (user.Id == 0)
				{
					await userEndPoint.SaveUser(UserName);
					user = await userEndPoint.GetUser(UserName);
				}
				UserId = user.Id;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get USER: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}

		}


	}
}
