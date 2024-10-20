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
    private async void AdminRegisterClick(object sender, RoutedEventArgs e)
    {
        var email = txtUsername.Text;
        var password = txtPassword.Password;
        var location = cmbLocation.SelectedItem.ToString();

        var uid = await FirebaseAuthService.Instance.CreateUserAsync(email, password, location);

        if (uid != null)
        {
            MessageBox.Show("User registered successfully.");
        }
        else
        {
            MessageBox.Show("Registration failed.");
        }
    }
}