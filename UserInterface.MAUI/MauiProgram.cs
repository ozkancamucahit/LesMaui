using Microsoft.Extensions.Logging;
using UserInterface.MAUI.View;
using UserInterface.MAUI.ViewModel;
using UI.Library.API;

namespace UserInterface.MAUI
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.UseMauiMaps();

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services
				.AddSingleton<IConnectivity>(Connectivity.Current)
				.AddSingleton<IGeolocation>(Geolocation.Default)
				.AddSingleton<IMap>(Map.Default)
				.AddSingleton<IMediaPicker>(MediaPicker.Default)

				.AddSingleton<MainPage>()
				.AddTransient<MemosPage>()
				.AddTransient<MemoEditPage>()
				.AddTransient<MemoDetailPage>()

				.AddTransient<MemoDetailViewModel>()
				.AddTransient<MemosViewModel>()

				.AddSingleton<IAPIHelper, APIHelper>()
				.AddTransient<IPhotoEndPoint, PhotoEndPoint>()
				.AddTransient<IMemoEndPoint, MemoEndPoint>()
				.AddTransient<IUserEndPoint, UserEndPoint>();

			return builder.Build();
		}
	}
}
