using SimpleWpfApp.Utilities.Interfaces;
using System;
using System.Windows;

namespace SimpleWpfApp.Utilities {
	public class DialogService : IDialogService {
		public void ShowDialog(string message, string caption, IDialogService.DialogType dialogType) {
			MessageBoxImage icon;

			switch (dialogType) {
				case IDialogService.DialogType.Error:
					icon = MessageBoxImage.Error;
					break;
				case IDialogService.DialogType.Warning:
					icon = MessageBoxImage.Warning;
					break;
				default:
					icon = MessageBoxImage.Information;
					break;
			}
		
			MessageBox.Show(message, caption, MessageBoxButton.OK, icon);
		}

		public string ShowDialog(string message, string caption, IDialogService.DialogType dialogType, IDialogService.ResponseType responseType) {
			MessageBoxImage icon;
			MessageBoxButton buttons;

			switch (dialogType) {
				case IDialogService.DialogType.Error:
					icon = MessageBoxImage.Error;
					break;
				case IDialogService.DialogType.Warning:
					icon = MessageBoxImage.Warning;
					break;
				default:
					icon = MessageBoxImage.Information;
					break;
			}

			switch (responseType) {
				case IDialogService.ResponseType.OkCancel:
					buttons = MessageBoxButton.OKCancel;
					break;
				case IDialogService.ResponseType.YesNo:
					buttons = MessageBoxButton.YesNo;
					break;
				case IDialogService.ResponseType.YesNoCancel:
					buttons = MessageBoxButton.YesNoCancel;
					break;
				default:
					buttons = MessageBoxButton.OK;
					break;
			}

			var result = MessageBox.Show(message, caption, buttons, icon);

			return result.ToString();
		}

		public void ShowDialog(Exception exception) {
			string message = $"{exception.Message} " +
							 $"{exception.InnerException?.Message} {Environment.NewLine}" +
							 $"{exception.StackTrace}";

			MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}
