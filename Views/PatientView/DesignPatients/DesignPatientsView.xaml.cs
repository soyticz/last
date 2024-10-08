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
            if (sender is Border card)
            {
                // Get the patient name from the Tag property
                string patientName = card.Tag.ToString();
                
                // Update the bottom details display
                PatientDetailsTextBlock.Text = $"Details for {patientName}.";
            }
        }
    }
}
