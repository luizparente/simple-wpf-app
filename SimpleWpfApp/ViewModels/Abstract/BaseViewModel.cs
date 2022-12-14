using System.ComponentModel;

namespace SimpleWpfApp.ViewModels.Abstract {
	public abstract class BaseViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void Notify(string propertyName) {
			// Always check if PropertyChanged != null!
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
