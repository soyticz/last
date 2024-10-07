using wpf1.Models;
using wpf1.Abstracts;
using System;
using System.Collections.Generic; // Include this for List<T>
using System.Windows;
using System.Windows.Input;
using wpf1.Views.EmployeesView.EditWindowView;
using wpf1.Commands;

namespace wpf1.ViewModels
{
    public class EmployeeDatagridViewModel : BaseMembersViewModel<EmployeeModel>
    {
        public EmployeeDatagridViewModel()
        {
            // Initialize the employee listener in the constructor
            InitializeEmployeeListener();
        }

        private void InitializeEmployeeListener()
        {
            firestoreService.GetAllEmployees<EmployeeModel>(OnEmployeesDataChanged);
        }

        private void OnEmployeesDataChanged(ObservableCollection<EmployeeModel> employees)
        {
            // Update the UI here, e.g., populate a ListView or DataGrid
            employees.Clear(); // Clear existing employees if necessary
            
            foreach (var employee in employees)
            {
                employees.Add(employee); // Add new employees to the collection
            }
        }
    }
}
