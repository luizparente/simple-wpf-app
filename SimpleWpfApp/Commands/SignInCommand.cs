using Application.Interfaces;
using Domain.Models.Presentation;
using SimpleWpfApp.Utilities;
using SimpleWpfApp.Utilities.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleWpfApp.Commands {
	public class SignInCommand : ICommand {
		private readonly IAuthenticationService _authenticationService;
		private readonly IDialogService _dialogService;

		public event EventHandler CanExecuteChanged;

		public SignInCommand(IAuthenticationService authenticationService,
							 IDialogService dialogService) {
			this._authenticationService = authenticationService;
			this._dialogService = dialogService;
		}

		public bool CanExecute(object parameter) {
			return true;
		}

		public void Execute(object parameter) {
			var login = (LoginModel)parameter;
			string username = login.Username;
			string password = login.Password;
			string method = login.Method?.Option;

			if (string.IsNullOrWhiteSpace(method)) {
				this._dialogService.ShowDialog("Login method required.", "Error", IDialogService.DialogType.Error);
				return;
			}

			try {
				Task.Run(async () => {
					bool success = await this._authenticationService.AuthenticateAsync(username, password, method);

					if (success)
						Navigator.Instance.Navigate("home");
					else
						this._dialogService.ShowDialog("Invalid credentials. Please try again.", "Login error", IDialogService.DialogType.Error);
				});
			}
			catch (Exception e) {
				throw;
			}
		}
	}
}