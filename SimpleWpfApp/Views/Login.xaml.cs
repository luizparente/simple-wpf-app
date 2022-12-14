using SimpleWpfApp.ViewModels;
using System.Windows.Controls;

namespace SimpleWpfApp.Views {
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : UserControl {
		public Login() {
			InitializeComponent();

			this.DataContext = new LoginViewModel();
		}
	}
}
