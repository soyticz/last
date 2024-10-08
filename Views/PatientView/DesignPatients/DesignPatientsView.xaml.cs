using System.Windows;
using System.Windows.Controls;

namespace wpf1.Views.PatientView.DesignPatients
{
    public partial class DesignPatientsView : UserControl
    {
        public DesignPatientsView()
        {
            InitializeComponent();
        }

        private void PatientCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Border patientCard)
            {
                // Get the name of the patient from the TextBlock in the card
                var textBlock = (TextBlock)((Grid)patientCard.Child).Children[1];
                string patientName = textBlock.Text;

                // Update the popup text and show it
                PopupTextBlock.Text = $"Details for {patientName}"; // Customize this with actual details
                PatientDetailsPopup.IsOpen = true;
            }
        }
    }
}
