using System.Windows.Controls;
using System.Windows;
using wpf1.ViewModels;
using wpf1.Views.EmployeesView.EditWindowView;

namespace wpf1.Views.EmployeesView.EmployeesDataGrid
{
    public partial class EmployeesDataGrid : UserControl
    {
        public EmployeesDataGrid()
        {
            InitializeComponent();
		this.DataContext = new EmployeeDatagridViewModel();
        }
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
           
          
        }
    }
}