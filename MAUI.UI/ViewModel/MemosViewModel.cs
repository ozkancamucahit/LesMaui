using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.UI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Library.API;
using UI.Library.Models;

namespace MAUI.UI.ViewModel
{
	[QueryProperty("UserName", "UserName")]
	public partial class MemosViewModel : BaseViewModel
	{
		[ObservableProperty]
		string userName = String.Empty;
		public ObservableCollection<MemoModel> Memos { get;} = new ();



        public MemosViewModel(IMemoEndPoint memoEndPoint)
        {
            Title = "Username 's Memos";
			
		}

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

			await Shell.Current.GoToAsync(nameof(MemoDetailPage), true, new Dictionary<string, object>
			{
				{"Memo", model}
			});
		}

	}
}
