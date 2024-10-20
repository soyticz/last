using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using wpf1.Commands;
using wpf1.Enums;
namespace wpf1.ViewModels
{
    public class AdminLoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }
        private static readonly Lazy<AdminLoginViewModel> _instance = new Lazy<AdminLoginViewModel>(() => new AdminLoginViewModel());
        public static AdminLoginViewModel Instance => _instance.Value;
        public string location { get; set; }
        private AdminLoginViewModel()
        {
            LoginCommand = new LoginCommand(ExecuteLogin, CanExecuteLogin);
            ComboBoxItems = Enum.GetValues(typeof(Location)).Cast<Location>().ToList();
        }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object? parameter)
        {
            string message = Username == "admin" && Password == "admin"
                ? $"Login successful! Selected Location: {SelectedLocation}"
                : $"Invalid username or password. Selected Location: {SelectedLocation}";
            MessageBox.Show(message);
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                (LoginCommand as LoginCommand)?.RaiseCanExecuteChanged();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                (LoginCommand as LoginCommand)?.RaiseCanExecuteChanged();
            }
        }

        public List<Location> ComboBoxItems { get; set; }

        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (_selectedLocation != value)
                {
                    _selectedLocation = value;
                    OnPropertyChanged(nameof(SelectedLocation));
                    location = SelectedLocation.ToString();
                    MessageBox.Show($"SelectedLocation set to: {location}");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}