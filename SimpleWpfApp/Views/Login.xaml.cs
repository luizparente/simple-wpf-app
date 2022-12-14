using SimpleWpfApp.Utilities;
using SimpleWpfApp.Views.Interfaces;
using System.Windows.Controls;

namespace SimpleWpfApp.Views {
	public partial class Login : UserControl, IView {
		public Login() {
			InitializeComponent();

			ViewModelLocator.Instance.WireUpViewModel(this);
		}
	}
}
