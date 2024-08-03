using System.Windows.Controls;

namespace WpfProjectTemplate.App.Services
{
    public class PageService
    {
        public event Action<Page>? PageChanged;

        public void ChangePage(Page page)
        {
            PageChanged?.Invoke(page);
        }
    }
}
