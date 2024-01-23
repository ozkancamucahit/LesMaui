using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Library.API;
using UI.Library.Models;
using UserInterface.MAUI.View;

namespace UserInterface.MAUI.ViewModel
{
	[QueryProperty("UserName", "UserName")]
	public partial class MemosViewModel : BaseViewModel
	{
		#region FIELDS

		[ObservableProperty]
		string userName = String.Empty;
		private readonly IMemoEndPoint memoEndPoint;

		public ObservableCollection<MemoModel> Memos { get; } = new();


		#endregion



		#region CTOR
		public MemosViewModel(IMemoEndPoint memoEndPoint)
		{
			Title = "Username 's Memos";
			this.memoEndPoint = memoEndPoint;
		}
		#endregion

		[RelayCommand]
		public async Task RedirectToMemoEditAsync()
		{
			Debug.WriteLine("Clicked add memos");
			if (IsBusy)
				return;

			try
			{

				await Shell.Current.GoToAsync($"MemoEditPage?UserName={UserName}");

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
		async Task GoToDetails(MemoModel model)
		{
			if (model == null)
				return;

			model.MemoDate = model.MemoDate.ToLocalTime();
			model.PhotoCreateDate = model.PhotoCreateDate?.ToLocalTime();

			await Shell.Current.GoToAsync(nameof(MemoDetailPage), true, new Dictionary<string, object>
			{
				{"Memo", model}
			});
		}

		[RelayCommand]
		public async Task GetMemos()
		{
			IsBusy = true;

			if (!String.IsNullOrWhiteSpace(UserName))
			{
				var memos = await memoEndPoint.GetMemos(UserName);

				foreach (var memo in memos.OrderBy(m => m.MemoDate))
				{
					if (!Memos.Any(m => m.Id == memo.Id))
						Memos.Add(memo);
				}
			}
			IsBusy = false;
		}

	}
}
