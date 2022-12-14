using SimpleWpfApp.Views;
using SimpleWpfApp.Views.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleWpfApp.Utilities {
	public class Navigator {
		private static Navigator instance;

		private INavigationOutlet _outlet;
		private IDictionary<string, Type> _routes;

		public static Navigator Instance {
			get {
				if (instance == null)
					instance = new Navigator();

				return instance;
			}
		}

		private Navigator() {
			this.InitRoutes();
		}

		public void SetNavigationOutlet(INavigationOutlet outlet) {
			this._outlet = outlet;
		}

		public void Navigate(string route) {
			if (!this._routes.ContainsKey(route?.ToLower()))
				throw new Exception($"Unknown route '{route}'.");

			System.Windows.Application.Current.Dispatcher.Invoke(() => {
				this._outlet.Content = Activator.CreateInstance(this._routes[route]);
			});
		}

		public void BeginNavigation() {
			this.Navigate("login");
		}

		private void InitRoutes() {
			this._routes = new Dictionary<string, Type>();

			this._routes.Add("login", typeof(Login));
			this._routes.Add("home", typeof(Home));
		}
	}
}
