using System.Windows;
using System.Windows.Controls;
namespace wpf1.Views.PatientView;

public partial class PatientView : UserControl
{
    private AddWindowView.AddWindowView _addWindow;
    public PatientView()
    {
        InitializeComponent();
    }

    public void AddPatientWindow(object sender, RoutedEventArgs e)
    {
        _addWindow = new AddWindowView.AddWindowView();
        _addWindow.Show();
    }
}