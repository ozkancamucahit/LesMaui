using MAUI.UI.ViewModel;
using System.Diagnostics;
using UI.Library.API;

namespace MAUI.UI.View;

public partial class MainPage : ContentPage
{
	private readonly IUserEndPoint userEndPoint;

	public MainPage(IUserEndPoint userEndPoint)
	{
		InitializeComponent();
		this.userEndPoint = userEndPoint;
	}

	private async void LoginBtn_Clicked(object sender, EventArgs e)
	{
		var btn = sender as Button;
		Debug.WriteLine("Clicked !");
		var userName = txtUserName.Text.Trim().Replace(" ", "");

		var res = await userEndPoint.SaveUser(userName);

		if (res)
		{
			lblInfo.Text = "Provide username to login";
			await Shell.Current.GoToAsync($"MemosPage?UserName={userName}"); 
		}
		else
		{
			lblInfo.Text = "Something went wrong try again";
		}
		
	}



}