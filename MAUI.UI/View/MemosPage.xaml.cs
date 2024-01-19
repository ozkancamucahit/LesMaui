using MAUI.UI.ViewModel;
using UI.Library.API;

namespace MAUI.UI.View;

public partial class MemosPage : ContentPage
{
	private readonly IMemoEndPoint memoEndPoint;

	public MemosPage(MemosViewModel viewModel, IMemoEndPoint memoEndPoint)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.memoEndPoint = memoEndPoint;
	}

	protected override async void OnAppearing()
	{
		await GetMemos();
	}

	public async Task GetMemos()
	{
		var viewModel = BindingContext as MemosViewModel;

		if (!String.IsNullOrWhiteSpace(viewModel?.UserName))
		{
			var memos = await memoEndPoint.GetMemos(viewModel.UserName);

			foreach (var memo in memos)
			{
				viewModel.Memos.Add(memo);
			}
		}
	}





}