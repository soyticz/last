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

        private void AdminLoginClick(object sender, RoutedEventArgs e)
        {
            var verifyLogin = await FirebaseAuthService.Instance.LoginUserAsync(txtUsername.Text, txtPassword.Password, cmbLocation.Text);
            if(verifyLogin)
            {
                MessageBox.Show("LoggedIn");
            }
            else{
                MessageBox.Show("Not Logged In");
            }
        }
    }
}
