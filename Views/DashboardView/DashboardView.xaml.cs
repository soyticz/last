using System.Windows.Controls;
using System.Windows;
using wpf1.ViewModels;
using wpf1.Views.MenuBar;
using System.Windows.Input; // Make sure to include this for ICommand

namespace wpf1.Views.DashboardView
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
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
                        patientButton.IsChecked = true; // Select the RadioButton

                        // Trigger the Command associated with the RadioButton
                        var command = patientButton.Command; // Get the command
                        if (command != null && command.CanExecute(patientButton.CommandParameter))
                        {
                            command.Execute(patientButton.CommandParameter); // Execute the command with the parameter
                        }
                    }
                }
            }
        }
    }
}
