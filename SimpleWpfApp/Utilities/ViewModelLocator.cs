using System;

namespace SimpleWpfApp.Utilities {
	public class ViewModelLocator {
		private static ViewModelLocator instance;

		public static ViewModelLocator Instance { 
			get {
				if (instance == null)
					instance = new ViewModelLocator();

				return instance;
			}
		}

		private ViewModelLocator() { }

		public void WireUpViewModel(Views.Interfaces.IView view) {
			string viewModel = $"SimpleWpfApp.ViewModels.{view.GetType().Name}ViewModel";
			Type viewModelType = Type.GetType(viewModel);
			view.DataContext = App.AppHost.Services.GetService(viewModelType);
		}
	}
}
