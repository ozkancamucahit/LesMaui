using MAUI.UI.View;

namespace MAUI.UI
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
