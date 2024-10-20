using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf1.ViewModels;
namespace wpf1.Views.PatientView.DesignPatients
{
    public partial class DesignPatientsView : UserControl
    {
        public DesignPatientsView()
        {
            InitializeComponent();
            DataContext = new PatientDatagridViewModel();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get the clicked patient data context
            var selectedPatient = (sender as FrameworkElement)?.DataContext;

            // Create and show the modal window
            var modal = new Modal(selectedPatient);
            modal.ShowDialog(); // Show the modal dialog
        }
    }
}
