using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserProfileApp;
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
    if (DataContext is PatientDatagridViewModel viewModel)
    {
        // Get the selected patient from the DataContext of the clicked border
        var selectedPatient = (sender as Border)?.DataContext as PatientModel;

        // Execute the command manually
        if (viewModel.ShowModalCommand.CanExecute(selectedPatient))
        {
            viewModel.ShowModalCommand.Execute(selectedPatient);
        }
    }
}

    }
}
