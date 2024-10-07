using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using Google.Cloud.Firestore.V1;

namespace wpf1.Views.EmployeesView.AddWindowView
{
    public partial class AddWindowsView : Window
    {

        public AddWindowsView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
{
    var button = sender as Button;
    button.Background = new SolidColorBrush(Color.FromRgb(102, 51, 153)); // Darker color on hover
}

private void Button_MouseLeave(object sender, MouseEventArgs e)
{
    var button = sender as Button;
    button.Background = new SolidColorBrush(Color.FromRgb(120, 79, 242)); // Original color
}

        
    }
}
