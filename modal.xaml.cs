using System;
using System.Windows;
using System.Windows.Controls;
using wpf1.ViewModels;
namespace UserProfileApp
{
    public partial class Modal : Window
    {
        public Modal()
        {
            InitializeComponent();
            DataContext = new ModalViewModel();
        }

        // Event handler for Save Button Click
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Sample user details (could be loaded from a database in a real application)
            string name = "John Doe";
            string email = "john.doe@example.com";
            string age = "30";
            string address = "123 Main Street, City";

            // Retrieve all diagnosis entries
            string diagnoses = "";
            foreach (Border diagnosisCard in DiagnosisListPanel.Children)
            {
                TextBlock diagnosisText = (TextBlock)diagnosisCard.Child;
                diagnoses += diagnosisText.Text + "\n";
            }

            // Display a confirmation message (for now, a MessageBox)
            MessageBox.Show($"User Information Saved:\nName: {name}\nEmail: {email}\nAge: {age}\nAddress: {address}\nDiagnoses:\n{diagnoses}", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for Add Diagnosis button click
        private void AddDiagnosis_Click(object sender, RoutedEventArgs e)
        {
            // Get the diagnosis text from the input TextBox
            string newDiagnosis = DiagnosisTextBox.Text;

            if (!string.IsNullOrWhiteSpace(newDiagnosis))
            {
                // Get current date
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                // Create a new StackPanel to display diagnosis text and date
                StackPanel diagnosisInfo = new StackPanel();
                diagnosisInfo.Orientation = Orientation.Vertical;

                // Diagnosis Text
                TextBlock diagnosisTextBlock = new TextBlock
                {
                    Text = newDiagnosis,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(5, 5, 0, 0)
                };

                // Diagnosis Date
                TextBlock diagnosisDateBlock = new TextBlock
                {
                    Text = $"Date: {currentDate}",
                    FontSize = 12,
                    FontStyle = FontStyles.Italic,
                    Margin = new Thickness(5, 0, 0, 10)
                };

                // Add the diagnosis text and date to the stack panel
                diagnosisInfo.Children.Add(diagnosisTextBlock);
                diagnosisInfo.Children.Add(diagnosisDateBlock);

                // Create a new border (card) to hold the diagnosis info
                Border diagnosisCard = new Border
                {
                    Background = System.Windows.Media.Brushes.LightGray,
                    CornerRadius = new CornerRadius(10),
                    BorderBrush = System.Windows.Media.Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(0, 10, 0, 0),
                    Padding = new Thickness(10),
                    Child = diagnosisInfo
                };

                // Add the new diagnosis card to the DiagnosisListPanel
                DiagnosisListPanel.Children.Add(diagnosisCard);

                // Clear the input TextBox for new entries
                DiagnosisTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid diagnosis before adding.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
