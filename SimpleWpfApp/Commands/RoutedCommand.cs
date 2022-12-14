using System;
using System.Windows.Input;

namespace Example01_DataBinding.Commands {
	public class RoutedCommand : ICommand {
		private Action<object> _execute;
		private Predicate<object> _canExecute;

		public event EventHandler CanExecuteChanged;

		public RoutedCommand(Action<object> execute,
							 Predicate<object> canExecute) {
			this._canExecute = canExecute;
			this._execute = execute;
		}

		public bool CanExecute(object parameter) {
			return this._canExecute(parameter);
		}

		public void Execute(object parameter) {
			this._execute(parameter);
		}
	}
}
