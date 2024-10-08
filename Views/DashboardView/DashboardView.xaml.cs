using System.Windows.Controls;
using System.Windows;
using wpf1.ViewModels;

namespace wpf1.Views.DashboardView
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        // Add the click event handler for the View button
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            // Find the MenuBar and the Patient RadioButton
            var mainWindow = Application.Current.MainWindow as MainWindow; // Assuming your main window is named MainWindow
            if (mainWindow != null)
            {
                var menuBar = mainWindow.FindName("MenuBar") as Menubar; // Assuming MenuBar has x:Name="MenuBar"
                if (menuBar != null)
                {
                    var patientButton = menuBar.FindName("PatientButton") as RadioButton; // Assuming the Patient RadioButton has x:Name="PatientButton"
                    if (patientButton != null)
                    {
                        patientButton.IsChecked = true;
                    }
                }
            }
        }
    }
}