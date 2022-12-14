using SimpleWpfApp.Factories.Interfaces;

namespace SimpleWpfApp.Factories {
	public class HostedServiceFactory : IHostedServiceFactory {
		public T Create<T>() {
			return (T)App.AppHost.Services.GetService(typeof(T));
		}
	}
}