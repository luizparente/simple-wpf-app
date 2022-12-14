using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Authentication;
using SimpleWpfApp.ViewModels;
using System.Windows;

namespace SimpleWpfApp {
	public partial class App : System.Windows.Application {
		public static IHost AppHost { get; set; }

		public App() {
			AppHost = Host.CreateDefaultBuilder()
				.ConfigureServices(services => {
					services.AddSingleton<MainWindow>();
					
					ConfigureViewModels(services);
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

		private static void ConfigureViewModels(IServiceCollection services) {
			services.AddSingleton<LoginViewModel>();
		}

		private void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<ILoginMethodService, LoginMethodService>();
		}

		private void ConfigureRepositories(IServiceCollection services) {
			
		}

		protected async void OnStartup(object sender, StartupEventArgs e) {
			await AppHost?.StartAsync();

			var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
			mainWindow.Show();
		}

		protected override async void OnExit(ExitEventArgs e) {
			await AppHost?.StopAsync();
		
			base.OnExit(e);
		}
	}
}