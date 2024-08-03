using DevExpress.Mvvm;
using System.Windows.Controls;
using System.Windows.Input;
using WpfProjectTemplate.App.Services;

namespace WpfProjectTemplate.App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly PageService _pageService;

        public Page PageSource { get; set; }

        public ICommand Loaded => new DelegateCommand(OnLoaded);

        public ICommand Unloaded => new DelegateCommand(OnUnloaded);

        public MainWindowViewModel(PageService pageService)
        {
            _pageService = pageService;
        }

        private void OnLoaded()
        {
            _pageService.PageChanged += OnPageChanged;

            _pageService.ChangePage(new Views.Pages.Menu());
        }

        private void OnUnloaded()
        {
            _pageService.PageChanged -= OnPageChanged;
        }

        private void OnPageChanged(Page page)
        {
            PageSource = page;
        }
    }
}
