using System.Windows;
using System.Windows.Controls;
using wpf1.Firebase.FirebaseAuthentication;
using wpf1.Models;
using wpf1.ViewModels;

namespace wpf1.Views.Login.LoginView
{
    public partial class LoginView : UserControl
    {

        public LoginView()
        {
            InitializeComponent();
        }

        private async void AdminLoginClick(object sender, RoutedEventArgs e)
{
    var verifyLogin = await FirebaseAuthService.Instance.LoginUserAsync(txtUsername.Text, txtPassword.Password, cmbLocation.Text);
    if (verifyLogin)
    {
        MessageBox.Show("Logged In");

        // Create and show the MainWindow
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();

        // Close the current login window (assuming it's a window, otherwise you can modify this as needed)
        Window.GetWindow(this)?.Close(); // Closes the current window that contains the LoginView
    }
    else
    {
        MessageBox.Show("Not Logged In");
    }
}

    }
}
