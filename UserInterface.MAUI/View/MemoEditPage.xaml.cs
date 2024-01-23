
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Diagnostics;
using UserInterface.MAUI.ViewModel;

namespace UserInterface.MAUI.View;

public partial class MemoEditPage : ContentPage
{
	private readonly IGeolocation geolocation;

	public MemoEditPage(IGeolocation geolocation, MemoDetailViewModel viewModel)
	{
		InitializeComponent();
		this.geolocation = geolocation;
		BindingContext = viewModel;
	}


	private async Task Setlocation()
	{
		try
		{
			//var viewmodel = BindingContext as MemoDetailViewModel;
			Debug.WriteLine("SET LOCATION CALLED");

			var locationPermission = await CheckAndRequestLocationPermission();

			if (BindingContext is MemoDetailViewModel viewModel)
			{
				viewModel.IsBusy = true;
				if (locationPermission == PermissionStatus.Granted)
				{
					//var location = await geolocation.GetLastKnownLocationAsync();
					//if (location == null)
					//{
					var location = await geolocation.GetLocationAsync(new GeolocationRequest
					{
						DesiredAccuracy = GeolocationAccuracy.Medium,
						Timeout = TimeSpan.FromSeconds(30)
					});
					//}

					if (location != null)
					{
						var mapSpan = new MapSpan(location, 0.01, 0.01);

						Pin pin = new Pin
						{
							Label = $"{viewModel.UserName}'s new memo",
							Address = "The city with a boardwalk",
							Type = PinType.Place,
							Location = new Location(location.Latitude, location.Longitude)
						};
						map.Pins.Add(pin);
						map.MoveToRegion(mapSpan);
					}


					lblLatitude.Text = location?.Latitude.ToString();
					lblLongitude.Text = location?.Longitude.ToString();

					viewModel.Latitude = location?.Latitude ?? 0;
					viewModel.Longitude = location?.Longitude ?? 0;
				}
				else
				{
					await Shell.Current.DisplayAlert("Permission required!", "Location permission is required", "OK");

				}

				viewModel.IsBusy = false;

			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to query location: {ex.Message}");
			await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");

			if (BindingContext is MemoDetailViewModel viewModel)
				viewModel.IsBusy = false;
		}
	}

	public async Task<PermissionStatus> CheckAndRequestLocationPermission()
	{
		PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

		if (status == PermissionStatus.Granted)
			return status;

		if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
		{
			// Prompt the user to turn on in settings
			// On iOS once a permission has been denied it may not be requested again from the application
			return status;
		}

		if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
		{
			// Prompt the user with additional information as to why the permission is needed
		}

		status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

		return status;
	}

	protected override async void OnAppearing()
	{
		await Setlocation();
	}

	private void txtAbaout_Unfocused(object sender, FocusEventArgs e)
	{
		if (BindingContext is MemoDetailViewModel viewModel)
		{
			viewModel.Memo.About = txtAbaout.Text.Trim();
		}
	}
}