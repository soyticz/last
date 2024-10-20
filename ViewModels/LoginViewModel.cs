using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using wpf1.Models;
using wpf1.Commands;

namespace wpf1.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private object? _currentView;
        public ICommand NavigateCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginViewModel()
        {
            NavigateCommand = new RelayCommand<string>(OnNavigate);
            CurrentView = AdminLoginViewModel.Instance;
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

        private void OnNavigate(string viewName)
        {
            switch (viewName)
            {
                case "Register":
                    CurrentView = new RegisterViewModel();
                    break;
                case "Login":
                    CurrentView = AdminLoginViewModel.Instance;
                    break;
                default:
                    CurrentView = AdminLoginViewModel.Instance;
                    break;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}