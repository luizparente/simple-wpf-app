using Example01_DataBinding.Models.Authentication;
using Example01_DataBinding.Models.Presentation;
using SimpleWpfApp.Commands;
using SimpleWpfApp.ViewModels.Abstract;
using System.Collections.Generic;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels {
	public class LoginViewModel : BaseViewModel {
		#region FIELDS
		private string _username;
		private string _password;
		private string _loginStatus;
		private LoginMethod _selectedLoginMethod;
		private IEnumerable<LoginMethod> _loginMethodOptions;
		private LoginModel _loginModel;

		#endregion

		#region PROPERTIES

		public LoginModel LoginModel {
			get {
				return this._loginModel;
			}
			set {
				this._loginModel = value;

				this.Notify("LoginModel");
			}
		}

		public string Username {
			get {
				return this._username;
			}
			set {
				this._username = value;
				this.LoginModel.Username = value;

				this.Notify("Username");
			}
		}

		public string Password {
			get {
				return this._password;
			}
			set {
				this._password = value;
				this.LoginModel.Password = value;

				this.Notify("Password");
			}
		}

		public LoginMethod SelectedLoginMethod {
			get {
				return this._selectedLoginMethod;
			}
			set {
				this._selectedLoginMethod = value;
				this.LoginModel.Method = value;

				this.Notify("SelectedLoginMethod");
			}
		}

		public IEnumerable<LoginMethod> LoginMethodOptions {
			get {
				return this._loginMethodOptions;
			}
			set {
				this._loginMethodOptions = value;

				this.Notify("LoginMethodOptions");
			}
		}

		public string LoginStatus {
			get {
				return this._loginStatus;
			}
			set {
				this._loginStatus = value;

				this.Notify("LoginStatus");
			}
		}

		#endregion

		#region COMMANDS
		public ICommand SignInCommand { get; set; }
		public ICommand InitDataCommand { get; set; }

		#endregion

		public LoginViewModel() {
			this.SignInCommand = new SignInCommand();
			this.InitDataCommand = new Example01_DataBinding.Commands.RoutedCommand(InitData, (object obj) => true);
		}

		public void InitData(object obj) {
			this.LoginModel = new LoginModel();
			this.LoginMethodOptions = new List<LoginMethod>() {
				new LoginMethod() { ID = 0, Option = "2FA" },
				new LoginMethod() { ID = 1, Option = "Active Directory" },
				new LoginMethod() { ID = 2, Option = "Default" },
				new LoginMethod() { ID = 3, Option = "Token" },
			};
		}
	}
}
