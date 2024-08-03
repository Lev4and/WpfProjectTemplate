using Microsoft.Extensions.DependencyInjection;
using WpfProjectTemplate.App.Services;
using WpfProjectTemplate.App.ViewModels;

namespace WpfProjectTemplate.App.DependencyInjection
{
    public class DependencyInjectionContainer
    {
        private static ServiceProvider _provider;

        public DefaultViewModel DefaultViewModel => _provider.GetRequiredService<DefaultViewModel>();

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();

        public MenuViewModel MenuViewModel => _provider.GetRequiredService<MenuViewModel>();

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<DefaultViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MenuViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<WindowService>();
            services.AddSingleton<MenuPageService>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }
    }
}
