using Application.Interfaces;
using Domain.Models.Presentation;
using SimpleWpfApp.Commands.Interfaces;
using SimpleWpfApp.Utilities;
using SimpleWpfApp.Utilities.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleWpfApp.Commands {
	public class SignInCommand : IInjectableCommand {
		private Predicate<object> _canExecute;
		private readonly IAuthenticationService _authenticationService;
		private readonly IDialogService _dialogService;

		public event EventHandler CanExecuteChanged;

		public SignInCommand(IAuthenticationService authenticationService,
							 IDialogService dialogService) {
			this._authenticationService = authenticationService;
			this._dialogService = dialogService;
		}

		public bool CanExecute(object parameter) {
			if (this._canExecute == null) {
				return false;
			}

			return this._canExecute(parameter);
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

		public void SetCanExecute(Predicate<object> canExecute) {
			this._canExecute = canExecute;
		}

		public void TriggerCanExecuteChanged() {
			this.CanExecuteChanged?.Invoke(this, new EventArgs());
		}
	}
}