using System;
using System.Windows.Input;

namespace SimpleWpfApp.Commands.Interfaces {
	public interface IInjectableCommand : ICommand {
		public void SetCanExecute(Predicate<object> canExecute);
		public void TriggerCanExecuteChanged();
	}
}
