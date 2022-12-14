using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace SimpleWpfApp {
	public partial class App : Application {
		private static IHost host;

		public App() {
			host = Host.CreateDefaultBuilder()
				.ConfigureServices(services => {
					services.AddSingleton<MainWindow>();

					ConfigureServices(services);
					ConfigureRepositories(services);
				})
				.ConfigureAppConfiguration((hostingContext, configuration) => {
					IHostEnvironment env = hostingContext.HostingEnvironment;
					configuration.Sources.Clear();
					configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

					IConfigurationRoot configurationRoot = configuration.Build();
				})
				.Build();
		}

		private void ConfigureServices(IServiceCollection services) {
			
		}

		private void ConfigureRepositories(IServiceCollection services) {
			
		}

		protected async void OnStartup(object sender, StartupEventArgs e) {
			await host?.StartAsync();

			var mainWindow = host.Services.GetRequiredService<MainWindow>();
			mainWindow.Show();
		}

		protected override async void OnExit(ExitEventArgs e) {
			await host?.StopAsync();
		
			base.OnExit(e);
		}
	}
}
