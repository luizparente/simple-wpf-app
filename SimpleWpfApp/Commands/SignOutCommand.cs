using SimpleWpfApp.Utilities;
using System;
using System.Windows.Input;

namespace SimpleWpfApp.Commands {
	public class SignOutCommand : ICommand {
		public event EventHandler CanExecuteChanged;


		public bool CanExecute(object parameter) {
			return true;
		}

		public void Execute(object parameter) {
			Navigator.Instance.Navigate("login");
		}
	}
}
