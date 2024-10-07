using System;
using wpf1.Abstracts;

namespace wpf1.Commands
{
    public class RelayCommandNonGeneric : CommandBase
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommandNonGeneric(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) =>
            _canExecute == null || _canExecute();

        public override void Execute(object? parameter) => _execute();

    }
}
