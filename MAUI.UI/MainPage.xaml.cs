using System.Diagnostics;
using UI.Library.API;

namespace MAUI.UI
{
	public partial class MainPage : ContentPage
	{
		private readonly IMemoEndPoint memoEndPoint;
		int count = 0;

		public MainPage(IMemoEndPoint memoEndPoint)
		{
			InitializeComponent();
			this.memoEndPoint = memoEndPoint;
		}


		private async void LoginButton_Clicked(object sender, EventArgs e)
		{
			var btn = sender as Button;

			Debug.WriteLine("Clicked !");

			var result = await memoEndPoint.GetMemos("meccu");

		}
	}

}
