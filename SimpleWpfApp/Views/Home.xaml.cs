using SimpleWpfApp.Utilities;
using SimpleWpfApp.Views.Interfaces;
using System.Windows.Controls;

namespace SimpleWpfApp.Views {
	public partial class Home : UserControl, IView {
		public Home() {
			InitializeComponent();

			ViewModelLocator.Instance.WireUpViewModel(this);
		}
	}
}
