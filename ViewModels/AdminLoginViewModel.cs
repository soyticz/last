using System.ComponentModel;
using System.Windows.Input;

namespace wpf1.ViewModels
{
    public class AdminLoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _selectedLocation;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        public ICommand LoginCommand { get; }

        public AdminLoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            // Load ComboBox items, etc.
        }

        private async void Login()
        {
            // Call your FirebaseAuthService here to handle the login based on Username, Password, and SelectedLocation.
            // Example:
            var uid = await FirebaseAuthService.Instance.LoginUserAsync(Username, Password, SelectedLocation);
            if (uid != null)
            {
                // Handle successful login
            }
            else
            {
                // Handle login failure
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
