using Application.Interfaces;
using Domain.Models.Domain;
using Domain.Models.Presentation;
using SimpleWpfApp.Commands;
using SimpleWpfApp.Commands.Interfaces;
using SimpleWpfApp.Utilities;
using SimpleWpfApp.Utilities.Interfaces;
using SimpleWpfApp.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels {
	public class LoginViewModel : BaseViewModel {
		#region FIELDS
		private string _username;
		private string _password;
		private LoginMethod _selectedLoginMethod;
		private IEnumerable<LoginMethod> _loginMethodOptions;
		private LoginModel _loginModel;

		#endregion

		#region SERVICES
		private readonly ILoginMethodService _loginMethodService;
		private readonly IDialogService _dialogService;

		#endregion

		#region PROPERTIES

		public LoginModel LoginModel {
			get => this._loginModel;
			set => this.SetAndNotify(ref this._loginModel, value);
		}

		public string Username {
			get => this._username;
			set {
				this.SetAndNotify(ref this._username, value, this.RefreshCanLogin);
				this.LoginModel.Username = value;
			}
		}

		public string Password {
			get => this._password;
			set {
				this.SetAndNotify(ref this._password, value, this.RefreshCanLogin);
				this.LoginModel.Password = value;
			}
		}

		public LoginMethod SelectedLoginMethod {
			get => this._selectedLoginMethod;
			set {
				this.SetAndNotify(ref this._selectedLoginMethod, value, this.RefreshCanLogin);
				this.LoginModel.Method = value;
			}
		}

		public IEnumerable<LoginMethod> LoginMethodOptions {
			get => this._loginMethodOptions;
			set => this.SetAndNotify(ref this._loginMethodOptions, value);
		}

		#endregion

		#region COMMANDS
		public IInjectableCommand SignInCommand { get; set; }
		public ICommand InitDataCommand { get; set; }

		#endregion

		public LoginViewModel(ILoginMethodService loginMethodService,
							  IDialogService dialogService,
							  SignInCommand signInCommand) {
			this._loginMethodService = loginMethodService;
			this._dialogService = dialogService;

			this.InitDataCommand = new RelayedCommand(async _ => await this.InitDataAsync(), _ => true);
			this.SignInCommand = signInCommand;
			this.SignInCommand.SetCanExecute(_ => this.CanLogin());
		}

		public async Task InitDataAsync() {
			this.LoginModel = new LoginModel();

			try {
				this.LoginMethodOptions = await this._loginMethodService.GetAsync();
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}

			Navigator.Instance.NavigateInNewWindow("welcome", "welcomepopup", "Welcome!", false, true, 500, 260);
		}

		private bool CanLogin() {
			return !string.IsNullOrWhiteSpace(this.Username)
					&& !string.IsNullOrWhiteSpace(this.Password)
					&& this.SelectedLoginMethod != null;
		}

		private void RefreshCanLogin() {
			this.SignInCommand.TriggerCanExecuteChanged();
		}
	}
}
