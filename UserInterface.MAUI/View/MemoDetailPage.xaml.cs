using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using UserInterface.MAUI.ViewModel;


namespace UserInterface.MAUI.View;

public partial class MemoDetailPage : ContentPage
{
	#region CTOR
	public MemoDetailPage(MemoDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	#endregion


	private void MoveMap()
	{
		if (BindingContext is MemoDetailViewModel viewModel)
		{
			Location location = new Location(41.0227878251, 29.0069532394);
			Pin pin = new Pin
			{
				Label = $"{viewModel.Memo.UserName}'s new memo",
				Address = "",
				Type = PinType.Place,
				Location = location
			};
			map.Pins.Add(pin);

			var mapSpan = new MapSpan(location, 0.01, 0.01);
			map.MoveToRegion(mapSpan);

		}
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		MoveMap();
		map.IsScrollEnabled = false;

	}
}