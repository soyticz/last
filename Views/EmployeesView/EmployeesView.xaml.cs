using System.Windows.Controls;
using System.Windows;
using wpf1.Models;
using wpf1.Views.EmployeesView.AddWindowView;

namespace wpf1.Views.EmployeesView
{
    public partial class EmployeesView : UserControl
    {
        private AddWindowsView _addWindow;
        public EmployeesView()
        {
            InitializeComponent();
        }

        public void AddEmployee(object sender, RoutedEventArgs e)
        {
             _addWindow = new AddWindowsView();
             _addWindow.Show();
        }
    }
}
