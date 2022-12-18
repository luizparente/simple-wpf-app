using Application.Interfaces;
using Domain.Models.Domain;
using Domain.Models.Presentation;
using SimpleWpfApp.Commands;
using SimpleWpfApp.Factories.Interfaces;
using SimpleWpfApp.Utilities;
using SimpleWpfApp.ViewModels.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels
{
    public class LoginViewModel : BaseViewModel {
		#region FIELDS
		private string _username;
		private string _password;
		private LoginMethod _selectedLoginMethod;
		private IEnumerable<LoginMethod> _loginMethodOptions;
		private LoginModel _LoginModel;
		private bool _canLogin;

		#endregion

		#region SERVICES
		private readonly ILoginMethodService _loginMethodService;
		private readonly IHostedServiceFactory _hostedServiceFactory;

		#endregion

		#region PROPERTIES

		public LoginModel LoginModel {
			get {
				return this._LoginModel;
			}
			set {
				this._LoginModel = value;

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

				this.UpdateCanLogin();

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

				this.UpdateCanLogin();

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

				this.UpdateCanLogin();

				this.Notify("SelectedLoginMethod");
			}
		}

		public bool CanLogin {
			get {
				return this._canLogin;
			}
			set {
				this._canLogin = value;

				this.Notify("CanLogin");
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

		#endregion

		#region COMMANDS
		public ICommand SignInCommand { get; set; }
		public ICommand InitDataCommand { get; set; }

		#endregion

		public LoginViewModel(ILoginMethodService loginMethodService,
							  IHostedServiceFactory hostedServiceFactory) {
			this._loginMethodService = loginMethodService;
			this._hostedServiceFactory = hostedServiceFactory;
			this.SignInCommand = this._hostedServiceFactory.Create<SignInCommand>();
			this.InitDataCommand = new RelayedCommand(async _ => await InitDataAsync(), _ => true);
		}

		public async Task InitDataAsync() {
			this.LoginModel = new LoginModel();
			this.LoginMethodOptions = await this._loginMethodService.GetAsync();

			Navigator.Instance.NavigateInNewWindow("welcome", "welcomepopup", "Welcome!", false, true, 500, 250);
		}

		private void UpdateCanLogin() { 
			this.CanLogin = !string.IsNullOrWhiteSpace(this.Username)
						    && !string.IsNullOrWhiteSpace(this.Password)
						    && this.SelectedLoginMethod != null;
		}
	}
}
