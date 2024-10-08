using System.ComponentModel;
using System.Windows.Input;
using wpf1.Commands;
using wpf1.Abstracts;
namespace wpf1.ViewModels
{
    public class MainViewModel : BaseNavigation
    {
        private bool _isMenuExpanded = true;

        public MainViewModel()
        {
            ToggleMenuCommand = new RelayCommandNonGeneric(OnToggleMenu);
            // ViewMappings["Dashboard"] = () => new DashboardViewModel();
            ViewMappings["Patient"] = () => new PatientViewModel();
            ViewMappings["Employees"] = () => new EmployeeViewModel();
            ViewMappings["Schedules"] = () => new ScheduleViewModel();
        }
        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                OnPropertyChanged(nameof(IsMenuExpanded));
                _isMenuExpanded = value;
            }
        }

        private void OnToggleMenu()
        {
            IsMenuExpanded = !IsMenuExpanded;
        }
        public ICommand ToggleMenuCommand { get; }

    }
}
