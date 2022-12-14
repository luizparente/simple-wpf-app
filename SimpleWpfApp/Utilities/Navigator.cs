using SimpleWpfApp.Views;
using SimpleWpfApp.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SimpleWpfApp.Utilities {
	public class Navigator {
		private static Navigator instance;

		private INavigationOutlet _outlet;
		private IDictionary<string, Type> _routes;
		private IDictionary<string, Window> _windows;

		public static Navigator Instance {
			get {
				if (instance == null)
					instance = new Navigator();

				return instance;
			}
		}

		private Navigator() {
			this.InitRoutes();
			this._windows = new Dictionary<string, Window>();
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

		public void Navigate(string route, NavigationMode mode) {
			if (!this._routes.ContainsKey(route?.ToLower()))
				throw new Exception($"Unknown route '{route}'.");

			System.Windows.Application.Current.Dispatcher.Invoke(() => {
				var window = new Window() { Name = route };
				window.Content = Activator.CreateInstance(this._routes[route]);
				window.Show();
			});
		}

		public void Navigate(string route, int newWindowWidth, int newWindowHeight) {
			if (!this._routes.ContainsKey(route?.ToLower()))
				throw new Exception($"Unknown route '{route}'.");

			System.Windows.Application.Current.Dispatcher.Invoke(() => {
				var window = new Window() { 
					Name = route,
					Width = newWindowWidth,
					Height = newWindowHeight
				};
				window.Content = Activator.CreateInstance(this._routes[route]);
				this._windows.Add(window.Name, window);
				window.Show();
			});
		}

		public void CloseWindow(string windowName) {
			var window = this._windows[windowName];
			window.Close();
		}

		public void BeginNavigation() {
			this.Navigate("login");
		}

		private void InitRoutes() {
			this._routes = new Dictionary<string, Type>();

			this._routes.Add("login", typeof(Login));
			this._routes.Add("home", typeof(Home));
		}

		public enum NavigationMode {
			SameWindow,
			NewWindow
		}
	}
}
