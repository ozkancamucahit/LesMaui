
using UserInterface.MAUI.View;

namespace UserInterface.MAUI
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(MemoDetailPage), typeof(MemoDetailPage));
			Routing.RegisterRoute(nameof(MemoEditPage), typeof(MemoEditPage));
			Routing.RegisterRoute(nameof(MemosPage), typeof(MemosPage));
		}
	}
}
