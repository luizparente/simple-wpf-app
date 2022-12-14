namespace SimpleWpfApp.Factories.Interfaces {
	public interface IHostedServiceFactory {
		public T Create<T>();
	}
}