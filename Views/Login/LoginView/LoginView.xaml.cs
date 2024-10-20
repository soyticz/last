using System.Windows;
using System.Windows.Controls;
using wpf1.Firebase.FirebaseAuthentication;
using wpf1.Models;
using wpf1.ViewModels;

namespace wpf1.Views.Login.LoginView
{
    public partial class LoginView : UserControl
    {
        // Declare fields as nullable
        private string? Username;
        private string? Password;
        private string Tenant;
        public LoginView()
        {
            InitializeComponent();
        }

        private async void AdminLoginClick(object sender, RoutedEventArgs e)
        {
            // Get the parent window of this UserControl
            Window parentWindow = Window.GetWindow(this);

            // Create the new window and set it to the new instance
            var mainWindow = new MainWindow();

            // Capture username and password from UI
            Username = txtUsername.Text;
            Password = txtPassword.Password;
            Tenant = cmbLocation.Text;
            try
            {
                var loginSuccesfull = await FirebaseUserAuth.Instance.LoginUserAsync(Username, Password);

                if (loginSuccesfull)
                {

                    AdminLoginViewModel.Instance.location = cmbLocation.Text;
                    // Hide the parent window (login window)
                    parentWindow?.Hide();
                    // Show the new window
                    mainWindow.Show();
                }
                else
                {
                    throw new Exception(MessageBox.Show("Username or Password is incorrect").ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username or Password is incorrect" + ex.Message);
            }
        }
    }
}
