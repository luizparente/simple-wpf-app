using Domain.Models.Presentation;
using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleWpfApp.Commands {
	public class SignInCommand : ICommand {
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) {
			return true;
		}

		public void Execute(object parameter) {
			var login = (LoginModel)parameter;
			string username = login.Username;
			string password = login.Password;
			string method = login.Method?.Option;

			if (username == "luiz" && password == "parente" && method == "2FA") {
				MessageBox.Show("Login successful!");
			}
			else {
				MessageBox.Show("Login failed.");
			}
		}
	}
}
