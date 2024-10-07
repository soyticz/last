using System.Windows.Input;
using wpf1.Commands;
using wpf1.Abstracts;
using wpf1.Models;
using wpf1.Interfaces;
namespace wpf1.ViewModels
{
    public class EmployeeViewModel : BaseNavigation
    {
        public EmployeeViewModel()
        {
            // Map view names to their respective view models
            ViewMappings["Employees"] = () => new EmployeeDatagridViewModel();
            ViewMappings["Attendance"] = () => new AttendanceViewModel();
        }
    }
}
