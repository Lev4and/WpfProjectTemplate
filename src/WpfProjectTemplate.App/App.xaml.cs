using System.Windows;
using WpfProjectTemplate.App.DependencyInjection;

namespace WpfProjectTemplate.App
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DependencyInjectionContainer.Init();
        }
    }
}
