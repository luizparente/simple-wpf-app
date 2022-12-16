using SimpleWpfApp.Factories.Interfaces;
using System;

namespace SimpleWpfApp.Factories {
	public class HostedServiceFactory : IHostedServiceFactory {
		private readonly IServiceProvider _services;

		public HostedServiceFactory(IServiceProvider services) {
			this._services = services;
		}	

		public T Create<T>() {
			return (T)this._services.GetService(typeof(T));
		}
	}
}