using System.Windows.Controls;
using System.Windows;
using wpf1.Models;
using wpf1.Firebase.Firestore;
using wpf1.Views.EmployeesView.AddWindowView;

namespace wpf1.Views.EmployeesView
{
    public partial class EmployeesView : UserControl
    {
        private AddWindowsView _addWindow;
        private string collectionName ="Employee";
        public EmployeesView()
        {
            InitializeComponent();
        }

        public void AddEmployeeWindow(object sender, RoutedEventArgs e)
        {
            _addWindow = new AddWindowsView();
            _addWindow.Show();
        }
        public void ImportFromExcel(object sender, RoutedEventArgs e)
        {
            FireStoreQuery.Instance.GetDataFromExcel(collectionName);
        }

    }
}
