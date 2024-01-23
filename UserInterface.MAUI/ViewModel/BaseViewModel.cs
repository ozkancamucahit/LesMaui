using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.MAUI.ViewModel
{
	public partial class BaseViewModel : ObservableObject
	{

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		[ObservableProperty]
		string title = String.Empty;

		public bool IsNotBusy => !IsBusy;
	}
}
