using System.Windows.Controls;
using wpf1.ViewModels;

namespace wpf1.Views.ScheduleView.ScheduleDatagridView;
public partial class ScheduleDatagridView : UserControl
{
    public ScheduleDatagridView()
    {
        InitializeComponent();
        this.DataContext = new ScheduleDatagridViewModel();
    }
}