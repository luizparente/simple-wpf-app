using SimpleWpfApp.Commands.Interfaces;
using System;

namespace SimpleWpfApp.Commands {
	public class RelayedCommand : IRelayedCommand {
		private Action<object> _execute;
		private Predicate<object> _canExecute;

		public event EventHandler CanExecuteChanged;

		public RelayedCommand(Action<object> execute,
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

		public void TriggerCanExecuteChanged() {
			this.CanExecuteChanged?.Invoke(this, new EventArgs());
		}
	}
}
