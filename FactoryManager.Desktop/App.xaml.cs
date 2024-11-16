using FactoryManager.Desktop.Services;
using FactoryManager.Desktop.ViewModels;
using FactoryManager.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;
using System.Windows;

namespace FactoryManager.Desktop
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Infrastructure
            services.AddHttpClient();
            services.AddSingleton<IHttpClient, HttpClientWrapper>();
            services.AddSingleton<ISignalRClient, SignalRClient>();

            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IProductionService, ProductionService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IPlanningService, PlanningService>();
            services.AddScoped<IQualityService, QualityService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<INotificationService, NotificationService>();

            // ViewModels
            services.AddScoped<LoginViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<DashboardViewModel>();
            services.AddScoped<ProductionViewModel>();
            services.AddScoped<WarehouseViewModel>();
            services.AddScoped<PlanningViewModel>();
            services.AddScoped<QualityViewModel>();
            services.AddScoped<ReportsViewModel>();

            // Views
            services.AddTransient<MainWindow>();
            services.AddTransient<LoginWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _serviceProvider.Dispose();
        }
    }
}
