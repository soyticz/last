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
        }
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            // Get the EID from the CommandParameter
            var button = sender as Button;
            if (button != null)
            {
                string eid = button.CommandParameter as string;

                // Now you can use the EID to load the corresponding employee data for editing
                if (!string.IsNullOrEmpty(eid))
                {
                    // Open the Edit window and pass the EID
                    var _editWindowView = new EditWindowView.EditWindowView(eid);
                    _editWindowView.ShowDialog();
                }
            }
        }
    }
}