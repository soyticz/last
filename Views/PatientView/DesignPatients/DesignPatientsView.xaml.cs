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
    }
}
