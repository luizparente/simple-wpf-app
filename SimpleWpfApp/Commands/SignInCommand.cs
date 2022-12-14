using Application.Interfaces;
using Domain.Models.Presentation;
using SimpleWpfApp.Utilities;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleWpfApp.Commands {
	public class SignInCommand : ICommand {
		private readonly IAuthenticationService _authenticationService;

		public event EventHandler CanExecuteChanged;

		public SignInCommand(IAuthenticationService authenticationService) {
			this._authenticationService = authenticationService;
		}

		public bool CanExecute(object parameter) {
			return true;
		}

		public void Execute(object parameter) {
			var login = (LoginModel)parameter;
			string username = login.Username;
			string password = login.Password;
			string method = login.Method?.Option;

			try {
				Task.Run(async () => {
					bool success = await this._authenticationService.AuthenticateAsync(username, password, method);

					if (success)
						Navigator.Instance.Navigate("home");
					else
						MessageBox.Show("Invalid credentials. Please try again.", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
				});
			}
			catch (Exception e) {
				throw;
			}
		}
	}
}