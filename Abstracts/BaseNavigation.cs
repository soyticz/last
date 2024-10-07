using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using wpf1.Commands;

namespace wpf1.Abstracts
{
    public abstract class BaseNavigation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private object? _currentView;
        public ICommand NavigateCommand { get; }
        // Dictionary to map view names to view models
        protected Dictionary<string, Func<object>> ViewMappings { get; }
        public BaseNavigation()
        {
            NavigateCommand = new RelayCommand<string>(OnNavigate);
            ViewMappings = new Dictionary<string, Func<object>>();
        }
        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        // OnNavigate uses the dictionary to switch views
        public void OnNavigate(string viewName)
        {
            if (ViewMappings.TryGetValue(viewName, out var viewModelFactory))
            {
                CurrentView = viewModelFactory.Invoke();
            }
            else
            {
                throw new ArgumentException($"View '{viewName}' is not mapped.", nameof(viewName));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
