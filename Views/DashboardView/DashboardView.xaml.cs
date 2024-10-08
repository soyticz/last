using System.Windows.Controls;
using System.Windows;
using wpf1.ViewModels;

namespace wpf1.Views.DashboardView;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}