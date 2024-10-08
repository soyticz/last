using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace wpf1.Views.PatientView.DesignPatients
{
    public partial class DesignPatientsView : UserControl
    {
        public DesignPatientsView()
        {
            InitializeComponent();
        }

        private void PatientCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PatientPopup.IsOpen = true;
            if (sender is Border patientCard && PatientPopup.IsOpen == true)
            {
                // Get the name of the patient from the TextBlock in the card
                var textBlock = (TextBlock)((Grid)patientCard.Child).Children[1];
                string patientName = textBlock.Text;

                // Example of patient details, you can customize this with actual data
                string patientDetails = "Patient Age: 30\nCondition: Healthy\nLast Visit: 01/01/2024";

                // Set the Popup content
                PopupPatientName.Text = patientName;
                PopupPatientDetails.Text = patientDetails;

                // Show the Popup
                
            }
        }

        private void ClosePopupButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the Popup
            PatientPopup.IsOpen = false;
        }
    }
}
