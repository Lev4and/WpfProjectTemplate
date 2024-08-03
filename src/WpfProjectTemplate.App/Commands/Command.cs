using System.Windows.Input;

namespace WpfProjectTemplate.App.Commands
{
    public class Command : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public Command(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
