namespace SimpleWpfApp.Utilities.Interfaces {
	public interface IDialogService {
		public void ShowDialog(string message, string caption, DialogType dialogType);
		public string ShowDialog(string message, string caption, DialogType dialogType, ResponseType responseType);

		public enum DialogType {
			Info,
			Error,
			Warning
		}

		public enum ResponseType {
			OK,
			OkCancel,
			YesNo,
			YesNoCancel
		}
	}
}
