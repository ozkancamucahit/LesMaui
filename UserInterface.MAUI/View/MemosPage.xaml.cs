
using UserInterface.MAUI.ViewModel;

namespace UserInterface.MAUI.View;


public partial class MemosPage : ContentPage
{


	#region CTOR
	public MemosPage(MemosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	#endregion

	protected override async void OnAppearing()
	{
		if (BindingContext is MemosViewModel viewModel) // != null
		{
			await viewModel.GetMemos();
		}

	}

}