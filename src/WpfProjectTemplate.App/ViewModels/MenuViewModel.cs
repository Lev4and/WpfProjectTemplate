using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfProjectTemplate.App.Services;

namespace WpfProjectTemplate.App.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private readonly MenuPageService _menuPageService;

        public bool IsLeftDrawerOpen { get; set; }

        public Page PageSource { get; set; }

        public ICommand Loaded => new DelegateCommand(OnLoaded);

        public ICommand Unloaded => new DelegateCommand(OnUnloaded);

        public ICommand Unchecked => new DelegateCommand(OnUnchecked);

        public ICommand DefaultPage => new DelegateCommand(OpenDefaultPage);

        public ICommand Exit => new DelegateCommand(CloseApplication);

        public MenuViewModel(MenuPageService menuPageService)
        {
            _menuPageService = menuPageService;
        }

        private void OnLoaded()
        {
            _menuPageService.PageChanged += OnPageChanged;
        }

        private void OnUnloaded()
        {
            _menuPageService.PageChanged -= OnPageChanged;
        }

        private void OnUnchecked()
        {
            IsLeftDrawerOpen = false;
        }

        private void OnPageChanged(Page page)
        {
            IsLeftDrawerOpen = false; 
            PageSource = page;
        }

        private void OpenDefaultPage()
        {
            _menuPageService.ChangePage(new Views.Pages.Default());
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
