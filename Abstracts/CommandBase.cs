using System;
using System.Windows.Input;

namespace wpf1.Abstracts
{
    public abstract class CommandBase : ICommand
    {
        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
