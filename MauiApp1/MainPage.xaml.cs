using UI.Library.API;
using UI.Library.Models;

namespace MauiApp1
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

		private async void OnCounterClicked(object sender, EventArgs e)
		{
			count++;

			string url = "http://localhost:5124";

			if (count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";

			SemanticScreenReader.Announce(CounterBtn.Text);

			var result = await memoEndPoint.GetMemos("meccu");


		}
	}

}
