using System.Windows.Input;

namespace _25._10.Commands
{
    public class MyCommand(Action<object?> action, Func<object?, bool>? canExecute = null) : ICommand
    {
        private readonly Action<object?> action = action;
        private readonly Func<object?, bool>? canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            action(parameter);
        }
    }
}