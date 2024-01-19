using MAUI.UI.ViewModel;

namespace MAUI.UI.View;

public partial class MemoDetailPage : ContentPage
{
	public MemoDetailPage(MemoDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}