using SimpleWpfApp.Utilities;
using SimpleWpfApp.Views.Interfaces;
using System.Windows.Controls;

namespace SimpleWpfApp.Views {
	public partial class NavigationOutlet : UserControl, INavigationOutlet {
		public NavigationOutlet() {
			InitializeComponent();

			Navigator.Instance.SetNavigationOutlet(this);
		}
	}
}
