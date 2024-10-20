using System.Windows;
using System.Windows.Controls;
using wpf1.Firebase.FirebaseAuthentication;

namespace wpf1.Views.Login.RegisterView;

public partial class RegisterView : UserControl
{
    public RegisterView()
    {
        InitializeComponent();
    }
    public async void AdminRegisterClick(object sender, RoutedEventArgs e)
    {
        string Username = txtUsername.Text;
        string Password = txtPassword.Password;
        string Tenant = cmbLocation.Text;
        try
        {
            bool IsRegisterSuccessful = await FirebaseUserAuth.Instance.RegisterUserAsync(Username, Password);
            if (IsRegisterSuccessful)
            {
                MessageBox.Show("Registration Successful");
            }
            else
            {
                MessageBox.Show("Registration Failed");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error in" + ex.Message);
        }

    }
}