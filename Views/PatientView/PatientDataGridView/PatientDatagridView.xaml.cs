using System.Windows.Controls;
using wpf1.ViewModels;

namespace wpf1.Views.PatientView.PatientDataGridView;
public partial class PatientDatagridView : UserControl
{
    public PatientDatagridView()
    {
        InitializeComponent();
        this.DataContext = new PatientDatagridViewModel();
    }
}