using System.Windows.Input;

namespace SimpleWpfApp.Commands.Interfaces {
	public interface IRelayedCommand : ICommand {
		public void TriggerCanExecuteChanged();
	}
}
