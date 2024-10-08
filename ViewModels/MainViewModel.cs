using System.ComponentModel;
using System.Windows.Input;
using wpf1.Commands;
using wpf1.Abstracts;

namespace wpf1.ViewModels
{
    public class MainViewModel : BaseNavigation, INotifyPropertyChanged
    {
        private bool _isMenuExpanded = true;
        private string _selectedMenu;

        public MainViewModel()
        {
            ToggleMenuCommand = new RelayCommandNonGeneric(OnToggleMenu);
            ViewButtonCommand = new RelayCommandNonGeneric(ExecuteViewButton);

            ViewMappings["Dashboard"] = () => new DashboardViewModel();
            ViewMappings["Patient"] = () => new PatientViewModel();
            ViewMappings["Employees"] = () => new EmployeeViewModel();
            ViewMappings["Schedules"] = () => new ScheduleViewModel();
        }

        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                if (_isMenuExpanded != value)
                {
                    _isMenuExpanded = value;
                    OnPropertyChanged(nameof(IsMenuExpanded));
                }
            }
        }

        public string SelectedMenu
        {
            get => _selectedMenu;
            set
            {
                if (_selectedMenu != value)
                {
                    _selectedMenu = value;
                    OnPropertyChanged(nameof(SelectedMenu));
                }
            }
        }

        private void OnToggleMenu()
        {
            IsMenuExpanded = !IsMenuExpanded;
        }

        private void ExecuteViewButton()
        {
            SelectedMenu = "Patient"; // Set the selected menu to Patient when View button is clicked
            // Additional logic for viewing can be added here if needed
        }

        public ICommand ToggleMenuCommand { get; }
        public ICommand ViewButtonCommand { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
