using System.Windows;
using System.Windows.Input;
using System.Windows.Controls; // Corrected this line
using System.Windows.Media;
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

        // Change button background color on mouse enter
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button) // Use pattern matching
            {
                button.Background = new SolidColorBrush(Color.FromRgb(102, 51, 153)); // Darker color on hover
            }
        }

        // Reset button background color on mouse leave
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button) // Use pattern matching
            {
                button.Background = new SolidColorBrush(Color.FromRgb(120, 79, 242)); // Original color
            }
        }
    }
}
