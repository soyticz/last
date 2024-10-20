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
            var viewModel = (AdminLoginViewModel)DataContext;

            // Manually trigger the login command, assuming it's bound to the button
            if (viewModel.LoginCommand.CanExecute(null))
            {
                viewModel.LoginCommand.Execute(null);
            }
        }
    }
}
