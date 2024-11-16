using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using FactoryManager.Desktop.Services;
using FactoryManager.Desktop.Services.Interfaces;
using FactoryManager.Desktop.ViewModels;
using System.Configuration;

namespace FactoryManager.Desktop
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
            .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // HTTP Client
            services.AddHttpClient();

            // Services
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IProductionService, ProductionService>();
            services.AddSingleton<IWarehouseService, WarehouseService>();
            services.AddSingleton<IQualityService, QualityService>();
            services.AddSingleton<IReportService, ReportService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<IDialogService, DialogService>();

            // ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<ProductionViewModel>();
            services.AddTransient<WarehouseViewModel>();
            services.AddTransient<QualityViewModel>();
            services.AddTransient<ReportsViewModel>();

            // Main Window
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
