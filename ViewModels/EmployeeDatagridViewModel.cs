using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Windows;
using wpf1.Firebase.FirebaseRepository;
using System.Windows.Input;
using wpf1.Views.EmployeesView.EditWindowView;
using wpf1.Commands;
namespace wpf1.ViewModels
{
    public class EmployeeDatagridViewModel : BaseMembersViewModel<EmployeeModel>
    {
       
        public EmployeeDatagridViewModel()
        {
           
        }
    }
}
