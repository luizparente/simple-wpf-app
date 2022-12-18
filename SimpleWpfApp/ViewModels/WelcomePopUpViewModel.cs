using SimpleWpfApp.Commands;
using SimpleWpfApp.Utilities;
using SimpleWpfApp.ViewModels.Abstract;
using System;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels {
	public class WelcomePopUpViewModel : BaseViewModel {
		public ICommand CloseCommand { get; set; }

		public WelcomePopUpViewModel() {
			this.CloseCommand = new RelayedCommand(_ => CloseWindow(), _ => true);	
		}

		private void CloseWindow() {
			Navigator.Instance.CloseWindow("welcomepopup");
		}
	}
}
