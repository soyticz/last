using System.ComponentModel;
using wpf1.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using wpf1.Firebase.FirebaseAuthentication;
using wpf1.Enums;
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
        public ObservableCollection<Location> Locations { get; set; }
        public AdminLoginViewModel()
        {
            LoginCommand = new RelayCommandNonGeneric(Login);
            Locations = new ObservableCollection<Location>(Enum.GetValues(typeof(Location)) as Location[]);
            // Load ComboBox items, etc.
        }

        private async void Login()
        {
            // Call your FirebaseAuthService here to handle the login based on Username, Password, and SelectedLocation.
            // Example:
            var uid = await FirebaseAuthService.Instance.LoginUserAsync(Username, Password, SelectedLocation);
            if (uid != null)
            {
                MessageBox.Show($"Errr logging in user: ", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show($"Error logging in user: ", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
