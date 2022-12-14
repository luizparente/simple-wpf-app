using SimpleWpfApp.Utilities;
using SimpleWpfApp.Views.Interfaces;
using System.Windows.Controls;

namespace SimpleWpfApp.Views {
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : UserControl, IView {
		public Login() {
			InitializeComponent();

			ViewModelLocator.Instance.WireUpViewModel(this);
		}
	}
}
